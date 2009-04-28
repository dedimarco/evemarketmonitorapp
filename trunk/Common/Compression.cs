using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.Common
{
    static class Compression
    {
        private const int BUFFERSIZE = 100000;
        private const long FOURGIG = 4000000000;

        /// <summary>
        /// Uncompress the specified compound file and write the individual files to the specified destination
        /// directory.
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="dstDir"></param>
        public static int DecompressDirectory(string srcFile, string dstDir)
        {
            string tempDataFile = string.Format("{0}Temp{1}Data.tmp",
                    AppDomain.CurrentDomain.BaseDirectory, Path.DirectorySeparatorChar);

            // First, decompress the file.
            DecompressFile(srcFile, tempDataFile);
            // Build destination directory and files.
            int fileVersion = BuildDirFromFile(tempDataFile, dstDir);

            File.Delete(tempDataFile);

            return fileVersion;
        }

        /// <summary>
        /// Build the contents of the specified destination directory from the specified EMMA compound file.
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="dstDir"></param>
        public static int BuildDirFromFile(string srcFile, string dstDir)
        {
            int charsInBuffer = 0;
            int charsSoFar = 0;
            char[] buffer = new char[BUFFERSIZE];
            string line = "";
            string currentFileName = "";
            int currentFileSize = 0;
            int fileVersion = 0;
            StreamReader reader = File.OpenText(srcFile);

            try
            {
                string firstLine = reader.ReadLine();
                // First, make sure it's an EMMA save file..
                if (!firstLine.StartsWith("**-- EMMA Compound Save File"))
                {
                    throw new EMMACompressionException(ExceptionSeverity.Error, "Supplied file is not an EMMA" +
                        " save data file. (" + srcFile + ")");
                }

                if (firstLine.Contains("Version:"))
                {
                    fileVersion = int.Parse(firstLine.Substring(firstLine.IndexOf("Version:") + 8), 
                        System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                }

                // Create the destination directory if required.
                if (!Directory.Exists(dstDir))
                {
                    Directory.CreateDirectory(dstDir);
                }
                else
                {
                    Directory.Delete(dstDir, true);
                    Directory.CreateDirectory(dstDir);
                }

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    StreamWriter writer = null;
                    charsSoFar = 0;

                    try
                    {
                        // Search for file headers, if we find one then populate the file name and size variables.
                        if (line.StartsWith("**--"))
                        {
                            int fileNameLoc = line.IndexOf("FileName:") + 9;
                            int fileSizeLoc = line.IndexOf("FileSize:") + 9;
                            currentFileName = line.Substring(fileNameLoc, (fileSizeLoc - 9) - fileNameLoc);
                            currentFileSize = int.Parse(line.Substring(fileSizeLoc, line.Length - fileSizeLoc), 
                                System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                            writer = File.CreateText(dstDir + currentFileName);
                        }
                        // If a file header has been identified then extract the data and write the file.
                        while (!currentFileName.Equals(""))
                        {
                            // Read a block of data into the buffer but do not go past the end of this file
                            // within the compound file.
                            charsInBuffer = reader.ReadBlock(buffer, 0,
                                Math.Min(currentFileSize - charsSoFar, BUFFERSIZE));
                            charsSoFar += charsInBuffer;

                            // write out the data in the buffer to the destination file.
                            writer.Write(buffer, 0, charsInBuffer);

                            // If we've reached the end of the file within the compound file then clear the
                            // current file variables to allow us to go back round and start looking for the 
                            // next file.
                            if (charsInBuffer < BUFFERSIZE)
                            {
                                currentFileName = "";
                                currentFileSize = 0;
                            }

                        }
                    }
                    finally
                    {
                        if(writer != null) writer.Close();
                    }
                }

            }
            finally
            {
                reader.Close();
            }

            return fileVersion;
        }

        /// <summary>
        /// Produce a compressed file containing all of the files in the specified directory.
        /// Note this does NOT include sub-directories or files in sub-directories.
        /// </summary>
        /// <param name="srcDir"></param>
        /// <param name="dstFile"></param>
        /// <param name="deleteSrcDir"></param>
        public static void CompressDirectory(string srcDir, string dstFile, bool deleteSrcDir)
        {
            // This works by first building a big file containing the data from all the files
            // in the source directory + a bit of header information for each one.
            // This large file is then compressed.
            // Note that because of limitations with GZipStream this will not work on directories
            // with 4Gb or more of data. (Should not be a problem here!)

            // First do some checks...
            if (!Directory.Exists(srcDir))
            {
                throw new EMMACompressionException(ExceptionSeverity.Error, "Source directory for compression does " +
                    "not exist. (" + srcDir + ")");
            }
            if (GetTotalDirSize(srcDir) > FOURGIG)
            {
                throw new EMMACompressionException(ExceptionSeverity.Error, "Source directory for compression " +
                    "contains total data of more than four gigabytes. (" + srcDir + ")");
            }

            string tempDataFile = string.Format("{0}Temp{1}Data.tmp",
                    AppDomain.CurrentDomain.BaseDirectory, Path.DirectorySeparatorChar);

            try
            {
                // Build the single large temp file with all the other files inside it.
                BuildFileFromDir(srcDir, tempDataFile);
                // Compress the large file and write out to the destination location.
                CompressFile(tempDataFile, dstFile);

                if (deleteSrcDir)
                {
                    // Delete the source dir if the flag is on.
                    Directory.Delete(srcDir, true);
                }
            }
            catch (Exception ex)
            {
                throw new EMMACompressionException(ExceptionSeverity.Error, "Problem compressing directory to file.\r\n" +
                    "Source directory: " + srcDir + "\r\nDestination File: " + dstFile, ex);
            }
            finally
            {
                // Delete the temp file.
                File.Delete(tempDataFile);
            }
        }

        /// <summary>
        /// Take all the files in the source directory and put them into one big file separated by
        /// header information.
        /// </summary>
        /// <param name="srcDir"></param>
        /// <param name="dstFile"></param>
        private static void BuildFileFromDir(string srcDir, string dstFile)
        {
            int charsInBuffer = 0;
            char[] buffer = new char[BUFFERSIZE];
            string[] files = Directory.GetFiles(srcDir);
            StreamWriter writer = File.CreateText(dstFile);

            try
            {
                writer.WriteLine("**-- EMMA Compound Save File Version: 1.2");

                foreach (string file in files)
                {
                    // Loop through all files in the source directory
                    FileInfo fileInfo = new FileInfo(file);
                    StreamReader reader = File.OpenText(file);
                    int realFileSize = 0;

                    // This seems to be the only way to get an accurate count of the 
                    // number of characters in a file
                    //--------------------------------------------------------
                    try
                    {
                        // Read blocks of the source file and count up the total chars read.
                        while (!reader.EndOfStream)
                        {
                            charsInBuffer = reader.ReadBlock(buffer, 0, BUFFERSIZE);
                            realFileSize += charsInBuffer;
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                    //--------------------------------------------------------

                    // Open the same file again to copy out the data... lame.
                    reader = File.OpenText(file);

                    try
                    {
                        // write the header for this file.
                        writer.WriteLine();
                        writer.WriteLine(string.Format("**-- FileName:{0} FileSize:{1}",
                            fileInfo.Name, realFileSize)); //reader.BaseStream.Length));

                        // Read blocks of the source file and write them out to the destination file.
                        while (!reader.EndOfStream)
                        {
                            charsInBuffer = reader.ReadBlock(buffer, 0, BUFFERSIZE);

                            writer.Write(buffer, 0, charsInBuffer);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Decompress the specified file and create a new file that contains the uncompressed data.
        /// </summary>
        /// <param name="srcFile">The file to be decompressed</param>
        /// <param name="dstFile">The destination file for the decompressed data</param>
        public static void DecompressFile(string srcFile, string dstFile)
        {
            int bytesInBuffer = BUFFERSIZE;
            int bytesSoFar = 0;
            byte[] buffer = new byte[BUFFERSIZE];

            if (!File.Exists(srcFile))
            {
                throw new EMMACompressionException(ExceptionSeverity.Error, "Source file for decompression does " +
                    "not exist. (" + srcFile + ")");
            }

            FileStream inputStream = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream outputStream = new FileStream(dstFile, FileMode.Create, FileAccess.Write,
                FileShare.None);
            GZipStream zipStream = new GZipStream(inputStream, CompressionMode.Decompress, true);
            try
            {
                while (bytesInBuffer == BUFFERSIZE)
                {
                    bytesInBuffer = zipStream.Read(buffer, 0, BUFFERSIZE);
                    outputStream.Write(buffer, 0, bytesInBuffer);
                    bytesSoFar += bytesInBuffer;
                }
            }
            catch (Exception ex)
            {
                throw new EMMACompressionException(ExceptionSeverity.Error, "Problem decompressing data.\r\n" +
                    "Source File: " + srcFile + "\r\nDestination File: " + dstFile, ex);
            }
            finally
            {
                inputStream.Close();
                outputStream.Close();
                zipStream.Close();
            }
        }

        /// <summary>
        /// Read the specified file, compress the data and create a new file containing the compressed data.
        /// </summary>
        /// <param name="srcFile">The file to be compressed</param>
        /// <param name="dstFile">The destination file for the compressed data</param>
        public static void CompressFile(string srcFile, string dstFile)
        {
            int bytesInBuffer = 0;
            int bytesSoFar = 0;
            byte[] buffer = new byte[BUFFERSIZE];

            if (!File.Exists(srcFile))
            {
                throw new EMMACompressionException(ExceptionSeverity.Error, "Source file for decompression does " +
                    "not exist. (" + srcFile + ")");
            }

            FileStream outputStream = new FileStream(dstFile, FileMode.Create, FileAccess.Write,
                FileShare.None);
            GZipStream zipStream = new GZipStream(outputStream, CompressionMode.Compress, true);

            FileStream inputStream = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                while (bytesSoFar < inputStream.Length)
                {
                    bytesInBuffer = inputStream.Read(buffer, 0, BUFFERSIZE);
                    zipStream.Write(buffer, 0, bytesInBuffer);
                    bytesSoFar += bytesInBuffer;
                }
            }
            catch (Exception ex)
            {
                throw new EMMACompressionException(ExceptionSeverity.Error, "Problem compressing data.\r\n" +
                    "Source File: " + srcFile + "\r\nDestination File: " + dstFile, ex);
            }
            finally
            {
                inputStream.Close();
                zipStream.Close();
                outputStream.Close();
            }

        }


        /// <summary>
        /// Get the size of all the files in the specified directory.
        /// Note this does NOT include sub-directories or files in sub-directories.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private static long GetTotalDirSize(string directory)
        {
            // don't really need to know about sub dirs so removed the relevant lines
            string[] files;
            //string[] dirs;
            long retVal = 0;

            files = Directory.GetFiles(directory);
            //dirs = Directory.GetDirectories(directory);

            foreach (string file in files)
            {
                retVal += new FileInfo(file).Length;
            }
            //foreach (string dir in dirs)
            //{
            //    retVal += GetTotalDirSize(dirs);
            //}

            return retVal;
        }

    }
}

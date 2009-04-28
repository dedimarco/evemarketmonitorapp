using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace AutoUpdater
{
    static class Compression
    {
        private const int BUFFERSIZE = 100000;
        private const long FOURGIG = 4000000000;

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
                throw new Exception("Source file for decompression does " +
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
                throw new Exception("Problem decompressing data.\r\n" +
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

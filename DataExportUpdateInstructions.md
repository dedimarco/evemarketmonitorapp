How to update EMMA with new data export:

(Data updates will be released through EMMA's auto-update system. This procedure is for those who do not want to wait for the automatic update)


1. Download and extract .bak file.

2. Make a copy of EveData.mdf (and log file) somewhere like C:\Temp\Old

3. Open SQL server management studio and attach the database file you just copied, change the 'attach as' property to OLDEVEDATA for clarity.

4. Right click Databases->Tasks->Restore->Database

5. In the 'to database' field, enter 'EVEDATA'. Select the 'From a device' option and browse to the datadump .bak file. Check the 'Restore' option in the list. Go to the options page and check 'overwrite existing database' Change the 'restore as' filenames to your temp location (e.g. C:\Temp\EveData.mdf and C:\Temp\EveData\_log.ldf). Click 'ok' and wait for it to finish.

6. Right click EVEDATA -> Properties and go to the Files page. Change the logical names to 'EVEDATA' and 'EVEDATA\_log' respectively.

7. Open 'Tables' for both EVEDATA and OLDEVEDATA. Remove all tables from EVEDATA that are not in OLDEVEDATA.

8. Right click OLDEVEDATA -> Tasks -> Generate Scripts. Make sure the correct database is selected (OLDEVEDATA). Leave the defaults options. on the choose object types screen, select Assemblies, Stored Procedures and User Defined Functions. On each of the following screens click 'select all'. Finally, use the 'script to new query editor window' option.

9. scroll to the top and change 'USE OLDEVEDATA?' to 'USE EVEDATA?'

10. Click execute.

11. Execute the stored procedures called 'INIT' and 'INIT2'. These set up the jump distance tables based upon the new data and the item build requirements table and should take no more than a few seconds to complete.

12. Right click EVEDATA->tasks->shrink->database, check 'reorganise files' and click ok.

13. Right click EVEDATA->tasks->detatch. check 'drop connection' and click ok.

14. Copy the EVEDATA mdf and log files back to the EMMA folder.
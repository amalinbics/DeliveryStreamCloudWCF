﻿//2013.12.23 FSWW, Ramesh M Added For CR#61509 Modified logging style
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace DeliveryStreamCloudWCF.Utils
{
    /// <summary>
    /// Logging
    /// Logging class
    /// </summary>
    public class Logging
    {
        private static string _fileName = string.Empty;

        /// <summary>
        /// Log folder path
        /// </summary>
        private static string LogFolder
        {
            get
            {
                String folderPath = string.Empty;
                try
                {
                   // folderPath = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
                    folderPath = ConfigurationManager.AppSettings["LogFile"];
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                }
                catch
                {
                    folderPath = AppDomain.CurrentDomain.BaseDirectory;
                }

                return folderPath;
            }
        }

        /// <summary>
        /// Log file name
        /// </summary>
        private static string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(_fileName))
                {
                    _fileName = LogFolder + "\\Log_";
                    _fileName = _fileName + DateTime.Now.ToString("MM") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("dd") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("yyyy") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("HH") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("mm") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("ss") + ".txt";
                }
                else
                {

                    if (!File.Exists(_fileName))
                    {
                        FileStream file = File.Create(_fileName);
                        if (file.Length > 1048576)
                        {
                            _fileName = string.Empty;
                            return FileName;
                        }
                        file.Close();
                    }
                    else
                    {
                        FileInfo file = new FileInfo(_fileName);
                        if (file.Length > 1048576)
                        {
                            _fileName = string.Empty;
                            return FileName;
                        }
                    }
                    //FileInfo file = new FileInfo(_fileName);
                    //if (file.Length > 1048576)
                    //{
                    //    _fileName = string.Empty;
                    //    return FileName;
                    //}
                }

                return _fileName;
            }
        }

        /// <summary>
        /// LogError
        /// Function to Log Error
        /// </summary>
        /// <param name="ex">Exception</param>
        ///  <param name="ex">Exception</param>
        // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Added CustomerInfo parameter to add More Details about calling function in Error log file.
        public static void LogError(Exception ex,String CustomerInfo)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                WriteToEventLog(CustomerInfo + String.Format(ApplicationConstants.Errors.FunctionError,
                                  stackTrace.GetFrame(1).GetMethod().Name, stackTrace.GetFrame(1).GetType().FullName, ex.Message, ex.StackTrace), EventLogEntryType.Error);
            }
            catch
            {
                //Do nothing
                //Supress exception when unable to log the errors
            }

        }

        /// <summary>
        /// WriteLog
        /// Function to Write Log
        /// </summary>
        /// <param name="message">String</param>
        /// <param name="EventType">EventLogEntryType</param>
        public static void WriteLog(String message, EventLogEntryType EventType)
        {
            WriteToEventLog(message, EventType);
        }

        /// <summary>
        /// WriteToEventLog
        /// Function to Write Log To EventLog
        /// </summary>
        /// <param name="message">String</param>
        /// <param name="EventType">EventLogEntryType</param>
        private static void WriteToEventLog(String message, EventLogEntryType EventType)
        {
            WriteToFile(message);

            EventLog objEventLog = new EventLog();
            try
            {
                if (!EventLog.SourceExists(ApplicationConstants.Logging.Source))
                    EventLog.CreateEventSource(ApplicationConstants.Logging.Source, ApplicationConstants.Logging.Log);

            }
            catch (Exception)
            {
                //Do nothing
            }

            try
            {
                objEventLog.Log = ApplicationConstants.Logging.Log;
                objEventLog.Source = ApplicationConstants.Logging.Source;
                objEventLog.WriteEntry(message, EventType);
                objEventLog.Close();
            }
            catch (Exception)
            {
                //Do nothing
            }

        }

        /// <summary>
        /// WriteToFile
        /// Function to write log to file
        /// </summary>
        /// <param name="message">String</param>
        private static void WriteToFile(String message)
        {
            try
            {
                FileInfo file = null;

                file = new FileInfo(FileName);


                using (StreamWriter writer = file.AppendText())
                {
                    //Write message to the log file
                    //2013.12.05 FSWW, Ramesh M Added For CR#60643
                    //2013.12.23 FSWW, Ramesh M Added For CR#61509 Modified logging style
                    writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+":" + message );                   
                }

            }
            catch
            {
                //do nothing
            }
        }
        // 2013.07.22 FSWW, Ramesh M Added For 
        public static void LogInfoAboutCallingFunction(String message)
        {
            try
            {
                FileInfo file = null;

                file = new FileInfo(FileName);


                using (StreamWriter writer = file.AppendText())
                {
                    //Write message to the log file
                    //2013.12.05 FSWW, Ramesh M Added For CR#60643
                    //2013.12.23 FSWW, Ramesh M Added For CR#61509 Modified logging style
                    writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message);                    
                }

            }
            catch
            {
                //do nothing
            }
        }
    }
}

using PaperlessRedemption_Schedular.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaperlessRedemption_Schedular.Helper
{
    public static class CLogger
    {
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        private static readonly string appRootPath = AppDomain.CurrentDomain.BaseDirectory;
        public static void ProcessInformationLog(object information)
        {
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                //System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Finish2.txt");
                var errorFile = Path.Combine(appRootPath, "information.txt");
                //var errorFile = Path.Combine(appRootPath, "logs", "error-log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                using (StreamWriter sw = (File.Exists(errorFile)) ? File.AppendText(errorFile) : File.CreateText(errorFile))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + information);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }
        public static void ProcessError(Exception ex)
        {
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                //System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Finish2.txt");
                var errorFile = Path.Combine(appRootPath, "error.txt");
                //var errorFile = Path.Combine(appRootPath, "logs", "error-log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                using (StreamWriter sw = (File.Exists(errorFile)) ? File.AppendText(errorFile) : File.CreateText(errorFile))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.Message);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.ToString());
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + "-------------------------------------------------------------------------------------------");
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public static void ProcessError(Exception ex, ServiceCaller serviceCaller)
        {
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                var errorFile = Path.Combine(appRootPath, "logs", "error-log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                using (StreamWriter sw = (File.Exists(errorFile)) ? File.AppendText(errorFile) : File.CreateText(errorFile))
                {
                    sw.WriteLine($"Service Caller: {Enum.GetName(typeof(ServiceCaller), serviceCaller)}");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.Message);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.ToString());
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + "-------------------------------------------------------------------------------------------");
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public static void ProcessError(Exception ex, ServiceCaller serviceCaller, ServiceType serviceType)
        {
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                var errorFile = Path.Combine(appRootPath, "logs", "error-log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                using (StreamWriter sw = (File.Exists(errorFile)) ? File.AppendText(errorFile) : File.CreateText(errorFile))
                {
                    sw.WriteLine($"Service Caller: {Enum.GetName(typeof(ServiceCaller), serviceCaller)}");
                    sw.WriteLine($"Service Type: {Enum.GetName(typeof(ServiceType), serviceType)}");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.Message);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.ToString());
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + "-------------------------------------------------------------------------------------------");
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public static void ProcessActivities(string activities, string response, string title, DateTime  date,string url = "")
        {
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                var errorFile = Path.Combine(appRootPath, "logs", "activities-log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                using (StreamWriter sw = (File.Exists(errorFile)) ? File.AppendText(errorFile) : File.CreateText(errorFile))
                {
                    sw.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:tt"));
                    sw.WriteLine("Title: " + title);
                    sw.WriteLine("Event: " + activities);
                    if (!string.IsNullOrEmpty(url))
                        sw.WriteLine("Url: " + url);
                    sw.WriteLine("Response: " + response);
                    sw.WriteLine("Date: " + date);
                    sw.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }
    }
}

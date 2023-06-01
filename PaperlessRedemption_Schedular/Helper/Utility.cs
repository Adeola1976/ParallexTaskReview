using Newtonsoft.Json;
using PaperlessRedemption_Schedular.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRedemption_Schedular.Helper
{
    public class Utility
    {


        public static Dictionary<string, object> GetAppSettingsFromAppConfig()
        {
            AppSettingsReader appSettingsReader = new AppSettingsReader();

            Dictionary<string, object> dictionaryAppSettings = new Dictionary<string, object>();
            //ServiceExecutionDailyCommencementTime
            dictionaryAppSettings.Add("ServiceExecutionDailyCommencementTime", appSettingsReader.GetValue("ServiceExecutionDailyCommencementTime", typeof(string)));
            //DaysToExclude
            dictionaryAppSettings.Add("DaysToExclude", appSettingsReader.GetValue("DaysToExclude", typeof(string)));

            return dictionaryAppSettings;
        }

        public static string ValidateServiceExecutionDailyCommencementTime(out List<TimeSpan> _listServiceExecutionDailyCommencementTime)
        {
            string msg = "";

            List<TimeSpan> listServiceExecutionDailyCommencementTime = new List<TimeSpan>();

            try
            {
                //get the working hours from config file
                string serviceExecutionDailyCommencementTime = Utility.GetAppSettingsFromAppConfig()["ServiceExecutionDailyCommencementTime"].ToString();
                string[] serviceExecutionDailyCommencementTimeInArray = serviceExecutionDailyCommencementTime.Split(';');

                if (serviceExecutionDailyCommencementTimeInArray.Length == 0)
                {
                    _listServiceExecutionDailyCommencementTime = listServiceExecutionDailyCommencementTime;
                    return "Service execution commencement hours not yet configured";
                }

                List<string> listServiceExecutionDailyCommencementTimeInString = new List<string>();

                foreach (var item in serviceExecutionDailyCommencementTimeInArray)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        listServiceExecutionDailyCommencementTimeInString.Add(item.Trim());
                    }
                }

                if (!listServiceExecutionDailyCommencementTimeInString.Any())
                {
                    _listServiceExecutionDailyCommencementTime = listServiceExecutionDailyCommencementTime;
                    return "Service execution commencement hours not yet configured";
                }

                //check if service execution commencement hours are valid time               

                foreach (var item in listServiceExecutionDailyCommencementTimeInString)
                {
                    TimeSpan time = new TimeSpan();

                    if (!TimeSpan.TryParse(item, out time))
                    {
                        msg += $"{item} is not a valid time; ";
                    }
                    else
                    {
                        listServiceExecutionDailyCommencementTime.Add(time);
                    }
                }

                if (!string.IsNullOrEmpty(msg))
                {
                    _listServiceExecutionDailyCommencementTime = listServiceExecutionDailyCommencementTime;
                    return msg;
                }

                _listServiceExecutionDailyCommencementTime = listServiceExecutionDailyCommencementTime;
                return msg;
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                _listServiceExecutionDailyCommencementTime = listServiceExecutionDailyCommencementTime;
                return msg;
            }
        }

        public static string ValidateDaysToExclude(out List<DaysOfWeek> daysOfWeekToExclude)
        {
            string msg = "";
            List<DaysOfWeek> _daysOfWeekToExclude = new List<DaysOfWeek>();

            try
            {
                string weekDaysToExclude = GetAppSettingsFromAppConfig()["DaysToExclude"].ToString();

                if (!string.IsNullOrEmpty(weekDaysToExclude))
                {
                    string[] weekDaysToExcludeInArray = weekDaysToExclude.Split(';');

                    if (weekDaysToExcludeInArray.Length > 0)
                    {
                        List<string> listDaysOfWeekToExclude = new List<string>();

                        foreach (var item in weekDaysToExcludeInArray)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                listDaysOfWeekToExclude.Add(item.Trim());
                            }
                        }

                        if (listDaysOfWeekToExclude.Any())
                        {
                            //check if item in the list is a valid day of the week                           

                            foreach (var item in listDaysOfWeekToExclude)
                            {
                                DaysOfWeek daysOfWeek;

                                if (Enum.TryParse<DaysOfWeek>(item, true, out daysOfWeek))
                                {
                                    _daysOfWeekToExclude.Add(daysOfWeek);
                                }
                                else
                                {
                                    msg += $"{item} is not a valid day of the week; ";
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }
            }

            daysOfWeekToExclude = _daysOfWeekToExclude;

            return msg;
        }

    }
}

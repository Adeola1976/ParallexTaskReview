using Newtonsoft.Json;
using PaperlessRedemption_Schedular.Data;
using PaperlessRedemption_Schedular.Enums;
using PaperlessRedemption_Schedular.Helper;
using PaperlessRedemption_Schedular.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static PaperlessRedemption_Schedular.Models.AutoMatchTransaction;

namespace PaperlessRedemption_Schedular
{
    public partial class PaperlessRedemptionService : ServiceBase
    {
        Timer serviceTimer = new Timer();
        List<TimeSpan> _listServiceExecutionDailyCommencementTime = new List<TimeSpan>();
        List<DaysOfWeek> listDaysOfWeekToExclude = new List<DaysOfWeek>();

        private readonly string _connectionString;
        private readonly string serviceName = "Paperless Redemption Service";
        string msg = "";

        public PaperlessRedemptionService()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["DatahubConnection"].ConnectionString;
        }

        protected  override void OnStart(string[] args)
        {
            try 
            {

                  msg = Utility.ValidateServiceExecutionDailyCommencementTime(out _listServiceExecutionDailyCommencementTime);
                  //validate days of the week to exclude
                  msg += Utility.ValidateDaysToExclude(out listDaysOfWeekToExclude);
                  if (string.IsNullOrEmpty(msg))
                {
                    serviceTimer.Elapsed += new ElapsedEventHandler(serviceTimer_Elapsed);
                    //slaParentTimer.Interval = 5000; //5s measured in milliseconds
                    //serviceTimer.Interval = double.Parse(Utility.GetAppSettingsFromAppConfig()["ServiceTriggeringInterval"].ToString()) * 60.0d * 1000.0d; // measured in milliseconds
                    serviceTimer.Interval = 1.0d * 60.0d * 1000.0d; // measured in milliseconds //this is 1 minutes i.e event fired every one minute
                    serviceTimer.Enabled = true;
                }  
            }

            catch (Exception eX)
            {
                CLogger.ProcessError(eX);
            }

        }


        private async void serviceTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //skip the days of the week configured in app config file                    
                if (listDaysOfWeekToExclude.Contains((DaysOfWeek)DateTime.Now.DayOfWeek))
                {
                    return;
                }

                foreach (var itemCommencementTime in _listServiceExecutionDailyCommencementTime)
                {
                    //if (itemCommencementTime.ToString("hh':'mm") == DateTime.Now.TimeOfDay.ToString("hh':'mm"))
                     //{
                        DateTime endDate = DateTime.Today;
                        DateTime startDate = DateTime.Today;
                        var webResponse = await NavWebServiceCall.CallService(startDate, endDate);
                        bool didDataInserted = await AMStpPaymentTrans.InsertPaymentSTPTransaction(_connectionString, webResponse.TProperty);
                        if (didDataInserted == true)
                        {
                           CLogger.ProcessActivities($"{serviceName} running fine", "", "Data inserted successfully", DateTime.Now);
                        }

                        else
                        {
                            CLogger.ProcessActivities($"{serviceName} running fine", "", "record already exist", DateTime.Now);
                        }
                    }
               // }
            }


            catch (Exception eX)
            {
                CLogger.ProcessError(eX);
            }
        }

        protected override void OnStop()
        {
            CLogger.ProcessActivities($"{serviceName} was stopped", "", $"{serviceName} stopped", DateTime.Now);
        }

    }
}

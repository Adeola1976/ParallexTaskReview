using Newtonsoft.Json;
using PaperlessRedemption_Schedular.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRedemption_Schedular.Helper
{
    public class NavWebServiceCall
    {

        

        public static async Task<ApiResponse> CallService(DateTime startDate, DateTime endDate)
        {

            //WHAT TO CHANGE FOR OTHERS: RESPONSE
            ApiResponse response = new ApiResponse();
            string msg = "";

            try
            {

                NavSoapWebService.WebServiceNAVSoapClient client = new NavSoapWebService.WebServiceNAVSoapClient("WebServiceNAVSoap");
                var webResponse = JsonConvert.SerializeObject(await client.GetPostedRedemptionAsync(startDate, endDate));
                
                if(webResponse.Length>0)
                {
                         var webResponseObject = JsonConvert.DeserializeObject<Parent>(webResponse);  
                         response.TProperty = webResponseObject; 
                
                }
                return response;
            }
            catch (Exception eX)
            {
                CLogger.ProcessError(eX);
                msg = eX.Message;
                response.ErrorMsg = msg;
                return response;
            }


        }


    }
}

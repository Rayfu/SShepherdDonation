/*
	Name:        ProcessDonation.cs
	Description: Process method is used to process the donation transaction using secured fileds.
	Version:     1.0.0
	Author:      Ray Fu
	Adapted (heavily modified) from eWAY.Rapid3.0-ASP.Net-REST-SampleCode https://www.eway.com.au/eway-partner-portal/resources
*/

using SSDonationBLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SSDonationBLL
{
    public class ProcessDonation
    {
        /// <summary>
        /// Process the donation transaction using secured fileds
        /// </summary>
        /// <param name="transactionDetails">the ResultRequest instance</param>
        /// <returns>the ResultResponse instance</returns>
        public ResultResponse Process(ResultRequest resultRequest)
        {
            string strResponse = string.Empty;
            ResultResponse resultResponse = null;
            string strUrl = resultRequest.Url;
            string strError = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(strUrl));
            string username = resultRequest.UserName;
            string password = resultRequest.Password;
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)));
            request.Method = "POST";
            request.ContentType = "application/json";
            TransactionDetails transactionDetails = new TransactionDetails()
            {
                TransactionType = "Purchase",
                SecuredCardData = resultRequest.SecuredCardData,
                Method = "ProcessPayment",
                Payment = resultRequest.Payment,
                Customer = resultRequest.Customer
            };
            string parsedContent = Utility.SerializeObjectToJSON(transactionDetails);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(parsedContent);
                streamWriter.Flush();
                streamWriter.Close();
            }
            using (StreamReader stream = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                strResponse = stream.ReadToEnd();
            }
            if (!string.IsNullOrEmpty(strResponse))
            {
                resultResponse = Utility.DeserializeJSONResonse<ResultResponse>(strResponse);
            }
            else
            {
                strError = "Something has gone wrong with eWay, no response received.";
            }
            resultResponse.Error = strError;
            return resultResponse;
        }
    }
}

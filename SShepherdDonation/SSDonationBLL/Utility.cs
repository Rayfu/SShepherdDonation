/*
	Name:        Utility.cs
	Description: Serialize given object to JSON and  Deserialize JSON to Object.
	Version:     1.0.0
	Author:      Ray Fu
	Adapted (modified) from eWAY.Rapid3.0-ASP.Net-REST-SampleCode https://www.eway.com.au/eway-partner-portal/resources
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SSDonationBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDonationBLL
{
    public class Utility
    {
        /// <summary>
        /// Serialize given object to JSON
        /// </summary>
        /// <param name="obj">c# object</param>
        /// <returns>json string</returns>
        public static string SerializeObjectToJSON(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            settings.Converters.Add(new StringEnumConverter());
            settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            string json = JsonConvert.SerializeObject(obj, settings);
            return json;
        }
        /// <summary>
        /// Deserialize JSON to Object
        /// </summary>
        /// <typeparam name="T">c# customized type</typeparam>
        /// <param name="json">json string</param>
        /// <returns>T object</returns>
        public static T DeserializeJSONResonse<T>(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            settings.Converters.Add(new StringEnumConverter());
            settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
        /// <summary>
        /// Translate the eWay validation response codes into meaningful messages. 
        /// </summary>
        /// <param name="resultResponse">ResultResponse instance.</param>
        /// <returns>List<string> instance</returns>
        public static List<string> TranslateErrors(ResultResponse resultResponse)
        {
            var result = new List<string>();
            var errorCodes = resultResponse.Errors.Split(',').ToList();
            if (resultResponse.Errors.Contains("V6111"))
            {
                result.Add("Unauthorised API Access, Account Not PCI Certified");
                errorCodes.Remove("V6111");
            }
            if (resultResponse.Errors.Contains("V6148"))
            {
                result.Add("Secure Field has Expired");
                errorCodes.Remove("V6148");
            }
            if (resultResponse.Errors.Contains("V6149"))
            {
                result.Add(" Invalid Secure Field One Time Code");
                errorCodes.Remove("V6149");
            }
            if (resultResponse.Errors.Contains("V6010"))
            {
                result.Add(" Invalid Transaction Type, account not certified for eCome only MOTO or Recurring available");
                errorCodes.Remove("V6010");
            }
            if (resultResponse.Errors.Contains("V6021"))
            {
                result.Add("CARD HOLDER NAME Required");
                errorCodes.Remove("V6021");
            }
            if (resultResponse.Errors.Contains("V6022"))
            {
                result.Add("CARD NUMBER Required");
                errorCodes.Remove("V6022");
            }
            if (resultResponse.Errors.Contains("V6023"))
            {
                result.Add("CARD CVN Required");
                errorCodes.Remove("V6023");
            }
            if (resultResponse.Errors.Contains("V6033"))
            {
                result.Add("Invalid Expiry Date");
                errorCodes.Remove("V6033");
            }
            if (resultResponse.Errors.Contains("V6034"))
            {
                result.Add("Invalid Issue Number");
                errorCodes.Remove("V6034");
            }
            if (resultResponse.Errors.Contains("V6035"))
            {
                result.Add("Invalid Valid From Date");
                errorCodes.Remove("V6035");
            }
            if (resultResponse.Errors.Contains("V6040"))
            {
                result.Add("Invalid Token CustomerID");
                errorCodes.Remove("V6040");
            }
            if (resultResponse.Errors.Contains("V6100"))
            {
                result.Add("Invalid CARD NAME");
                errorCodes.Remove("V6100");
            }
            if (resultResponse.Errors.Contains("V6101"))
            {
                result.Add("Invalid CARD EXPIRY MONTH");
                errorCodes.Remove("V6101");
            }
            if (resultResponse.Errors.Contains("V6102"))
            {
                result.Add("Invalid CARD EXPIRY YEAR");
                errorCodes.Remove("V6102");
            }
            if (resultResponse.Errors.Contains("V6103"))
            {
                result.Add("Invalid CARD START MONTH");
                errorCodes.Remove("V6103");
            }
            if (resultResponse.Errors.Contains("V6104"))
            {
                result.Add("Invalid CARD START YEAR");
                errorCodes.Remove("V6104");
            }
            if (resultResponse.Errors.Contains("V6105"))
            {
                result.Add("Invalid CARD ISSUE NUMBER");
                errorCodes.Remove("V6105");
            }
            if (resultResponse.Errors.Contains("V6106"))
            {
                result.Add("Invalid CARD CVN");
                errorCodes.Remove("V6106");
            }
            if (resultResponse.Errors.Contains("V6011"))
            {
                result.Add("Invalid Payment Total Amount");
                errorCodes.Remove("V6011");
            }
            if (resultResponse.Errors.Contains("V6016"))
            {
                result.Add("Payment Required");
                errorCodes.Remove("V6016");
            }
            if (resultResponse.Errors.Contains("V6110"))
            {
                result.Add("Invalid CARD NUMBER");
                errorCodes.Remove("V6110");
            }
            if (resultResponse.Errors.Contains("V6161"))
            {
                result.Add("Encryption failed, missing or invalid key");
                errorCodes.Remove("V6161");
            }
            if (errorCodes.Count() > 0)
                result.Add("eWay Internal error, please contact administrator for more information");

            return result;
        }
    }
}

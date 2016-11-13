using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SSDonationBLL
{
    public class EWayServiceConfig
    {
        private string _Url;
        private string _UserName;
        private string _Password;

        public EWayServiceConfig()
        {
            _Url = string.Format("{0}/{1}", "https://api.sandbox.ewaypayments.com", "transaction");
            _UserName = "F9802CL6tBYFeInWkTdR/ZTnii9NgHEz7fZNVCrWf0FSTnfXlMBxdM0lgJD5QSYSoOqUlI";
            _Password = "Abcd1234";
        }

        public string Url
        {
            get { return _Url; }
        }

        public string UserName
        {
            get { return _UserName; }
        }

        public string Password
        {
            get { return _Password; }

        }
    }
}
/*
	Name:        ResultRequest.cs
	Description: Reprsents the donation request using secured fileds.
	Version:     1.0.0
	Author:      Ray Fu
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDonationBLL.Models
{
    public class ResultRequest
    {
        private string _SecuredCardData;
        private Payment _Payment;
        private Customer _Customer;
        private string _Url;
        private string _UserName;
        private string _Password;

        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string SecuredCardData
        {
            get { return _SecuredCardData; }
            set { _SecuredCardData = value; }
        }

        public Payment Payment
        {
            get { return _Payment; }
            set { _Payment = value; }
        }

        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }
    }
}

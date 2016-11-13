/*
	Name:        Payment.cs
	Description: Payment class represents the payment.
	Version:     1.0.0
	Author:      Ray Fu
	Adapted from eWAY.Rapid3.0-ASP.Net-REST-SampleCode https://www.eway.com.au/eway-partner-portal/resources
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDonationBLL.Models
{
    public class Payment
    {
        private int _TotalAmount;
        private string _InvoiceNumber;
        private string _InvoiceDescription;
        private string _InvoiceReference;
        private string _CurrencyCode;

        public int TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        public string InvoiceNumber
        {
            get { return _InvoiceNumber; }
            set { _InvoiceNumber = value; }
        }

        public string InvoiceDescription
        {
            get { return _InvoiceDescription; }
            set { _InvoiceDescription = value; }
        }

        public string InvoiceReference
        {
            get { return _InvoiceReference; }
            set { _InvoiceReference = value; }
        }

        public string CurrencyCode
        {
            get { return _CurrencyCode; }
            set { _CurrencyCode = value; }
        }
    }
}

/*
	Name:        TransactionDetails.cs
	Description: TransactionDetails class represents the transaction.
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
    public class TransactionDetails
    {
        private string _TransactionType;
        private string _Method;
        private string _SecuredCardData;
        private Payment _Payment;
        private Customer _Customer;

        public string TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
        }

        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
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

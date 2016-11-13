/*
	Name:        ResultResponse.cs
	Description: Includes ResultResponse calss represents the response, VerificationResult class, Option class, and VerificationStatus enum.
	Version:     1.0.0
	Author:      Ray Fu
	Adapted (heavily modified) from eWAY.Rapid3.0-ASP.Net-REST-SampleCode https://www.eway.com.au/eway-partner-portal/resources
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDonationBLL.Models
{
    public class ResultResponse
    {
        private string _AccessCode;
        private string _AuthorisationCode;
        private string _ResponseCode;
        private string _ResponseMessage;
        private string _InvoiceNumber;
        private string _InvoiceReference;
        private int? _TotalAmount;
        private int? _TransactionID;
        private bool? _TransactionStatus;
        private long? _TokenCustomerID;
        private decimal? _BeagleScore;
        private List<Option> _Options;
        private VerificationResult _Verification;
        private string _Error;
        private Customer _Customer;
        private Payment _Payment;
        private string _Errors;
        private string _TransactionType;

        public string TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
        }

        public string Errors
        {
            get { return _Errors; }
            set { _Errors = value; }
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

        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }

        public string AccessCode
        {
            get { return _AccessCode; }
            set { _AccessCode = value; }
        }

        public string AuthorisationCode
        {
            get { return _AuthorisationCode; }
            set { _AuthorisationCode = value; }
        }

        public string ResponseCode
        {
            get { return _ResponseCode; }
            set { _ResponseCode = value; }
        }

        public string ResponseMessage
        {
            get { return _ResponseMessage; }
            set { _ResponseMessage = value; }
        }

        public string InvoiceNumber
        {
            get { return _InvoiceNumber; }
            set { _InvoiceNumber = value; }
        }

        public string InvoiceReference
        {
            get { return _InvoiceReference; }
            set { _InvoiceReference = value; }
        }

        public int? TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        public int? TransactionID
        {
            get { return _TransactionID; }
            set { _TransactionID = value; }
        }

        public bool? TransactionStatus
        {
            get { return _TransactionStatus; }
            set { _TransactionStatus = value; }
        }

        public long? TokenCustomerID
        {
            get { return _TokenCustomerID; }
            set { _TokenCustomerID = value; }
        }

        public decimal? BeagleScore
        {
            get { return _BeagleScore; }
            set { _BeagleScore = value; }
        }

        public List<Option> Options
        {
            get { return _Options; }
            set { _Options = value; }
        }

        public VerificationResult Verification
        {
            get { return _Verification; }
            set { _Verification = value; }
        }

    }

    public class VerificationResult
    {
        public VerificationStatus _CVN;
        public VerificationStatus _Address;
        public VerificationStatus _Email;
        public VerificationStatus _Mobile;
        public VerificationStatus _Phone;

        public VerificationStatus CVN
        {
            get { return _CVN; }
            set { _CVN = value; }
        }

        public VerificationStatus Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public VerificationStatus Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public VerificationStatus Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        public VerificationStatus Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
    }
    public class Option
    {
        private string _Value;

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
    public enum VerificationStatus
    {
        @Unchecked = 0,
        Valid = 1,
        Invalid = 2
    }
}
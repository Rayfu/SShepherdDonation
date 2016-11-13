using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSDonationBLL.Models;
using System.ComponentModel.DataAnnotations;

namespace SSDonationPresentationLayer.Models
{
    public class ResultResponseVM
    {
        private int? _TotalAmount;
        private int? _TransactionID;
        private bool? _TransactionStatus;
        private string _InternalError;
        private string _EWayReturnedErrors;
        private List<string> _ValidationErrors;

        public ResultResponseVM()
        {
            _ValidationErrors = new List<string>();
        }

        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        public int? TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        [Display(Name = "Transaction ID")]
        public int? TransactionID
        {
            get { return _TransactionID; }
            set { _TransactionID = value; }
        }

        [Display(Name = "Transaction Status")]
        public bool? TransactionStatus
        {
            get { return _TransactionStatus; }
            set { _TransactionStatus = value; }
        }

        [Display(Name = "Internal Error")]
        public string InternalError
        {
            get { return _InternalError; }
            set { _InternalError = value; }
        }

        [Display(Name = "Validation Errors")]
        public List<string> ValidationErrors
        {
            get { return _ValidationErrors; }
            set { _ValidationErrors = value; }
        }

        public string EWayReturnedErrors
        {
            get { return _EWayReturnedErrors; }
            set { _EWayReturnedErrors = value; }
        }
    }
}
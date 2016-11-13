/*
	Name:        DonationVM.cs
	Description: Donation view model.
	Version:     1.0.0
	Author:      Ray Fu
*/
using SSDonationBLL.Models;
using SSDonationPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSDonationPresentation.Models
{
    public class DonationVM
    {
        private string _SecuredCardData;
        private int _TotalAmount;
        private string _Email;
        private string _Phone;
        private string _FirstName;
        private string _LastName;
        private ResultResponseVM _ResultResponseVM;

        [DataType(DataType.Currency)]
        public int TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        public ResultResponseVM ResultResponseVM
        {
            get { return _ResultResponseVM; }
            set { _ResultResponseVM = value; }
        }

        public string SecuredCardData
        {
            get { return _SecuredCardData; }
            set { _SecuredCardData = value; }
        }

        [Display(Name = "First Name")]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        [Display(Name = "Last Name")]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        [EmailAddress]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
    }
}
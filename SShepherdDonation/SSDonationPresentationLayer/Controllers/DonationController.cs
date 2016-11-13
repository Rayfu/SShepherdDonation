/*
	Name:        DonationController.cs
	Description: Donation controller  .
	Version:     1.0.0
	Author:      Ray Fu
*/
using SSDonationBLL;
using SSDonationBLL.Models;
using SSDonationPresentation.Models;
using SSDonationPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSDonationPresentation.Controllers
{
    public class DonationController : Controller
    {
        /// <summary>
        /// Process the donation request using SSDonationBLL's ProcessDonation class.
        /// </summary>
        /// <param name="donationVM">DonationVM instance.</param>
        /// <returns> _ResultResponse PartialView with a ResultResponse instance.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Process(DonationVM donationVM)
        {
            ResultResponseVM resultResponseVM = new ResultResponseVM();
            if (string.IsNullOrEmpty(donationVM.SecuredCardData))
            {
                resultResponseVM.ValidationErrors.Add("Please enter the Card Details");
            }
            if (string.IsNullOrEmpty(donationVM.Email) && string.IsNullOrEmpty(donationVM.Phone))
            {
                resultResponseVM.ValidationErrors.Add("Either email or phone must be supplied");
            }
            donationVM.TotalAmount = donationVM.TotalAmount * 100;
            if (resultResponseVM.ValidationErrors.Count() == 0 && ModelState.IsValid)
            {
                try
                {
                    EWayServiceConfig config = new EWayServiceConfig();
                    ResultRequest resultRequest = new ResultRequest()
                    {
                        Url = config.Url,
                        UserName = config.UserName,
                        Password = config.Password,
                        Customer = new Customer
                        {
                            FirstName = donationVM.FirstName,
                            LastName = donationVM.LastName,
                            Email = donationVM.Email,
                            Phone = donationVM.Phone
                        },
                        Payment = new Payment
                        {
                            TotalAmount = donationVM.TotalAmount
                        },
                        SecuredCardData = donationVM.SecuredCardData
                    };
                    ProcessDonation processDonation = new ProcessDonation();
                    ResultResponse resultResponse = processDonation.Process(resultRequest);
                    resultResponseVM.TotalAmount = resultResponse.Payment.TotalAmount / 100;
                    resultResponseVM.TransactionID = resultResponse.TransactionID;
                    resultResponseVM.TransactionStatus = resultResponse.TransactionStatus;
                    resultResponseVM.EWayReturnedErrors = resultResponse.Error;
                    if (!string.IsNullOrEmpty(resultResponse.Errors))
                        resultResponseVM.ValidationErrors.AddRange(Utility.TranslateErrors(resultResponse));
                }
                catch (Exception ex)
                {
                    resultResponseVM.InternalError += "Internal error, please contact administrator for more information." + ex.Message;
                }
            }
            donationVM.ResultResponseVM = resultResponseVM;
            return View("Index", donationVM);
        }
        /// <summary>
        /// The site entry point. 
        /// </summary>
        /// <returns>Donation view.</returns>
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
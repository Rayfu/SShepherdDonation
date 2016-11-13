/*
	Name:        ProcessDonationTests.cs
	Description: Unit test the ProcessDonation.Process() method.
	Version:     1.0.0
	Author:      Ray Fu
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSDonationBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSDonationBLL.Models;
using System.Configuration;
namespace SSDonationBLL.Tests
{
    [TestClass()]
    public class ProcessDonationTests
    {
        private ResultRequest resultRequest;

        [TestInitialize]
        public void SetUp()
        {
            EWayServiceConfig config = new EWayServiceConfig();
            resultRequest = new ResultRequest()
           {
               Url = config.Url,
               UserName = config.UserName,
               Password = config.Password,
               Customer = new Customer
               {
                   FirstName = "Ray",
                   LastName = "Fu",
                   Email = "ray.fu@gmail.com",
                   Phone = "0402020202",
                   CardDetails = new CardDetails
                   {
                       Name = "Ray",
                       Number = "4444333322221111",
                       ExpiryMonth = 12,
                       ExpiryYear = 22,
                       CVN = 123
                   }
               },
               Payment = new Payment
               {
                   TotalAmount = 1234
               },
               SecuredCardData = string.Empty
           };
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (resultRequest != null)
                resultRequest = null;
        }

        [TestMethod()]
        public void ProcessTest_When_CardDetailsWithoutSecuredCardData_Then_TotalAmountIsNullAndWithoutCVNOfCardDeatils()
        {
            ProcessDonation processDonation = new ProcessDonation();
            ResultResponse resultResponse = processDonation.Process(resultRequest);
            //Customer
            Assert.AreEqual(resultRequest.Customer.FirstName, resultResponse.Customer.FirstName);
            Assert.AreEqual(resultRequest.Customer.LastName, resultResponse.Customer.LastName);
            Assert.AreEqual(resultRequest.Customer.Email, resultResponse.Customer.Email);
            Assert.AreEqual(resultRequest.Customer.Phone, resultResponse.Customer.Phone);
            //Customer.CardDetails
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryMonth, resultResponse.Customer.CardDetails.ExpiryMonth);
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryYear, resultResponse.Customer.CardDetails.ExpiryYear);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Name, resultResponse.Customer.CardDetails.Name);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Number.Substring(0, 4), resultResponse.Customer.CardDetails.Number.Substring(0, 4));
            Assert.AreEqual(0, resultResponse.Customer.CardDetails.CVN);
            //Payment
            Assert.AreEqual(resultRequest.Payment.TotalAmount, resultResponse.Payment.TotalAmount);
            //Transaction            
            Assert.AreEqual(null, resultResponse.TotalAmount);
        }

        [TestMethod()]
        public void ProcessTest_When_CardDetailsWtihCVNIsZero_Then_TotalAmountIsNullAndWithoutCVNOfCardDeatils()
        {
            resultRequest.Customer.CardDetails.CVN = 0;
            ProcessDonation processDonation = new ProcessDonation();
            ResultResponse resultResponse = processDonation.Process(resultRequest);
            //Customer
            Assert.AreEqual(resultRequest.Customer.FirstName, resultResponse.Customer.FirstName);
            Assert.AreEqual(resultRequest.Customer.LastName, resultResponse.Customer.LastName);
            Assert.AreEqual(resultRequest.Customer.Email, resultResponse.Customer.Email);
            Assert.AreEqual(resultRequest.Customer.Phone, resultResponse.Customer.Phone);
            //Customer.CardDetails
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryMonth, resultResponse.Customer.CardDetails.ExpiryMonth);
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryYear, resultResponse.Customer.CardDetails.ExpiryYear);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Name, resultResponse.Customer.CardDetails.Name);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Number.Substring(0, 4), resultResponse.Customer.CardDetails.Number.Substring(0, 4));
            Assert.AreEqual(0, resultResponse.Customer.CardDetails.CVN);
            //Payment
            Assert.AreEqual(resultRequest.Payment.TotalAmount, resultResponse.Payment.TotalAmount);
            //Transaction            
            Assert.AreEqual(null, resultResponse.TotalAmount);
        }

        [TestMethod()]
        public void ProcessTest_When_CardDetailsWtihOldSecuredCardData_Then_TotalAmountIsNullAndWithoutCVNOfCardDeatils()
        {
            resultRequest.SecuredCardData = "F98022RmAfT0H_TWcj8eYs9PJ-3GpeO-CWxytygesIzti9QhpRl6JvqAifCEuk9YCZe9O";
            ProcessDonation processDonation = new ProcessDonation();
            ResultResponse resultResponse = processDonation.Process(resultRequest);
            //Customer
            Assert.AreEqual(resultRequest.Customer.FirstName, resultResponse.Customer.FirstName);
            Assert.AreEqual(resultRequest.Customer.LastName, resultResponse.Customer.LastName);
            Assert.AreEqual(resultRequest.Customer.Email, resultResponse.Customer.Email);
            Assert.AreEqual(resultRequest.Customer.Phone, resultResponse.Customer.Phone);
            //Customer.CardDetails
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryMonth, resultResponse.Customer.CardDetails.ExpiryMonth);
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryYear, resultResponse.Customer.CardDetails.ExpiryYear);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Name, resultResponse.Customer.CardDetails.Name);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Number.Substring(0, 4), resultResponse.Customer.CardDetails.Number.Substring(0, 4));
            Assert.AreEqual(0, resultResponse.Customer.CardDetails.CVN);
            //Payment
            Assert.AreEqual(resultRequest.Payment.TotalAmount, resultResponse.Payment.TotalAmount);
            //Transaction            
            Assert.AreEqual(null, resultResponse.TotalAmount);
        }

        [TestMethod()]
        public void ProcessTest_When_OldSecuredCardDataWithNullCardDetails_Then_TotalAmountIsNullAndWithoutCVNOfCardDeatils()
        {
            resultRequest.Customer.CardDetails = null;
            resultRequest.SecuredCardData = "F98022RmAfT0H_TWcj8eYs9PJ-3GpeO-CWxytygesIzti9QhpRl6JvqAifCEuk9YCZe9O";
            ProcessDonation processDonation = new ProcessDonation();
            ResultResponse resultResponse = processDonation.Process(resultRequest);
            //Customer
            Assert.AreEqual(resultRequest.Customer.FirstName, resultResponse.Customer.FirstName);
            Assert.AreEqual(resultRequest.Customer.LastName, resultResponse.Customer.LastName);
            Assert.AreEqual(resultRequest.Customer.Email, resultResponse.Customer.Email);
            Assert.AreEqual(resultRequest.Customer.Phone, resultResponse.Customer.Phone);
            //Customer.CardDetails
            Assert.AreEqual(0, resultResponse.Customer.CardDetails.ExpiryMonth);
            Assert.AreEqual(0, resultResponse.Customer.CardDetails.ExpiryYear);
            Assert.AreEqual(null, resultResponse.Customer.CardDetails.Name);
            Assert.AreEqual(null, resultResponse.Customer.CardDetails.Number);
            Assert.AreEqual(0, resultResponse.Customer.CardDetails.CVN);
            //Payment
            Assert.AreEqual(resultRequest.Payment.TotalAmount, resultResponse.Payment.TotalAmount);
            //Transaction            
            Assert.AreEqual(null, resultResponse.TotalAmount);
        }

        [TestMethod()]
        public void ProcessTest_When_CardDetailsWithoutName_Then_TotalAmountIsNullAndWithoutCVNOfCardDeatils()
        {
            resultRequest.Customer.CardDetails.Name = null;
            ProcessDonation processDonation = new ProcessDonation();
            ResultResponse resultResponse = processDonation.Process(resultRequest);
            //Customer
            Assert.AreEqual(resultRequest.Customer.FirstName, resultResponse.Customer.FirstName);
            Assert.AreEqual(resultRequest.Customer.LastName, resultResponse.Customer.LastName);
            Assert.AreEqual(resultRequest.Customer.Email, resultResponse.Customer.Email);
            Assert.AreEqual(resultRequest.Customer.Phone, resultResponse.Customer.Phone);
            //Customer.CardDetails
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryMonth, resultResponse.Customer.CardDetails.ExpiryMonth);
            Assert.AreEqual(resultRequest.Customer.CardDetails.ExpiryYear, resultResponse.Customer.CardDetails.ExpiryYear);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Name, resultResponse.Customer.CardDetails.Name);
            Assert.AreEqual(resultRequest.Customer.CardDetails.Number.Substring(0, 4), resultResponse.Customer.CardDetails.Number.Substring(0, 4));
            Assert.AreEqual(0, resultResponse.Customer.CardDetails.CVN);
            //Payment
            Assert.AreEqual(resultRequest.Payment.TotalAmount, resultResponse.Payment.TotalAmount);
            //Transaction            
            Assert.AreEqual(null, resultResponse.TotalAmount);
        }
    }
}

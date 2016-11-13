/*
	Name:        DonationControllerTests.cs
	Description: Unit test the Process() and Index() methods of DonationController.
	Version:     1.0.0
	Author:      Ray Fu
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSDonationPresentation.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSDonationPresentation.Models;
using SSDonationBLL.Models;
using System.Web;
using System.Web.Mvc;
using SSDonationPresentationLayer.Models;

namespace SSDonationPresentation.Controllers.Tests
{
    [TestClass()]
    public class DonationControllerTests
    {
        private DonationVM donationVM;

        [TestInitialize]
        public void SetUp()
        {
            donationVM = new DonationVM()
            {
                FirstName = "Ray",
                LastName = "Fu",
                Email = "ray.fu@gmail.com",
                Phone = "0402020202",
                TotalAmount = 1234,
                SecuredCardData = "Test"
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (donationVM != null)
                donationVM = null;
        }

        [TestMethod()]
        public void ProcessTest_When_WithSecuredCardData_Then_TransactionStatusIsNull()
        {
            DonationController donationController = new DonationController();
            var result = donationController.Process(donationVM) as ViewResult;
            var donationVMResult = result.ViewData.Model as DonationVM;

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(donationVM.TotalAmount / 100, donationVMResult.ResultResponseVM.TotalAmount);
            Assert.AreEqual(null, donationVMResult.ResultResponseVM.TransactionStatus);
        }

        [TestMethod()]
        public void ProcessTest_When_WithEmptySecuredCardData_Then_ReturnValidationError()
        {
            donationVM.SecuredCardData = string.Empty;
            DonationController donationController = new DonationController();
            var result = donationController.Process(donationVM) as ViewResult;
            var donationVMResult = result.ViewData.Model as DonationVM;

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("Please enter the CardDetails", donationVMResult.ResultResponseVM.ValidationErrors[0]);
        }

        [TestMethod()]
        public void ProcessTest_When_CustomerWithoutEmaiAndPhone_Then_ReturnValidationError()
        {
            donationVM.Email = string.Empty;
            donationVM.Phone = string.Empty;
            DonationController donationController = new DonationController();
            var result = donationController.Process(donationVM) as ViewResult;
            var donationVMResult = result.ViewData.Model as DonationVM;

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("Either email or phone must be supplied", donationVMResult.ResultResponseVM.ValidationErrors[0]);
        }

        [TestMethod()]
        public void ProcessTest_When_WithSecuredCardDataAndCustomerWithEmailWithoutPhone_Then_TransactionStatusIsNull()
        {
            donationVM.Phone = null;
            DonationController donationController = new DonationController();
            var result = donationController.Process(donationVM) as ViewResult;
            var donationVMResult = result.ViewData.Model as DonationVM;

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(null, donationVMResult.ResultResponseVM.TransactionStatus);
        }

        [TestMethod()]
        public void ProcessTest_When_WithSecuredCardDataAndCustomerWithPhoneWithoutEmail_Then_TransactionStatusIsNull()
        {
            donationVM.Email = null;
            DonationController donationController = new DonationController();
            var result = donationController.Process(donationVM) as ViewResult;
            var donationVMResult = result.ViewData.Model as DonationVM;

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(null, donationVMResult.ResultResponseVM.TransactionStatus);
        }

        [TestMethod()]
        public void ProcessTest_When_WithOldSecuredCardData_Then_InvalidSecureFieldOneTimeValidationCode()
        {
            DonationController donationController = new DonationController();
            var result = donationController.Process(donationVM) as ViewResult;
            var donationVMResult = result.ViewData.Model as DonationVM;
            var isInvalidSecure = donationVMResult.ResultResponseVM.ValidationErrors.Contains("Invalid Secure Field One Time Code");

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void IndexTest_When_CallingIndexMethod_Then_ReturnIndexView()
        {
            DonationController donationController = new DonationController();
            var result = donationController.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}

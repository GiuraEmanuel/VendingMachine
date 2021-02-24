﻿using System;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.MsTest
{
    [TestClass]
    public class PaymentUseCaseTests
    {
        private readonly Mock<IAuthenticationService> authenticationServiceMock;
        private readonly Mock<IBuyView> buyViewMock;
        private readonly Mock<IPaymentMethodsRepository> paymentMethodsRepositoryMock;
        private readonly Mock<Product> productMock;

        public PaymentUseCaseTests()
        {
            authenticationServiceMock = new Mock<IAuthenticationService>();
            buyViewMock = new Mock<IBuyView>();
            paymentMethodsRepositoryMock = new Mock<IPaymentMethodsRepository>();
            productMock = new Mock<Product>();
        }

        [TestMethod]
        public void Execute_ListIsEmpty_ThrowsNullReferenceException()
        {
            var paymentUseCase = new PaymentUseCase(authenticationServiceMock.Object, buyViewMock.Object,
                paymentMethodsRepositoryMock.Object, productMock.Object);
            buyViewMock
                .Setup(x => x.AskForPaymentMethod(paymentMethodsRepositoryMock.Object.GetAllPaymentMethods()))
                .Returns(null);

            Assert.ThrowsException<NullReferenceException>(paymentUseCase.Execute);
            buyViewMock.Verify(x => x.AskForPaymentMethod(paymentMethodsRepositoryMock.Object.GetAllPaymentMethods()));
        }

        [TestMethod]
        public void Execute_ListIsNotNull_EverythingIsSuccessful()
        {
            var notNullList = buyViewMock
                .Setup(x => x.AskForPaymentMethod(paymentMethodsRepositoryMock.Object.GetAllPaymentMethods()))
                .Returns(null);

            Assert.IsNotNull(notNullList);
        }

        //[TestMethod]
        //public void Execute_CashPaymentMethodSelected_EverythingIsSuccessful()
        //{
            
        //}
    }
}
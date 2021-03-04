using System;
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
    }
}
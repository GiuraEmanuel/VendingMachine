using iQuest.VendingMachine;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
namespace VendingMachine.MsTest
{
    [TestClass]
    public class BuyUseCaseTests
    {
        private readonly Mock<IAuthenticationService> authenticationServiceMock;
        private readonly Mock<IBuyView> buyViewMock;
        private readonly Mock<IProductRepository> productRepositoryMock;
        private readonly Mock<IDispenserView> dispenserViewMock;


        public BuyUseCaseTests()
        {
            authenticationServiceMock = new Mock<IAuthenticationService>();
            buyViewMock = new Mock<IBuyView>();
            productRepositoryMock = new Mock<IProductRepository>();
            dispenserViewMock = new Mock<IDispenserView>();
        }

        [TestMethod]
        public void Execute_InvalidInput_ThrowsInvalidColumnException()
        {
            var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object,dispenserViewMock.Object, buyViewMock.Object);
            Assert.ThrowsException<InvalidColumnException>(() => buyUseCase.Execute());
        }

        [TestMethod]
        public void Execute_QuantityLessThanOrEqualToZero_ThrowsInsufficentStockException()
        {
            var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object, dispenserViewMock.Object, buyViewMock.Object);
            Assert.ThrowsException<InsuficientStockException>(() => buyUseCase.Execute());
        }
    }
}

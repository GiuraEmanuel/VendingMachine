using iQuest.VendingMachine;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            buyViewMock.Setup(x => x.AskForColumnId()).Returns(10);
            Assert.ThrowsException<InvalidColumnException>(() => buyUseCase.Execute());
        }

        [TestMethod]
        public void Execute_QuantityLessThanOrEqualToZero_ThrowsInsufficentStockException()
        {
            var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object, dispenserViewMock.Object, buyViewMock.Object);

            buyViewMock.Setup(x => x.AskForColumnId()).Returns(1);
            productRepositoryMock.Setup(x => x.GetByColumn(1).SetQuantity(0));


            Assert.ThrowsException<InsuficientStockException>(() => buyUseCase.Execute());
        }

        [TestMethod]
        public void Execute_NullOrWhiteSpaceInput_ThrowsCancelException()
        {
            var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object, dispenserViewMock.Object, buyViewMock.Object);

            buyViewMock.Setup(x => x.AskForColumnId()).Throws<CancelException>();

            Assert.ThrowsException<CancelException>(() => buyUseCase.Execute());
        }

        [TestMethod]
        public void Execute_ValidInput_EverythingSuccesful()
        {
            var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object, dispenserViewMock.Object, buyViewMock.Object);
            Product product = new Product(1, "Cola", 1, 1.00M);
            productRepositoryMock.Setup(x => x.GetByColumn(1)).Returns(product);
            buyViewMock.Setup(x => x.AskForColumnId()).Returns(product.ColumnId);
            

            dispenserViewMock.Setup(x => x.DispenseProduct(product.Name));

            // don't know how to assert that the flow succesfully executes.
        }
    }
}

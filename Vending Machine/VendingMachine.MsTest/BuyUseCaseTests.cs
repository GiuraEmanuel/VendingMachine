using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.MsTest
{
    [TestClass]
    public class BuyUseCaseTests
    {
        private readonly Mock<IAuthenticationService> authenticationServiceMock;
        private readonly Mock<BuyView> buyViewMock;
        private readonly Mock<IProductRepository> productRepositoryMock;
        private readonly DispenserView dispenserView;
        private readonly Mock<IPaymentMethodProcessor> paymentMethodsRepositoryMock;
        private readonly InputOutputService inputOutputService;

        public BuyUseCaseTests()
        {
            authenticationServiceMock = new Mock<IAuthenticationService>();
            buyViewMock = new Mock<BuyView>();
            productRepositoryMock = new Mock<IProductRepository>();
            dispenserView = new DispenserView(inputOutputService);
            paymentMethodsRepositoryMock = new Mock<IPaymentMethodProcessor>();
            inputOutputService = new InputOutputService();
        }

        [TestMethod]
        public void Execute_InvalidInput_ThrowsInvalidColumnException()
        {
            var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object, dispenserView, buyViewMock.Object, paymentMethodsRepositoryMock.Object);
            buyViewMock.Setup(buyViewMock => buyViewMock.AskForColumnId()).Returns(7);
            Assert.ThrowsException<InvalidColumnException>(() => buyUseCase.Execute());
        }

        //[TestMethod]
        //public void Execute_QuantityLessThanOrEqualToZero_ThrowsInsufficientStockException()
        //{
        //    var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object,
        //        dispenserViewMock.Object, buyViewMock.Object, paymentMethodsRepositoryMock.Object);

        //    buyViewMock.Setup(x => x.AskForColumnId()).Returns(1);
        //    productRepositoryMock.Setup(x => x.GetByColumn(1).SetQuantity(0));

        //    Assert.ThrowsException<InsufficientStockException>(() => buyUseCase.Execute());
        //}

        //[TestMethod]
        //public void Execute_NullOrWhiteSpaceInput_ThrowsCancelException()
        //{
        //    var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object,
        //        dispenserViewMock.Object, buyViewMock.Object, paymentMethodsRepositoryMock.Object);

        //    buyViewMock.Setup(x => x.AskForColumnId()).Throws<CancelException>();

        //    Assert.ThrowsException<CancelException>(() => buyUseCase.Execute());
        //}

        //[TestMethod]
        //public void Execute_ValidInput_EverythingSuccessful()
        //{
        //    var buyUseCase = new BuyUseCase(authenticationServiceMock.Object, productRepositoryMock.Object,
        //        dispenserViewMock.Object, buyViewMock.Object, paymentMethodsRepositoryMock.Object);
        //    Product product = new Product(1, "Cola", 5, 1.00M);
        //    var expectedQuantity = 4;
        //    buyViewMock.Setup(x => x.AskForColumnId()).Returns(product.ColumnId);
        //    productRepositoryMock.Setup(x => x.GetByColumn(1)).Returns(product);
        //    dispenserViewMock.Setup(x => x.DispenseProduct(product.Name));


        //    buyUseCase.Execute();
        //    buyViewMock.Verify(x => x.AskForColumnId());
        //    productRepositoryMock.Verify(x => x.GetByColumn(1));
        //    dispenserViewMock.Verify(x => x.DispenseProduct(product.Name));

        //    Assert.AreEqual(product.Quantity, expectedQuantity);
        //}
    }
}
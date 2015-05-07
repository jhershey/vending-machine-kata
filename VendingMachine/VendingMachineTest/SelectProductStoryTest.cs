using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public class SelectProductStoryTest
    {
        private VendingMachine.VendingMachine machine;

        [TestInitialize]
        public void Setup()
        {
            machine = new VendingMachine.VendingMachine();            
        }

        [TestMethod]
        public void ShouldDispenseProductWithEnoughMoney()
        {          
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            Assert.AreEqual(machine.SelectProduct(Product.Cola), Product.Cola);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.DisplayMessages.THANK_YOU);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.DisplayMessages.INSERT_COIN);
            Assert.AreEqual(machine.CurrentAmount, 0);

            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            Assert.AreEqual(machine.SelectProduct(Product.Chips), Product.Chips);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.DisplayMessages.THANK_YOU);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.DisplayMessages.INSERT_COIN);
            Assert.AreEqual(machine.CurrentAmount, 0);

            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            Assert.AreEqual(machine.SelectProduct(Product.Candy), Product.Candy);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.DisplayMessages.THANK_YOU);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.DisplayMessages.INSERT_COIN);
            Assert.AreEqual(machine.CurrentAmount, 0);
            
        }

        [TestMethod]
        public void ShouldDisplayPriceWithNotEnoughMoney()
        {
            machine.InsertCoin(Coin.Quarter);
            Assert.AreEqual(machine.SelectProduct(Product.Cola), null);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.CreatePriceMessage(Product.Cola) );
            Assert.AreEqual(machine.Display, (int)Coin.Quarter);
            Assert.AreEqual(machine.CurrentAmount, 0);

        }
    }
}

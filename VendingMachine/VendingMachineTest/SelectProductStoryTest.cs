using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public class SelectProductStoryTest
    {

        [TestMethod]
        public void ShouldDispenseProductWithEnoughMoney()
        {
            var machine = new VendingMachine.VendingMachine();

            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            Assert.AreEqual(machine.SelectProduct(Product.Cola), Product.Cola);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.THANK_YOU_DISPLAY);

            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            Assert.AreEqual(machine.SelectProduct(Product.Chips), Product.Chips);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.THANK_YOU_DISPLAY);

            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            Assert.AreEqual(machine.SelectProduct(Product.Candy), Product.Candy);
            Assert.AreEqual(machine.Display, VendingMachine.VendingMachine.THANK_YOU_DISPLAY);

        }
    }
}

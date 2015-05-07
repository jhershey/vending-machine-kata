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

        }
    }
}

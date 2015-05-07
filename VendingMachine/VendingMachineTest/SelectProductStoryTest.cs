using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public partial class SelectProductStoryTest
    {
        [TestMethod]
        public void ShouldDispenseProduct()
        {
            var machine = new VendingMachine.VendingMachine();
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.SelectProduct(Product.Cola);
            Assert.AreEqual(machine.Dispenser, Product.Cola);


        }
    }
}

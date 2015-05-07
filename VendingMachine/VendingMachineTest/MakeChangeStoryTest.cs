using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public class MakeChangeStoryTest
    {
        [TestMethod]
        public void ShouldGiveBackExtraMoneyToCoinReturn()
        {
            var machine = new VendingMachine.VendingMachine();
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.InsertCoin(Coin.Quarter);
            machine.SelectProduct(Product.Chips);
            Assert.AreEqual(machine.CoinReturn, 50);
            
        }
    }
}

﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public class AcceptCoinsStoryTest
    {
        private VendingMachine.VendingMachine machine;

        [TestInitialize]
        public void Setup()
        {
            machine  = new VendingMachine.VendingMachine();
        }

        [TestMethod]
        public void ShouldAcceptValidCoins()
        {
            machine.InsertCoin(Coin.Nickle);
            machine.InsertCoin(Coin.Dime);
            machine.InsertCoin(Coin.Quarter);
        }

        [TestMethod]
        [ExpectedException(typeof(VendingMachine.VendingMachine.InvalidCoinException))]
        public void ShouldRejectInvalidCoins()
        {
            machine.InsertCoin(Coin.Penny);
        }

        [TestMethod]
        public void ShouldAddAmountToAndDisplayCurrentAmount()
        {
            machine.InsertCoin(Coin.Nickle);
            Assert.AreEqual(machine.CurrentAmount, 5);
            Assert.AreEqual(machine.GetDisplay(), "5");

            machine.InsertCoin(Coin.Dime);
            Assert.AreEqual(machine.CurrentAmount, 15);
            Assert.AreEqual(machine.GetDisplay(), "15");
        }

        [TestMethod]
        public void ShouldDisplayINSERTCOINSWhenNoCoins()
        {
            Assert.AreEqual(machine.GetDisplay(), VendingMachine.VendingMachine.DisplayMessages.INSERT_COIN);
        }

        [TestMethod]
        public void ShouldPutRejectedCoinsIntoCoinReturn()
        {
            machine.InsertCoin(Coin.Nickle);
            Assert.AreEqual(machine.CoinReturn, 0);

            try
            {
                machine.InsertCoin(Coin.Penny);
            }
            catch (VendingMachine.VendingMachine.InvalidCoinException)
            {
                Assert.AreEqual(machine.CoinReturn, 1);

            }
        }
    }
}

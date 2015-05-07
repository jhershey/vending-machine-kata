using System;
using System.Linq;

namespace VendingMachine
{
    public enum Coin : int
    {
        Penny = 1,
        Nickle = 5,
        Dime = 10,
        Quarter = 25
    }

    public enum Product:int
    {
        Cola = 100,
        Chips = 50,
        Candy = 65
    }

    public class VendingMachine
    {

        public const String INSERT_COIN_DISPLAY = "INSERT COIN";
        public const String THANK_YOU_DISPLAY = "THANK YOU";

        public class InvalidCoinException : Exception { };

        private Coin[] validCoins = { Coin.Nickle, Coin.Dime, Coin.Quarter };

        public int CurrentAmount { get;set; }
        public String Display { get; set; }
        public int CoinReturn { get; set; }
        // public Product ?Dispenser { get; set; }

        public VendingMachine()
        {
            Display = INSERT_COIN_DISPLAY;
        }

        public int InsertCoin(Coin coin)
        {
            if (validCoins.Contains(coin))
            {
                CurrentAmount += (int)coin;
                Display = CurrentAmount.ToString();
                return CurrentAmount;
            }

            CoinReturn += (int)coin;
            throw new InvalidCoinException();
        }

        public Product? SelectProduct(Product product)
        {
            if ((int)CurrentAmount >= (int)product)
            {
                Display = THANK_YOU_DISPLAY;
                CoinReturn = CurrentAmount - (int)product;
                CurrentAmount = 0;
                return product;
            }
            return null;
        }
    }   
}

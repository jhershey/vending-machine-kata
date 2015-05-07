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

        public class InvalidCoinException : Exception { };

        private Coin[] validCoins = { Coin.Nickle, Coin.Dime, Coin.Quarter };

        public int CurrentAmount { get;set; }
        public String Display {
            get
            {
                if (CurrentAmount == 0)
                {
                    return INSERT_COIN_DISPLAY;
                }
                return CurrentAmount.ToString();
            }
        }
        public int CoinReturn { get; set; }
        public Product Dispenser { get; set; }


        public int InsertCoin(Coin coin)
        {
            if (validCoins.Contains(coin))
            {
                CurrentAmount += (int)coin;
                return CurrentAmount;
            }

            CoinReturn += (int)coin;
            throw new InvalidCoinException();
        }

        public void SelectProduct(Product product)
        {
            
        }
    }   
}

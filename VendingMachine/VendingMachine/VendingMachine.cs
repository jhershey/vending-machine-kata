﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public enum Coin:int
    {
        Penny = 1,
        Nickle = 5,
        Dime = 10,
        Quarter = 25
    }

    public class VendingMachine
    {
        private Coin[] validCoins = { Coin.Nickle, Coin.Dime, Coin.Quarter };

        public int CurrentAmount { get;set; }
        public String Display { get; set; }

         
        public Boolean InsertCoin(Coin coin)
        {
            if (validCoins.Contains(coin))
            {
                CurrentAmount += (int)coin;
                Display = CurrentAmount.ToString();
                return true;
            }

            return false;
        }
    }   
}

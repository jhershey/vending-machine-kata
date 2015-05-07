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
        private enum MachineState
        {
            Start,
            AcceptingCoins,
            ProductDispensed
        };
        private MachineState currentState;

        public static class DisplayMessages
        {
            public const String INSERT_COIN = "INSERT COIN";
            public const String THANK_YOU = "THANK YOU";
            public const String PRICE = "PRICE";
        };

        public class InvalidCoinException : Exception {
            public InvalidCoinException(string message, string v) : base(message) { }
        };

        public class InvalidStateChangeException : Exception {
            public InvalidStateChangeException(string message) : base(message) { }
        };

        private Coin[] validCoins = { Coin.Nickle, Coin.Dime, Coin.Quarter };

        public int CurrentAmount { get;set; }

        public String Display {
            get {
                switch (currentState)
                {
                    case MachineState.Start:
                        return DisplayMessages.INSERT_COIN;

                    case MachineState.AcceptingCoins:
                        return CurrentAmount.ToString();

                    case MachineState.ProductDispensed:
                        SetState(MachineState.Start);
                        return DisplayMessages.THANK_YOU;

                    default:
                        throw new Exception("Trying to get Display with unknown machine state");
                }
            }
        }
        public int CoinReturn { get; set; }

        public VendingMachine()
        {
            currentState = MachineState.Start;
            CurrentAmount = 0;
        }

        public int InsertCoin(Coin coin)
        {
            if (validCoins.Contains(coin))
            {
                SetState(MachineState.AcceptingCoins);
                CurrentAmount += (int)coin;
                return CurrentAmount;
            }

            CoinReturn += (int)coin;
            throw new InvalidCoinException("Tried to Insert coin of type {0}", coin.GetType().ToString());
        }

        public Product? SelectProduct(Product product)
        {
            if ((int)CurrentAmount >= (int)product)
            {
                SetState(MachineState.ProductDispensed);
                CoinReturn = CurrentAmount - (int)product;
                CurrentAmount = 0;
                return product;
            }
            return null;
        }

        public static String CreatePriceMessage(Product product)
        {
            return DisplayMessages.PRICE + ": " + ((int)product).ToString();
        }

        private void SetState(MachineState newState)
        {
            switch (currentState)
            {
                case MachineState.Start:
                    switch (newState)
                    {
                        case MachineState.ProductDispensed:
                            throw new InvalidStateChangeException("Tried to goto ProductDispensed from Start state");

                        default:
                            currentState = newState;
                            break;
                    }
                    break;

                case MachineState.AcceptingCoins:
                    switch (newState)
                    {
                        case MachineState.Start:
                            throw new InvalidStateChangeException("Tried to goto Start from Accepting Coins state");

                        default:
                            currentState = newState;
                            break;
                    }
                    break;

                case MachineState.ProductDispensed:
                    switch (newState)
                    {
                        case MachineState.AcceptingCoins:
                            throw new InvalidStateChangeException("Tried to goto AcceptingCoins from ProductDispensed state");

                        default:
                            currentState = newState;
                            break;
                    }
                    break;
            }
        }
    }   
}

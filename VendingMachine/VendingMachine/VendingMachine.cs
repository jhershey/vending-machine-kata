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
            ProductDispensed,
            ProductPriceCheck
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

        public int CurrentAmount { get; set; }
        private Product? selectedProduct { get;set; }

        public String GetDisplay()
        {
            switch (currentState)
            {
                case MachineState.Start:
                    return DisplayMessages.INSERT_COIN;

                case MachineState.AcceptingCoins:
                    return CurrentAmount.ToString();

                case MachineState.ProductDispensed:
                    SetState(MachineState.Start);
                    return DisplayMessages.THANK_YOU;

                case MachineState.ProductPriceCheck:
                    if (CurrentAmount == 0)
                    {
                        SetState(MachineState.Start);
                    }
                    else
                    {
                        SetState(MachineState.AcceptingCoins);
                    }
                    return CreatePriceCheckMessage(selectedProduct);


                default:
                    throw new Exception("Trying to get Display with unknown machine state");
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
            selectedProduct = product;
            if ((int)CurrentAmount >= (int)product)
            {
                SetState(MachineState.ProductDispensed);
                //CoinReturn = CurrentAmount - (int)product;
                CurrentAmount = 0;
                return product;
            }
            SetState(MachineState.ProductPriceCheck);
            return null;
        }

        public static String CreatePriceCheckMessage(Product? product)
        {
            return product.HasValue ? DisplayMessages.PRICE + ": " + ((int)product).ToString() : "";
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

                case MachineState.ProductPriceCheck:
                    switch (newState)
                    {
                        case MachineState.Start:
                        case MachineState.AcceptingCoins:
   
                            currentState = newState;
                            break;

                        default:
                            throw new InvalidStateChangeException(String.Format("Tried to goto invalid state {0} from ProductPriceCheck state", newState));
                    }
                    break;
            }
        }
    }   
}

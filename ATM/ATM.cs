using ATM.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ATM.Methods;

namespace ATM
{

    internal class ATM
    {
        private List<AccountHolders> AccountHolders;
        private AccountHolders selectedAccount;

        public void InitializeData()
        {
            AccountHolders = new List<AccountHolders>
            {
                new AccountHolders { Id = 1, FullName = "Sahil Rawat", AccountNumber = 817809, CardNumber = 091824, CardPin = 123456, AccountBalance = 510000.00m, IsLocked = false },
                new AccountHolders { Id = 2, FullName = "Amrit Rawat", AccountNumber = 986830, CardNumber = 302308, CardPin = 456789, AccountBalance = 410000.00m, IsLocked = false }
            };
        }

        public void CheckUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();

                foreach (AccountHolders account in AccountHolders)
                {
                    selectedAccount = account;
                    if (inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        //selectedAccount.TotalLogin++;

                        if (inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;

                            if (selectedAccount.IsLocked)
                            {
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                //selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if (isCorrectLogin == false)
                    {
                        Utility.PrintMessage("\nInvalid card number or PIN.", false);
                        //selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }
                    }
                    Console.Clear();
                }
            }
        }

        public void Run()
        {
            AppScreen.Welcome();
            CheckUserCardNumAndPassword();
            AppScreen.WelcomeCustomer(selectedAccount.FullName);
            while (true)
            {
                AppScreen.DisplayAppMenu();
                ProcessMenuoption();
            }
        }

        public void CheckBalance()
        {
            Utility.PrintMessage($"Your account balance is: {Utility.FormatAmount(selectedAccount.AccountBalance)}");
        }

        private void ProcessMenuoption()
        {
            switch (Validator.Convert<int>("an option:"))
            {
                case (int)AppMenu.CheckBalance:
                    CheckBalance();
                    break;
                default: 
                    Utility.PrintMessage("Invalid Option.", false);
                    break;
            }
        }
    }

    public enum AppMenu
    {
        CheckBalance = 1,
        PlaceDeposit,
        MakeWithdrawal,
        InternalTransfer,
        ViewTransaction,
        Logout
    }
}

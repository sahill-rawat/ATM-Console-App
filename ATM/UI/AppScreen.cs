using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Methods;

namespace ATM.UI
{
    public class AppScreen
    {
        internal const string cur = "N ";
        internal static void Welcome()
        {
            Console.Clear();
            Console.Title = "Sahil's ATM";
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n-----------------Welcome-----------------\n\n");
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("PS: Actual ATM machine will accept and validate a physical ATM card");
            Utility.PressEnterToContinue();
        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.CardNumber = Validator.Convert<long>("your card number.");
            tempUserAccount.CardPin = Convert.ToInt32(Utility.GetSecretInput("Enter your card PIN"));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nVerifying...");
            Utility.PrintDotAnimation();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is locked. Please go to the nearest branch" +
                " to unlock your account. Thank you.", true);
            Environment.Exit(1);
        }

        internal static void WelcomeCustomer(string fullName)
        {
            Console.WriteLine($"Welcome, {fullName}");
            Utility.PressEnterToContinue();
        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------Menu-------------");
            Console.WriteLine(":                           :");
            Console.WriteLine("1. Check Balance            :");
            Console.WriteLine("2. Cash Deposit             :");
            Console.WriteLine("3. Withdraw                 :");
            Console.WriteLine("4. Transfer                 :");
            Console.WriteLine("5. Transaction              :");
            Console.WriteLine("6. Logout                   :");

        }

        internal static void LogoutProgress()
        {
            Console.WriteLine("Thank you!");
            Utility.PrintDotAnimation();
            Console.Clear();
        }

        internal static int SelectAmount()
        {
            Console.WriteLine("");
            Console.WriteLine(":1.{0}500      5.{0}10,000", cur);
            Console.WriteLine(":2.{0}1000     6.{0}15,000", cur);
            Console.WriteLine(":3.{0}2000     7.{0}20,000", cur);
            Console.WriteLine(":4.{0}5000     8.{0}40,000", cur);
            Console.WriteLine(":0.Other");
            Console.WriteLine("");

            int selectedAmount = Validator.Convert<int>("option:");
            switch (selectedAmount)
            {
                case 1:
                    return 500;
                case 2:
                    return 1000;
                case 3:
                    return 2000;
                case 4:
                    return 5000;
                case 5: 
                    return 10000;
                case 6:
                    return 15000;
                case 7:
                    return 20000;
                case 8:
                    return 40000;
                case 0:
                    return 0;
                default:
                    Utility.PrintMessage("Invalid input. Try again.", false);
                    return -1;
            }
        }
        internal InternalTransfer InternalTransferForm()
        {
            var internalTransfer = new InternalTransfer();
            internalTransfer.ReciepeintBankAccountNumber = Validator.Convert<long>("recipient's account number:");
            internalTransfer.TransferAmount = Validator.Convert<decimal>($"amount {cur}");
            internalTransfer.RecipientBankAccountName = Utility.GetUserInput("recipient's name:");
            return internalTransfer;
        }
    }
}

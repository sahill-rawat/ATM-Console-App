using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.UI
{
    public class LoginPage
    {
        internal const string cur = "N ";
        internal static void Welcome()
        {
            Console.Clear();
            Console.Title = "My ATM App";
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n-----------------Welcome to My ATM App-----------------\n\n");
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: Actual ATM machine will accept and validate" +
                " a physical ATM card, read the card number and validate it.");
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
            Console.WriteLine("\nChecking card number and PIN...");
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
            Console.WriteLine($"Welcome back, {fullName}");
            Utility.PressEnterToContinue();
        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("-------My ATM App Menu-------");
            Console.WriteLine(":                           :");
            Console.WriteLine("1. Account Balance          :");
            Console.WriteLine("2. Cash Deposit             :");
            Console.WriteLine("3. Withdrawal               :");
            Console.WriteLine("4. Transfer                 :");
            Console.WriteLine("5. Transactions             :");
            Console.WriteLine("6. Logout                   :");
        }

        internal static void LogoutProgress()
        {
            Console.WriteLine("Thank you for using My ATM App.");
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
    /* public class LoginPage
    {
        public string CurrentUser;
        Dictionary<string, string> Credentials = new Dictionary<string, string>();
        Dictionary<string, string> UsersName = new Dictionary<string, string>();
        public LoginPage()
        {
            Credentials["sahill_rawat"] = "sahil@2002";
            UsersName["sahill_rawat"] = "Sahil";
            Credentials["rawat22"] = "0047";
            UsersName["rawat22"] = "Amrit";
        }
        public bool Login()
        {
            string UserName;
            do
            {
                Console.Clear();
                Console.Write("Enter your username: ");
                UserName = Console.ReadLine();
            }
            while (!Credentials.ContainsKey(UserName));

            int Attempt = 4;
            while (Attempt > 0)
            {
                Console.Write("Enter your 4 digit pin: ");
                string Pin = Console.ReadLine();
                if (Credentials[UserName] == Pin)
                {
                    CurrentUser = UsersName[UserName];
                    return true;
                }
            }
            return false;
        }
    } */
}

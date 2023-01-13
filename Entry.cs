using System;

public class Entry
{
    static void Main(string[] args)
    {

        ATMApp atm = new ATM();
        atm.InitializeData();
        atm.Run();

    }
}

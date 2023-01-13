namespace ATM
{
    internal class AccountHolders
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int AccountNumber { get; set; }
        public int CardNumber { get; set; }
        public int CardPin { get; set; }
        public decimal AccountBalance { get; set; }
        public bool IsLocked { get; set; }
    }
}
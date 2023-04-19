namespace PicPayLite.Domain.ValueObjects
{
    public class Balance 
    {
        public string Currency { get; set; }
        public float Amount { get; set; }

        public Balance(string currency, float amount)
        {
            Currency = currency;
            Amount = amount;
        }
    }
}
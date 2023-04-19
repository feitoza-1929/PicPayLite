namespace PicPayLite.Domain.ValueObjects
{
    public class Recipient
    {
        public Document Document { get; private set; }
        public int AccountNumber { get; private set; }
        public string Name { get; private set; }
    }
}
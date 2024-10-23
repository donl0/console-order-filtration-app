namespace Domain.Exceptions
{
    internal class FutureTimeException : DomainException
    {
        public FutureTimeException(string time)
 : base($"Delivery time: {time} can not be in the past.")
        {
        }
    }
}

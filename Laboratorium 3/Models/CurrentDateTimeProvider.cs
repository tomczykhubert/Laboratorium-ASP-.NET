namespace Laboratorium_3.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime dateNow()
        {
            return DateTime.Now;
        }
    }
}

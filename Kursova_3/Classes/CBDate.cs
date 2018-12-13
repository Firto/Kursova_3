using System;

namespace SweetsFactory.Classes.CBirthdayDate
{
    public class BDateException : Exception
    {
        public BDateException(string message) : base(message) { }
    }
    public struct BDate
    {
        DateTime bdate;

        public void SetDate(int year, byte month, byte day)
        {
            bdate = new DateTime(year, month, day);
        }

        public BDate(int year, byte month, byte day)
        {
            bdate = new DateTime(year, month, day);
        }
    }
}

using System;

namespace HotelComplexChanged2._2
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Duty GetDuty { get; set; }
        public DateTime Birthday { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int PassportData { get; set; }
    }
}
using System;

namespace HotelComplexChanged2._2
{
    public class Reserv
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string PassportData { get; set; }
        public Room GetRoom { get; set; }
        public DateTime TimeEntry { get; set; }
        public DateTime TimeExit { get; set; }
    }
}
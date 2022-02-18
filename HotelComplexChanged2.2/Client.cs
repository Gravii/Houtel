using System;

namespace HotelComplexChanged2._2
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string PassportData { get; set; }
        public Room NumberRoom { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DataFinish { get; set; }
    }
}
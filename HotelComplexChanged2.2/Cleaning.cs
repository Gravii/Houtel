using System;

namespace HotelComplexChanged2._2
{
    public class Cleaning
    {
        public int Id { get; set; }
        public Staff Name { get; set; }
        public Room GetRoom { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
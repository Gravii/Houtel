using System;

namespace HotelComplexChanged2._2
{
    public class Schedule
    {
        public int Id { get; set; }
        public Staff Name { get; set; }
        public Duty GetDuty { get; set; }
        public DateTime Date { get; set; }
    }
}
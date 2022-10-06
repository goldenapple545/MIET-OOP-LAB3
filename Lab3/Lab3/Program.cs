using System;

namespace Lab3
{
    public class Aeroflot
    {
        public enum FlightType
        {
            High, Medium, Low
        }
        public string destination;
        private int flightNumber;
        public FlightType flightType;
        private string flightTime;
        private int weekday;

        public Aeroflot (string d, int n, string time, int w)
        {
            destination = d;
            if (flightNumber < 0)
                throw new Exception("Некорректный номер полета");
            flightNumber = n;
            flightTime = time;
            if (w > 0 && w < 8)
                throw new Exception("Некорректный день недели");
            weekday = w;
        }

        public void setFlightType(FlightType type)
        {
            flightType = type;
        }

        public int getFlightNumber()
        {
            return flightNumber;
        }

        public string getFlightTime()
        {
            return flightTime;
        }

        public int getWeekday()
        {
            return weekday;
        }

        public string info()
        {
            return String.Format($"Пункт назначения: {destination}, Номер рейса: {getFlightNumber()}, Время вылета: {getFlightTime()}, Дни недели: {getWeekday()}");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            Aeroflot[] masFlight = new Aeroflot[3];
            masFlight[0] = new Aeroflot("Москва", 2, "12:31", 3);
            masFlight[1] = new Aeroflot("Санкт-Петербург", 3, "13:35", 1);
            masFlight[2] = new Aeroflot("Лондон", 3, "11:31", 5);
        }
    }
}

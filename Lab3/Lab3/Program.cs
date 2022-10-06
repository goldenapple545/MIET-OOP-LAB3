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
        private int flightTime;
        private int weekday;

        public Aeroflot (string d, int n, int time, int w)
        {
            destination = d;
            if (n < 0)
                throw new Exception("Некорректный номер полета");
            flightNumber = n;
            if (time < 0)
                throw new Exception("Некорректный время");
            flightTime = time;
            if (0 > w || w > 8)
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

        public int getFlightTime()
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
        static void listDestination(Aeroflot[] mas, string destination)
        {
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].destination == destination)
                {
                    Console.WriteLine(mas[i].info());
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("Список пуст");
        }

        static void listWeekday(Aeroflot[] mas, int weekday)
        {
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].getWeekday() == weekday)
                {
                    Console.WriteLine(mas[i].info());
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("Список пуст");
        }
        static void listWeekdayTime(Aeroflot[] mas, int weekday, int time)
        {
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].getWeekday() == weekday && mas[i].getFlightTime() > time)
                {
                    Console.WriteLine(mas[i].info());
                    count++;
                }   
            }
            if (count == 0)
                Console.WriteLine("Список пуст");
        }

        static void Main(string[] args)
        {
            Aeroflot[] masFlight = new Aeroflot[3];
            masFlight[0] = new Aeroflot("Москва", 2, 123, 3);
            masFlight[1] = new Aeroflot("Санкт-Петербург", 3, 35, 1);
            masFlight[2] = new Aeroflot("Лондон", 3, 201, 5);

            Console.WriteLine("список рейсов для заданного пункта назначения");
            listDestination(masFlight, "Лондон");
            Console.WriteLine("список рейсов для заданного дня недели");
            listWeekday(masFlight, 1);
            Console.WriteLine("список рейсов для заданного дня недели, время вылета для которых больше заданного");
            listWeekdayTime(masFlight, 3, 70);
        }
    }
}

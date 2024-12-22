using System;
using System.Collections.Generic;

namespace AirlineSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var airline = new Airline();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Меню Авиакомпании:");
                Console.WriteLine("1. Показать список рейсов");
                Console.WriteLine("2. Добавить рейс");
                Console.WriteLine("3. Формировать летную бригаду");
                Console.WriteLine("4. Выйти");
                Console.Write("Введите номер команды: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        airline.ShowFlights();
                        break;
                    case "2":
                        airline.AddFlight();
                        break;
                    case "3":
                        airline.FormCrew();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                        break;
                }
            }
        }
    }

    class Flight
    {
        public string Destination { get; set; }
        public string Crew { get; set; }
    }

    class Airline
    {
        private List<Flight> flights = new List<Flight>();

        public void ShowFlights()
        {
            if (flights.Count == 0)
            {
                Console.WriteLine("Нет доступных рейсов.");
            }
            else
            {
                Console.WriteLine("Список рейсов:");
                foreach (var flight in flights)
                {
                    Console.WriteLine($"Рейс в {flight.Destination}, Бригада: {flight.Crew}");
                }
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
            Console.ReadKey();
        }

        public void AddFlight()
        {
            Console.Write("Введите пункт назначения: ");
            string destination = Console.ReadLine();
            flights.Add(new Flight { Destination = destination, Crew = "Не сформирована" });
            Console.WriteLine("Рейс добавлен. Нажмите любую клавишу, чтобы вернуться в меню.");
            Console.ReadKey();
        }

        public void FormCrew()
        {
            if (flights.Count == 0)
            {
                Console.WriteLine("Нет доступных рейсов для формирования бригады.");
            }
            else
            {
                Console.WriteLine("Формирование летной бригады");
                Console.Write("Введите номер рейса: ");
                int flightNumber;
                if (int.TryParse(Console.ReadLine(), out flightNumber) && flightNumber > 0 && flightNumber <= flights.Count)
                {
                    Console.Write("Введите состав бригады (пилоты, штурман, радист, стюардессы): ");
                    flights[flightNumber - 1].Crew = Console.ReadLine();
                    Console.WriteLine("Бригада сформирована. Нажмите любую клавишу, чтобы вернуться в меню.");
                }
                else
                {
                    Console.WriteLine("Неверный номер рейса. Нажмите любую клавишу, чтобы вернуться в меню.");
                }
            }
            Console.ReadKey();
        }
    }
}
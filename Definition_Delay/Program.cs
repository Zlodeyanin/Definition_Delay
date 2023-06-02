using System;
using System.Collections.Generic;
using System.Linq;

namespace Definition_Delay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auditor auditor = new Auditor();
            auditor.Work();
        }
    }

    class Preserve
    {
        public Preserve(Random random, string name)
        {
            int minYearProduction = 2015;
            int maxYearProduction = 2023;
            int quantityYears = 5;
            Name = name;
            YearProduction = random.Next(minYearProduction, maxYearProduction);
            ExpirationDate = quantityYears;
        }

        public string Name { get; private set; }
        public int YearProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} . Дата производства - {YearProduction} .");
        }
    }

    class Auditor
    {
        private List<Preserve> _preserves = new List<Preserve>();

        public Auditor()
        {
            Random random = new Random();
            CreatePreserves(random);
        }

        public void Work()
        {
            const string CommandShowAllPreserves = "1";
            const string CommandDetermineDelay = "2";
            const string CommandExit = "3";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Добро пожаловать в программу определения просрочки, аудитор!");
                Console.WriteLine($"Введите {CommandShowAllPreserves}, чтобы показать все консервы в наличии.");
                Console.WriteLine($"Введите {CommandDetermineDelay}, чтобы определить просроченные консервы.");
                Console.WriteLine($"Введите {CommandExit}, чтобы завершить работу.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowAllPreserves:
                        ShowAllPreserve();
                        break;

                    case CommandDetermineDelay:
                        DetermineDelay();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreatePreserves(Random random)
        {
            _preserves.Add(new Preserve(random, "говядина 1 сорт"));
            _preserves.Add(new Preserve(random, "говядина 2 сорт"));
            _preserves.Add(new Preserve(random, "свинина 1 сорт"));
            _preserves.Add(new Preserve(random, "свинина 2 сорт"));
            _preserves.Add(new Preserve(random, "конина 1 сорт"));
            _preserves.Add(new Preserve(random, "конина 2 сорт"));
            _preserves.Add(new Preserve(random, "абрикосы кусковые"));
            _preserves.Add(new Preserve(random, "ананасы кольца"));
            _preserves.Add(new Preserve(random, "ананасы кусковые"));
            _preserves.Add(new Preserve(random, "бычки в томате"));
            _preserves.Add(new Preserve(random, "фасоль белая"));
        }

        private void DetermineDelay()
        {
            int currentYear = 2023;
            var delayPreserves = _preserves.Where(preserve => currentYear - preserve.YearProduction > preserve.ExpirationDate).ToList();

            if (delayPreserves.Count > 0)
            {
                foreach (Preserve delay in delayPreserves)
                {
                    delay.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Просроченных консервов среди взятых на проверку не найдено!");
            }
        }

        private void ShowAllPreserve()
        {
            foreach (Preserve preserve in _preserves)
            {
                preserve.ShowInfo();
            }
        }
    }
}

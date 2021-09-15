using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentDataBase
{
    public class Worker
    {
        /// <summary>
        /// Именя сотрудников
        /// </summary>
        public static List<string> WorkersRandomNames = new List<string> { "Вася", "Женя", "Катя", "Петя", "Саша" };
        Random random = new Random();
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// Id департамента
        /// </summary>
        public int DepartamentId { get; set; }
        /// <summary>
        /// должность сотрудника
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Id работника
        /// </summary>
        public int Id { get; }

        private static int TempId = 0;
        /// <summary>
        /// Конструктор создания сотрудника
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="salary">Зарплата сотрудника</param>
        /// <param name="depId">Id департамента</param>
        public Worker(string name, int age, int depId)
        {
            this.Name = name;
            this.Age = age;
            this.DepartamentId = depId;
            this.Position = "";
            this.Id = TempId;
            TempId++;
        }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Worker()
        {
            this.Name = WorkersRandomNames[random.Next(0, 5)];
            this.Age = random.Next(18, 50);
            this.Salary = Convert.ToString(random.Next(1, 50) * 1000);
            this.DepartamentId = 0;
            this.Id = TempId;
            TempId++;
        }
        /// <summary>
        /// Конструктор создания сотрудника по департаменту
        /// </summary>
        /// <param name="DepId">Id департамента</param>
        public Worker(int DepId)
        {
            this.Name = WorkersRandomNames[random.Next(0, 5)];
            this.Age = random.Next(18, 50);
            this.Salary = Convert.ToString(random.Next(1, 50) * 1000);
            this.DepartamentId = DepId;
            this.Id = TempId;
            TempId++;
        }
        #region Сортировка
        class SortWorkersByName : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                return String.Compare(x.Name, y.Name);
            }
        }
        class SortWorkersBySalary : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                if (x.Salary == y.Salary) return 0;
                else if (Int32.Parse(x.Salary) > Int32.Parse(y.Salary)) return 1;
                else return -1;
            }
        }
        class SortWorkersByAge : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                if (x.Age == y.Age) return 0;
                else if (x.Age > y.Age) return 1;
                else return -1;
            }
        }
        class SortWorkersByPosition : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                return String.Compare(x.Position, y.Position);
            }
        }
        public enum SortParametr
        {
            Name,
            Salary,
            Age,
            Position
        }
        public static IComparer<Worker> SortedBy(SortParametr parametr)
        {
            switch (parametr)
            {
                case SortParametr.Name: return new SortWorkersByName();
                case SortParametr.Salary: return new SortWorkersBySalary();
                case SortParametr.Age: return new SortWorkersByAge();
                case SortParametr.Position: return new SortWorkersByPosition();
                default: return null;
            }
    }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentDataBase
{
    public class Amployed : Worker
    {
        #region Поля
        /// <summary>
        /// Время, отработанное в месяц
        /// </summary>
        public int Hours { get; set; }
        /// <summary>
        /// Почасовая ставка
        /// </summary>
        public int Cost { get; set; }
        #endregion
        #region Конструкторы
        public Amployed()
            : base()
        {
            Random random = new Random();
            this.Hours = random.Next(100, 200);
            this.Cost = random.Next(12, 250);
            this.Salary = Convert.ToString(Hours * Cost);
            this.Doljnost = "Офисный работник";
        }
        public Amployed(int Id)
            : base()
        {
            Random random = new Random();
            this.Hours = random.Next(100, 200);
            this.Cost = random.Next(12, 500);
            this.Salary = Convert.ToString(Hours * Cost);
            this.Doljnost = "Офисный работник";
            this.DepartamentId = Id;
        }
        public Amployed(string name, int age, int depId)
            : base()
        {
            Random random = new Random();
            this.Hours = random.Next(100, 200);
            this.Cost = random.Next(12, 500);
            this.Salary = Convert.ToString(Hours * Cost);
            this.Name = name;
            this.Age = age;
            this.Doljnost = "Офисный работник";
            this.DepartamentId = depId;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentDataBase
{
    public class Employer : Worker
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
        public Employer()
            : base()
        {
            Random random = new Random();
            this.Hours = random.Next(100, 200);
            this.Cost = random.Next(12, 250);
            this.Salary = Convert.ToString(Hours * Cost);
            this.Position = "Офисный работник";
        }
        public Employer(int Id)
            : this()
        {
            this.DepartamentId = Id;
        }
        public Employer(string name, int age, int depId)
            : this()
        {
            this.Name = name;
            this.Age = age;
            this.DepartamentId = depId;
        }
        #endregion
    }
}

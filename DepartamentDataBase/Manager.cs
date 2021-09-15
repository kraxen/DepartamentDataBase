using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentDataBase
{
    public class Manager : Worker
    {
        /// <summary>
        /// Департамент, за который ответственный менеджер
        /// </summary>
        public List<Worker> workers;
        private IEnumerable<Worker> enumerable;

        public Manager(List<Worker> workers,int Id)
            : base()
        {
            this.workers = workers;
            if (workers.Count == 0)
            {
                this.Salary = "0";
            }
            else
            {
                this.Salary = Convert.ToString(ManagerSalary(workers));
            }
            this.DepartamentId = Id;
        }
        public Manager()
            :base()
        {
            this.workers = new List<Worker> { };
            this.Salary = "0";
            this.Position = "Менеджер";
            this.DepartamentId = 0;
        }

        public Manager(IEnumerable<Worker> enumerable, int Id)
            : this()
        {
            this.enumerable = enumerable;
            this.workers = enumerable.ToList();
            if (workers.Count == 0)
            {
                this.Salary = "0";
            }
            else
            {
                this.Salary = Convert.ToString(ManagerSalary(workers));
            }
            //this.Position = "Менеджер";
            this.DepartamentId = Id;
        }

        #region Методы
        /// <summary>
        /// Просчет процента от зарплаты одного сотрудника
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        static int Prosent(Worker worker) => Convert.ToInt32(Convert.ToInt32(worker.Salary) * 0.15);
        /// <summary>
        /// Подсчет зарплаты менеджера
        /// </summary>
        /// <param name="workers">Сотрудники в подчинении менеджера</param>
        /// <returns></returns>
        public static int ManagerSalary(List<Worker> workers)
        {
            int temp = 0;
            foreach (Worker e in workers)
            {
                temp += Prosent(e);
            }
            if (temp < 1300)
            {
                temp = 1300;
            }
            return temp;
        }
        #endregion
    }
}

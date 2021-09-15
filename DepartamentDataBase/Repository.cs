using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentDataBase
{
    public class Repository
    {
        static Random random = new Random();

        public List<Worker> WorkersData { get; set; }
        public List<Departament> DepartamentsData { get; set; }
        public List<Repository> Repositories { get; set; }
        public string Name { get; set; }
        public int RepositoryID { get; set; }
        /// <summary>
        /// Создание репозитория со случайным количеством сотрудников по количеству департаментов и сотрудников
        /// </summary>
        /// <param name="CountDepartaments">Количество департаментов</param>
        /// <param name="CountWorkers">Количество сотрудников</param>
        private Repository(int CountDepartaments, int CountWorkers)
        {
            WorkersData = new List<Worker>();
            DepartamentsData = new List<Departament>();
            ///заполнение департаментов
            for(int i=0;i < CountDepartaments; i++)
            {
                DepartamentsData.Add(new Departament($"Департамент {i}", i));
            }
            ///Заполнение интернами 1/3
            for (int i = 0; i < (CountWorkers - CountWorkers / 10 * 1) / 3*1; i++)
            {
                WorkersData.Add(new Intern(
                    Worker.WorkersRandomNames[random.Next(0, 5)],
                    random.Next(18, 50),
                    random.Next(CountDepartaments)
                    ));
            }
            ///Заполнение рабочими 2/3
            for (int i = 0; i < (CountWorkers - CountWorkers/10*1) / 3 * 2; i++)
            {
                WorkersData.Add(new Employer(
                    Worker.WorkersRandomNames[random.Next(0, 5)],
                    random.Next(18, 50),
                    random.Next(CountDepartaments)
                    ));
            }
            for (int i=0; i < CountDepartaments; i++)
            {
                WorkersData.Add(new Manager(WorkersData.Where(e => e.DepartamentId == i) , i));
            }
        }
        public Repository()
        {
        }
        private Repository(int RepositoryCount, int CountDepartaments, int CountWorkers)
        {
            Repositories = new List<Repository>();
            WorkersData = new List<Worker>();
            DepartamentsData = new List<Departament>();
            for (int i = 0; i < RepositoryCount; i++)
            {
                Repositories.Add(new Repository(CountDepartaments, CountWorkers));
                Repositories[i].Name = $"Репозиторий {i}";
                Repositories[i].RepositoryID = i;
            }
        }
        public static Repository CreateRepository(int CountDepartaments, int CountWorkers)
        {
            return new Repository(CountDepartaments, CountWorkers);
        }
        public static Repository CreateRepository(int RepositoryCount,int CountDepartaments, int CountWorkers)
        {
            return new Repository(RepositoryCount, CountDepartaments, CountWorkers);
        }
        public override string ToString()
        {
            return $"{Name,15}";
        }
    }
}

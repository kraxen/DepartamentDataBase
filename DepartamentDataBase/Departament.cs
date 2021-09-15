using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentDataBase
{
    /// <summary>
    /// Департамент сотрудников
    /// </summary>
    public class Departament
    {
        /// <summary>
        /// Название департамента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Id департамента
        /// </summary>
        public int DepartamentId { get; set; }

        /// <summary>
        /// Конструктор создания департамента
        /// </summary>
        /// <param name="Name">Имя департамента</param>
        /// <param name="Id">Id департамента</param>
        public Departament(string Name, int Id)
        {
            this.Name = Name;
            this.DepartamentId = Id;
        }
        public Departament()
        {
        }
        public override string ToString()
        {
            return $"{Name,15}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentDataBase
{
    public class Intern : Worker
    {
        public Intern()
            : base()
        {
            Random random = new Random();
            this.Salary = Convert.ToString(random.Next(3, 10) * 100);
            this.Position = "Интерн";
        }
        public Intern(int Id)
            : this()
        {
            Random random = new Random();
            this.Salary = Convert.ToString(random.Next(3, 10) * 100);
            this.Position = "Интерн";
            this.DepartamentId = Id;
        }
        public Intern(string name, int age, int Id)
            : this()
        {
            Random random = new Random();
            this.Salary = Convert.ToString(random.Next(3, 10) * 100);
            this.Position = "Интерн";
            this.DepartamentId = Id;
        }
    }
}

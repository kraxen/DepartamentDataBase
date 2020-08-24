using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Seriolization;

namespace DepartamentDataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Создание репозитория сотрудников
        Repository data = new Repository();
        //Временная переменная для хранения Id департамента
        int oldId = 0;
        public MainWindow()
        {
            InitializeComponent();
            data = Repository.CreateRepository(10, 50, 10000);
            cmRep.ItemsSource = data.Repositories;
        }
        /// <summary>
        /// Кнопка изменения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRef(object sender, RoutedEventArgs e)
        {
            try
            {
                // Изменение имени
                (cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(WorkerId.Text))).Name = workerName.Text;
                //Изменение возраста
                try
                {
                    (cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(WorkerId.Text))).Age = Int32.Parse(workerAge.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Некорректно введен возраст.");
                }
                //Изменение зарплаты
                (cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(WorkerId.Text))).Salary = workerSalary.Text;
                //Изменение Id департамента
                try
                {
                    (cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(WorkerId.Text))).DepartamentId = Int32.Parse(workerId.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Некорректно введен возраст.");
                }
                //Обновление данных
                cbDepartament.Items.Refresh();
                lvWorkers.Items.Refresh();
                ChangeManagerSalary();
            }
            catch { MessageBox.Show("Сотрудник не выбран"); }
        }
        private void cbDepartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                lvWorkers.ItemsSource = (cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId);
                oldId = (cbDepartament.SelectedItem as Departament).DepartamentId;
            }
            catch
            {
                lvWorkers.ItemsSource = new List<string> { };
            }
        }
        private void btnSerJson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbSerJson.Text.Contains(".json"))
                {
                    ToJSON.SerializeToJsonList(data, tbSerJson.Text);
                }
                else
                {
                    MessageBox.Show("Некорректное имя файла/Файл не найден");
                }
            }
            catch
            {
                MessageBox.Show("Некорректное имя файла/Файл не найден");
            }
        }

        private void btnDeSerJson_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                data = ToJSON.DeserializeToJson<Repository>(tbDeSerJson.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное имя файла/Файл не найден");
            }
            cmRep.ItemsSource = data.Repositories;
            lvWorkers.ItemsSource = new List<string> { };
        }

        private void cmRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbDepartament.ItemsSource = (cmRep.SelectedItem as Repository).DepartamentsData;
                try
                {
                    lvWorkers.ItemsSource = (cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId);
                }
                catch
                {
                    lvWorkers.ItemsSource = new List<string> { };
                }
            }
            catch
            {
                cbDepartament.ItemsSource = new List<string> { };
            } 
        }

        private void btnSortByName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort(new Worker.SortWorkersByName());
                lvWorkers.ItemsSource = (cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }

        private void btnSortByAge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort(new Worker.SortWorkersByAge());
                lvWorkers.ItemsSource = (cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }

        private void btnSortBySalary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort(new Worker.SortWorkersBySalary());
                lvWorkers.ItemsSource = (cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }

        private void btnSortByWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort(new Worker.SortWorkersByDoljnost());
                lvWorkers.ItemsSource = (cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }

        private void btnRemove(object sender, RoutedEventArgs e)
        {
            try
            {
                (cmRep.SelectedItem as Repository).WorkersData.Remove((cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(WorkerId.Text))));
                ChangeManagerSalary();
                lvWorkers.ItemsSource = (cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { MessageBox.Show("Сотрудник не выбран"); }

        }
        /// <summary>
        /// Изменение зарплаты менеджера
        /// </summary>
        void ChangeManagerSalary()
        {
            try
            {
                ///Изменение зарплаты менеджера нового департамента
                Manager tempManager = new Manager((cmRep.SelectedItem as Repository).WorkersData.Where(e => (e.DepartamentId == Int32.Parse(workerId.Text)) && (e.Doljnost != "Менеджер")), Int32.Parse(workerId.Text));
                (cmRep.SelectedItem as Repository).WorkersData.Find(e =>
                (e.Doljnost == "Менеджер")
                &&
                (e.DepartamentId == (cbDepartament.SelectedItem as Departament).DepartamentId)
                ).Salary = tempManager.Salary;
                //Изменение зарплаты менеджера старого департамента
                tempManager = new Manager((cmRep.SelectedItem as Repository).WorkersData.Where(e => (e.DepartamentId == oldId) && (e.Doljnost != "Менеджер")), oldId);
                (cmRep.SelectedItem as Repository).WorkersData.Find(e => (e.Doljnost == "Менеджер") && (e.DepartamentId == oldId)).Salary = tempManager.Salary;
            }
            catch { }
        }
    }
}

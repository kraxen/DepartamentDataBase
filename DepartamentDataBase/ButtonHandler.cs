using Seriolization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepartamentDataBase
{
    public static class ButtonHandler
    {
        //Создание репозитория сотрудников
        static Repository data = Repository.CreateRepository(10, 10, 1000);
        /// <summary>
        /// Получить репозиторий
        /// </summary>
        public static Repository Data { get { return data; } }
        //Временная переменная для хранения Id департамента
        private static int oldId = 0;
        /// <summary>
        /// Метод изменения данных по кнопке
        /// </summary>
        /// <param name="w"></param>
        public static void btnRef(MainWindow w)
        {
            try
            {
                // Изменение имени
                (w.cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(w.WorkerId.Text))).Name = w.workerName.Text;
                //Изменение возраста
                try
                {
                    (w.cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(w.WorkerId.Text))).Age = Int32.Parse(w.workerAge.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Некорректно введен возраст.");
                }
                //Изменение зарплаты
                (w.cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(w.WorkerId.Text))).Salary = w.workerSalary.Text;
                //Изменение Id департамента
                try
                {
                    (w.cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(w.WorkerId.Text))).DepartamentId = Int32.Parse(w.workerId.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Некорректно введен возраст.");
                }
                //Обновление данных
                ChangeManagerSalary(w);
                w.cbDepartament.Items.Refresh();
                w.lvWorkers.Items.Refresh();
            }
            catch { MessageBox.Show("Сотрудник не выбран"); }
        }
        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="w"></param>
        public static void btnRemove(MainWindow w)
        {
            try
            {
                (w.cmRep.SelectedItem as Repository).WorkersData.Remove((w.cmRep.SelectedItem as Repository).WorkersData.Find((e => e.Id == Int32.Parse(w.WorkerId.Text))));
                ChangeManagerSalary(w);
                w.lvWorkers.ItemsSource = (w.cmRep.SelectedItem as Repository).WorkersData.Where(e => e.DepartamentId == (w.cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { MessageBox.Show("Сотрудник не выбран"); }
        }
        /// <summary>
        /// Изменение значений ComboBox с департаментами
        /// </summary>
        /// <param name="w"></param>
        public static void cbDepartament_SelectionChanged(MainWindow w)
        {
            try
            {
                w.lvWorkers.ItemsSource = (w.cmRep?.SelectedItem as Repository)?.WorkersData.Where
                    (e => e.DepartamentId == (w.cbDepartament?.SelectedItem as Departament)?.DepartamentId);
                oldId = (w.cbDepartament.SelectedItem != null) ? (w.cbDepartament.SelectedItem as Departament).DepartamentId : 0;
            }
            catch
            {
                w.lvWorkers.ItemsSource = new List<string> { };
            }
        }
        /// <summary>
        /// Изменение значений ComboBox с репозиторями
        /// </summary>
        /// <param name="w"></param>
        public static void cmRep_SelectionChanged(MainWindow w)
        {
            try
            {
                w.cbDepartament.ItemsSource = (w.cmRep.SelectedItem as Repository)?.DepartamentsData;
                try
                {
                    w.lvWorkers.ItemsSource = (w.cmRep.SelectedItem as Repository)?.WorkersData.Where
                        (e => e.DepartamentId == (w.cbDepartament.SelectedItem as Departament)?.DepartamentId);
                }
                catch
                {
                    w.lvWorkers.ItemsSource = new List<string> { };
                }
            }
            catch
            {
                w.cbDepartament.ItemsSource = new List<string> { };
            }
        }
        /// <summary>
        /// Изменение зарплаты менеджера
        /// </summary>
        static void ChangeManagerSalary(MainWindow w)
        {
            try
            {
                ///Изменение зарплаты менеджера нового департамента
                Manager tempManager = new Manager((w.cmRep.SelectedItem as Repository).WorkersData.Where
                    (e => (e.DepartamentId == Int32.Parse(w.workerId.Text))
                    && (e.Position != "Менеджер")), Int32.Parse(w.workerId.Text));
                (w.cmRep.SelectedItem as Repository).WorkersData.Find(e =>
                (e.Position == "Менеджер")
                &&
                (e.DepartamentId == (w.cbDepartament.SelectedItem as Departament).DepartamentId)
                ).Salary = tempManager.Salary;
                //Изменение зарплаты менеджера старого департамента
                tempManager = new Manager((w.cmRep.SelectedItem as Repository).WorkersData.Where(e => (e.DepartamentId == oldId) && (e.Position != "Менеджер")), oldId);
                (w.cmRep.SelectedItem as Repository).WorkersData.Find(e => (e.Position == "Менеджер")
                                                                && (e.DepartamentId == oldId)).Salary = tempManager.Salary;
            }
            catch { }
        }
        /// <summary>
        /// Сериализация базы в JSON
        /// </summary>
        /// <param name="w"></param>
        public static void btnSerJson_Click(MainWindow w)
        {
            try
            {
                if (w.tbSerJson.Text.Contains(".json"))
                {
                    ToJSON.SerializeToJsonList(data, w.tbSerJson.Text);
                    MessageBox.Show($"Файл успешно сохранен в \"{w.tbSerJson.Text}\"");
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
        /// <summary>
        /// Создание базы из файла JSON
        /// </summary>
        /// <param name="w"></param>
        public static void btnDeSerJson_Click(MainWindow w)
        {
            try
            {
                data = ToJSON.DeserializeToJson<Repository>(w.tbDeSerJson.Text);
                MessageBox.Show($"Файл успешно импортирован из \"{w.tbDeSerJson.Text}\"");
            }
            catch
            {
                MessageBox.Show("Некорректное имя файла/Файл не найден");
            }
            w.cmRep.ItemsSource = data.Repositories;
            w.lvWorkers.ItemsSource = new List<string> { };
        }
        /// <summary>
        /// Сортировка базы сотрудников по имени
        /// </summary>
        /// <param name="w"></param>
        public static void btnSortByName_Click(MainWindow w)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (w.cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort
                    (Worker.SortedBy(Worker.SortParametr.Name));
                w.lvWorkers.ItemsSource = (w.cmRep.SelectedItem as Repository).WorkersData.Where
                    (e => e.DepartamentId == (w.cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }
        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        /// <param name="w"></param>
        public static void btnSortByAge_Click(MainWindow w)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (w.cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort
                    (Worker.SortedBy(Worker.SortParametr.Age));
                w.lvWorkers.ItemsSource = (w.cmRep.SelectedItem as Repository).WorkersData.Where
                    (e => e.DepartamentId == (w.cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }
        /// <summary>
        /// Сортировка по зарплате
        /// </summary>
        /// <param name="w"></param>
        public static void btnSortBySalary_Click(MainWindow w)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (w.cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort
                    (Worker.SortedBy(Worker.SortParametr.Salary));
                w.lvWorkers.ItemsSource = (w.cmRep.SelectedItem as Repository).WorkersData.Where
                    (e => e.DepartamentId == (w.cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }
        /// <summary>
        /// Сортировка по позиции/должности
        /// </summary>
        /// <param name="w"></param>
        public static void btnSortByPosition_Click(MainWindow w)
        {
            try
            {
                data.Repositories.Find(e => e.RepositoryID == (w.cmRep.SelectedItem as Repository).RepositoryID).WorkersData.Sort
                    (Worker.SortedBy(Worker.SortParametr.Position));
                w.lvWorkers.ItemsSource = (w.cmRep.SelectedItem as Repository).WorkersData.Where
                    (e => e.DepartamentId == (w.cbDepartament.SelectedItem as Departament).DepartamentId);
            }
            catch { }
        }
    }
}

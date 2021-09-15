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
        public MainWindow()
        {
            InitializeComponent();
            cmRep.ItemsSource = ButtonHandler.Data.Repositories;
        }
        /// <summary>
        /// Кнопка изменения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRef(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnRef(this);
        }
        private void cbDepartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonHandler.cbDepartament_SelectionChanged(this);
        }
        private void btnSerJson_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnSerJson_Click(this);
        }

        private void btnDeSerJson_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnDeSerJson_Click(this);
        }

        private void cmRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonHandler.cmRep_SelectionChanged(this);
        }

        private void btnSortByName_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnSortByName_Click(this);
        }

        private void btnSortByAge_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnSortByAge_Click(this);
        }

        private void btnSortBySalary_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnSortBySalary_Click(this);
        }

        private void btnSortByPosition_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnSortByPosition_Click(this);
        }

        private void btnRemove(object sender, RoutedEventArgs e)
        {
            ButtonHandler.btnRemove(this);
        }
    }
}

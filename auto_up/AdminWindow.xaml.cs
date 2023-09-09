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
using System.Windows.Shapes;

namespace auto_up
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
          
            InitializeComponent();
        }
        //переход на окно "Товары"
        private void btnParts_Click(object sender, RoutedEventArgs e)
        {
            NewPart newPart = new NewPart();
            newPart.Show();
            
        }

        //переход на окно "Фирмы"
        private void btnFirms_Click(object sender, RoutedEventArgs e)
        {
            NewFirm newFirm = new NewFirm();
            newFirm.Show();
            
        }
        //переход на окно "Контракты"
        private void btnContract_Click(object sender, RoutedEventArgs e)
        {
            Contracts contracts = new Contracts();
            contracts.Show();
            
        }

        //переход на окно "Статистика за день"
        private void btnStaticsDay_Click(object sender, RoutedEventArgs e)
        {
            StatisticDay statisticDay = new StatisticDay();
            statisticDay.Show();
            
        }


        //выход
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}

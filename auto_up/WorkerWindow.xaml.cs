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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
        {
            InitializeComponent();
            
        }
        //переход на окно товаров
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Show();
        }
        //переход на окно статистики за период
        private void btnStatics_Click(object sender, RoutedEventArgs e)
        {
            StatisticPeriod statisticPeriod = new StatisticPeriod();
            statisticPeriod.Show();
        }
        //переход на окно авторизации
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}

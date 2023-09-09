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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
           
        }
        //переход на окно авторизации
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        //переход на окно товаров
        private void btnParts_Click(object sender, RoutedEventArgs e)
        {
            BuyParts buyParts = new BuyParts();
            buyParts.Show();
        }
        //переход в окно корзины
        private void btnBasket_Click(object sender, RoutedEventArgs e)
        {
            Basket basket = new Basket();
            basket.Show();
        }
        //переход на окно заказов
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
        }
    }
}

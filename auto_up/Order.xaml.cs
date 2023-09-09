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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        //запрос на выборку данных таблицы "Заказ"
        string qrOrder = "select [ID_Order],[Number_Order],[Amount],[Status],[Date],[Basket_ID],[ID_Basket],[Count_Part_Basket],[User_ID],[ID_User],[Email_User],[Login_User],[Password_User],[Role_ID],[ID_Role],[Name_Role],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Damage],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Order] inner join [dbo].[Basket] on [Basket_ID] = [ID_Basket] inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role] inner join [dbo].[Part] on [Part_ID] = [ID_Part] inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";

        public Order()
        {
            InitializeComponent();
        }
        //переход на окно пользователя
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            Close();
        }


        private void dtgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //заполнение таблицы данными
        private void _orderFill()
        {
            //создание экземпляра класса для работы с БД
            DataSetClass dataSet = new DataSetClass();
            //запрос на выборку данных из таблицы "Заказ"
            dataSet.DataSetFill(qrOrder, "Order", DataSetClass.Function.select, null);
            dtgOrders.ItemsSource = DataSetClass.dataSet.Tables["Order"].DefaultView;
            dtgOrders.Columns[0].Visibility = Visibility.Hidden;
            dtgOrders.Columns[1].Header = "Номер заказа";
            dtgOrders.Columns[2].Header = "Сумма заказа";
            dtgOrders.Columns[3].Header = "Статус заказа";
            dtgOrders.Columns[4].Header = "Дата заказа";
            dtgOrders.Columns[5].Visibility = Visibility.Hidden;
            dtgOrders.Columns[6].Visibility = Visibility.Hidden;
            dtgOrders.Columns[7].Header = "Количество товара";
            dtgOrders.Columns[8].Visibility = Visibility.Hidden;
            dtgOrders.Columns[9].Visibility = Visibility.Hidden;
            dtgOrders.Columns[10].Visibility = Visibility.Hidden;
            dtgOrders.Columns[11].Header = "Логин";
            dtgOrders.Columns[12].Visibility = Visibility.Hidden;
            dtgOrders.Columns[13].Visibility = Visibility.Hidden;
            dtgOrders.Columns[14].Visibility = Visibility.Hidden;
            dtgOrders.Columns[15].Visibility = Visibility.Hidden;
            dtgOrders.Columns[16].Visibility = Visibility.Hidden;
            dtgOrders.Columns[17].Visibility = Visibility.Hidden;
            dtgOrders.Columns[18].Visibility = Visibility.Hidden;
            dtgOrders.Columns[19].Header = "Название товара";
            dtgOrders.Columns[20].Header = "Цена товара";
            dtgOrders.Columns[21].Visibility = Visibility.Hidden;
            dtgOrders.Columns[22].Visibility = Visibility.Hidden;
            dtgOrders.Columns[23].Visibility = Visibility.Hidden;
            dtgOrders.Columns[24].Visibility = Visibility.Hidden;
            dtgOrders.Columns[25].Visibility = Visibility.Hidden;
            dtgOrders.Columns[26].Visibility = Visibility.Hidden;
            dtgOrders.Columns[27].Visibility = Visibility.Hidden;
            dtgOrders.Columns[28].Visibility = Visibility.Hidden;
            dtgOrders.Columns[29].Visibility = Visibility.Hidden;
            dtgOrders.Columns[30].Visibility = Visibility.Hidden;
            dtgOrders.Columns[31].Visibility = Visibility.Hidden;
            dtgOrders.Columns[32].Visibility = Visibility.Hidden;
            dtgOrders.Columns[33].Header = "Название фирмы";
            dtgOrders.Columns[34].Visibility = Visibility.Hidden;
            dtgOrders.Columns[35].Visibility = Visibility.Hidden;
            dtgOrders.Columns[36].Visibility = Visibility.Hidden;
            dtgOrders.Columns[37].Visibility = Visibility.Hidden;
            dtgOrders.Columns[38].Visibility = Visibility.Hidden;
            dtgOrders.Columns[39].Visibility = Visibility.Hidden;
            dtgOrders.Columns[40].Visibility = Visibility.Hidden;
            dtgOrders.Columns[41].Visibility = Visibility.Hidden;
            dtgOrders.Columns[42].Visibility = Visibility.Hidden;
            dtgOrders.Columns[43].Visibility = Visibility.Hidden;
            dtgOrders.Columns[44].Visibility = Visibility.Hidden;
            dtgOrders.Columns[45].Visibility = Visibility.Hidden;
            dtgOrders.Columns[46].Visibility = Visibility.Hidden;
            dtgOrders.Columns[47].Visibility = Visibility.Hidden;
            dtgOrders.Columns[48].Visibility = Visibility.Hidden;
            dtgOrders.Columns[49].Visibility = Visibility.Hidden;
            dtgOrders.Columns[50].Visibility = Visibility.Hidden;
            dtgOrders.Columns[51].Visibility = Visibility.Hidden;
            dtgOrders.Columns[52].Visibility = Visibility.Hidden;
            dtgOrders.Columns[53].Header = "Название модели";
            dtgOrders.Columns[54].Visibility = Visibility.Hidden;
            dtgOrders.Columns[55].Visibility = Visibility.Hidden;
            dtgOrders.Columns[56].Header = "Название бренда";
            dtgOrders.Columns[57].Visibility = Visibility.Hidden;
        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _orderFill();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для BuyParts.xaml
    /// </summary>
    public partial class BuyParts : Window
    {
        //Создание листа для добавления данных
        ArrayList value = new ArrayList();
        //Запрос на вывод данных из таблицы "Корзина"
        string qrBasket = "select [ID_Basket],[Count_Part_Basket],[User_ID],[ID_User],[Email_User],[Login_User],[Password_User],[Role_ID],[ID_Role],[Name_Role],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Damage],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Basket]  inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role] inner join [dbo].[Part] on [Part_ID] = [ID_Part] inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";
        //Запрос на вывод данных из таблицы "Запчасть"
        string qrPart = "select [ID_Part],[Part_Status],[Name_Part],[Price_Part],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[OGRN],[INN],[Damage],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Part]  inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";
        //создание переменной для роли
        int role = 3;
        //СОздание переменной для количества товара
        int count = 1;
        public BuyParts()
        {
            InitializeComponent();
        }
        //событие добавления товара в корзину
        private void btnAddBasket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowView = (DataRowView)dtgOrders.SelectedItems[0];
                //очистка листа
                value.Clear();
                //проверка выделена ли строка
                if (rowView[0] != null)
                {
                    //добавления в листа данных: количество, роль и данные из выделенной строки
                    value.Add(count);
                    value.Add(role);
                    value.Add(rowView[0]);
                    //создание экземляра класса
                    DataSetClass dataSetClass = new DataSetClass();
                    //Запрос на добавление данных в таблицу "Корзина"
                    dataSetClass.DataSetFill(qrBasket, "Basket", DataSetClass.Function.insert, value);
                    

                    MessageBox.Show("Товар добален в корзину!");
                    //Переход на окно корзины
                    Basket basket = new Basket();
                    basket.Show();
                    Close();




                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        //Открытие окна пользователя
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            Close();
        }


       
        //событие выделения строки
        private void dtgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgOrders.Items.Count != 0 & dtgOrders.SelectedItems.Count != 0)
            {
                DataRowView dataRow = (DataRowView)dtgOrders.SelectedItems[0];
                
            }
        }
        //заполнение datagrid
        private void _partsfill()
        {
            //создание экземпляра класса для работы с БД
            DataSetClass dataSet = new DataSetClass();
            //запрос на выборку данных из таблицы "PArt"
            dataSet.DataSetFill(qrPart, "Part", DataSetClass.Function.select, null);
            dtgOrders.ItemsSource = DataSetClass.dataSet.Tables["Part"].DefaultView;
            dtgOrders.Columns[0].Visibility = Visibility.Hidden;
            dtgOrders.Columns[1].Header = "Статус запчасти";
            dtgOrders.Columns[2].Header = "Название запчасти";
            dtgOrders.Columns[3].Header = "Цена запчасти";
            dtgOrders.Columns[4].Visibility = Visibility.Hidden;
            dtgOrders.Columns[5].Visibility = Visibility.Hidden;
            dtgOrders.Columns[6].Visibility = Visibility.Hidden;
            dtgOrders.Columns[7].Visibility = Visibility.Hidden;
            dtgOrders.Columns[8].Header = "Название поставщика";
            dtgOrders.Columns[9].Header = "Адрес поставщика";
            dtgOrders.Columns[10].Visibility = Visibility.Hidden;
            dtgOrders.Columns[11].Visibility = Visibility.Hidden;
            dtgOrders.Columns[12].Visibility = Visibility.Hidden;
            dtgOrders.Columns[13].Visibility = Visibility.Hidden;
            dtgOrders.Columns[14].Visibility = Visibility.Hidden;
            dtgOrders.Columns[15].Visibility = Visibility.Hidden;
            dtgOrders.Columns[16].Visibility = Visibility.Hidden;
            dtgOrders.Columns[17].Visibility = Visibility.Hidden;
            dtgOrders.Columns[18].Visibility = Visibility.Hidden;
            dtgOrders.Columns[19].Visibility = Visibility.Hidden;
            dtgOrders.Columns[20].Visibility = Visibility.Hidden;
            dtgOrders.Columns[21].Visibility = Visibility.Hidden;
            dtgOrders.Columns[22].Visibility = Visibility.Hidden;
            dtgOrders.Columns[23].Header = "Брак";
            dtgOrders.Columns[24].Visibility = Visibility.Hidden;
            dtgOrders.Columns[25].Visibility = Visibility.Hidden;
            dtgOrders.Columns[26].Visibility = Visibility.Hidden;
            dtgOrders.Columns[27].Visibility = Visibility.Hidden;
            dtgOrders.Columns[28].Visibility = Visibility.Hidden;
            dtgOrders.Columns[29].Visibility = Visibility.Hidden;
            dtgOrders.Columns[30].Visibility = Visibility.Hidden;
            dtgOrders.Columns[31].Visibility = Visibility.Hidden;
            dtgOrders.Columns[32].Header = "Тип запчасти";
            dtgOrders.Columns[33].Visibility = Visibility.Hidden;
            dtgOrders.Columns[34].Visibility = Visibility.Hidden;
            dtgOrders.Columns[35].Header = "Модель";
            dtgOrders.Columns[36].Visibility = Visibility.Hidden;
            dtgOrders.Columns[37].Visibility = Visibility.Hidden;
            dtgOrders.Columns[38].Header = "Бренд";
            dtgOrders.Columns[39].Header = "Количество";


        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _partsfill();
        }
    }
}

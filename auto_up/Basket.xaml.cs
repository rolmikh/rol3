using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data;
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
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;

namespace auto_up
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        //Запрос на вывод данных из таблицы "Корзина"
        string qrBasket = "select [ID_Basket],[Count_Part_Basket],[User_ID],[ID_User],[Email_User],[Login_User],[Password_User],[Role_ID],[ID_Role],[Name_Role],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Damage],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Basket]  inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role] inner join [dbo].[Part] on [Part_ID] = [ID_Part] inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";
       //Создание листа для вывода пользователей
        ArrayList user = new ArrayList();
        //Создание листа для вывода товаров
        ArrayList part = new ArrayList();
        //Создание листа для добавления данных
        ArrayList value = new ArrayList();
        public Basket()
        {
            InitializeComponent();
        }
        //Изменение количества товара в корзине
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataRowView rowView = (DataRowView)dtgBasket.SelectedItems[0];
                //очистка листа
                value.Clear();
                //проверка выделенна ли строка
                if (rowView[0] != null)
                {
                    //добавление данных выделенной строки
                    value.Add(rowView[0]);
                    if (!string.IsNullOrEmpty(txtCount.Text))
                    {
                        //создание экземпляра класса
                        DataSetClass dataSetClass = new DataSetClass();
                        //Присвоение ID номера из запроса выборки
                        int Iduser = Convert.ToInt32(DataSetClass.dataSet.Tables["User"].Rows[0][0]);
                        //Выборка из таблицы бд User значений
                        dataSetClass.DataSetFill(string.Format("select * from [dbo].[User] where [Login_User] = '{0}'", cmbuser.SelectedItem.ToString()), "User", DataSetClass.Function.select, null);
                        //Присвоение ID номера из запроса выборки
                        int Idpart = Convert.ToInt32(DataSetClass.dataSet.Tables["Part"].Rows[0][0]);
                        //Выборка из таблицы бд Part значений
                        dataSetClass.DataSetFill(string.Format("select * from [dbo].[Part] where [Name_Part] = '{0}'", cmbpart.SelectedItem.ToString()), "Part", DataSetClass.Function.select, null);
                        //добавление в лист 
                        value.Add(txtCount.Text);
                        value.Add(Iduser);
                        value.Add(Idpart);
                        //запрос на изменение данных
                        dataSetClass.DataSetFill(qrBasket, "Basket", DataSetClass.Function.update, value);
                        //очистка полей ввода
                        cmbuser.SelectedItem = null;
                        cmbpart.SelectedItem = null;
                        txtCount.Text = string.Empty;
                        //вызов метода вывода данных в таблицу
                        _basket();
                    }
                    else
                    {
                        MessageBox.Show("Поле 'Количество' должно быть заполнено!");
                        txtCount.Focus();
                    }



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

        
        //заполнение Combobox
        private void _userFill()
        {
            //Создание экземпляра класса БД
            DataSetClass dataSetClass = new DataSetClass();
            //запрос на вывод данных о пользователе
            dataSetClass.DataSetFill("select * from [dbo].[User]", "User", DataSetClass.Function.select, null);
            //очистка листа
            user.Clear();
            //Перебор данных пользователя и вывод соответсвующего столбца в ComboBox
            for (int i = 0; i < DataSetClass.dataSet.Tables["User"].Rows.Count; i++)
            {
                user.Add(DataSetClass.dataSet.Tables["User"].Rows[i][2]);
            }
            cmbuser.ItemsSource = user;
        }
        //заполнение Combobox
        private void _partFill()
        {
            //Создание экземпляра класса БД
            DataSetClass dataSetClass = new DataSetClass();
            //запрос на вывод данных о запчастях
            dataSetClass.DataSetFill("select * from [dbo].[Part]", "Part", DataSetClass.Function.select, null);
            //очистка листа
            part.Clear();
            //Перебор данных запчастей и вывод соответсвующего столбца в ComboBox
            for (int i = 0; i < DataSetClass.dataSet.Tables["Part"].Rows.Count; i++)
            {
                part.Add(DataSetClass.dataSet.Tables["Part"].Rows[i][2]);
            }
            cmbpart.ItemsSource = part;
        }
        //переход на окно пользователя
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            Close();
        }
        //метод вывод данных в таблицу 
        private void _basket()
        {
           //Создание экземпляра класса для работы с БД
            DataSetClass dataSet = new DataSetClass();
            //запрос на вывод данных из таблицы "Basket"
            dataSet.DataSetFill(qrBasket, "Basket", DataSetClass.Function.select, null);
            dtgBasket.ItemsSource = DataSetClass.dataSet.Tables["Basket"].DefaultView;
            dtgBasket.Columns[0].Visibility = Visibility.Hidden;
            dtgBasket.Columns[1].Header = "Количество";
            dtgBasket.Columns[2].Visibility = Visibility.Hidden;
            dtgBasket.Columns[3].Visibility = Visibility.Hidden;
            dtgBasket.Columns[4].Visibility = Visibility.Hidden;
            dtgBasket.Columns[5].Header = "Логин пользователя"; 
            dtgBasket.Columns[6].Visibility = Visibility.Hidden;
            dtgBasket.Columns[7].Visibility = Visibility.Hidden;
            dtgBasket.Columns[8].Visibility = Visibility.Hidden;
            dtgBasket.Columns[9].Visibility = Visibility.Hidden;
            dtgBasket.Columns[10].Visibility = Visibility.Hidden;
            dtgBasket.Columns[11].Visibility = Visibility.Hidden;
            dtgBasket.Columns[12].Visibility = Visibility.Hidden;
            dtgBasket.Columns[13].Header = "Название";
            dtgBasket.Columns[14].Header = "Стоимость";
            dtgBasket.Columns[15].Visibility = Visibility.Hidden;
            dtgBasket.Columns[16].Visibility = Visibility.Hidden;
            dtgBasket.Columns[17].Visibility = Visibility.Hidden;
            dtgBasket.Columns[18].Visibility = Visibility.Hidden;
            dtgBasket.Columns[19].Visibility = Visibility.Hidden;
            dtgBasket.Columns[20].Visibility = Visibility.Hidden;
            dtgBasket.Columns[21].Visibility = Visibility.Hidden; 
            dtgBasket.Columns[22].Visibility = Visibility.Hidden;
            dtgBasket.Columns[23].Visibility = Visibility.Hidden;
            dtgBasket.Columns[24].Visibility = Visibility.Hidden;
            dtgBasket.Columns[25].Visibility = Visibility.Hidden;
            dtgBasket.Columns[26].Visibility = Visibility.Hidden;
            dtgBasket.Columns[27].Visibility = Visibility.Hidden;
            dtgBasket.Columns[28].Visibility = Visibility.Hidden;
            dtgBasket.Columns[29].Visibility = Visibility.Hidden;
            dtgBasket.Columns[30].Visibility = Visibility.Hidden;
            dtgBasket.Columns[31].Visibility = Visibility.Hidden;
            dtgBasket.Columns[32].Visibility = Visibility.Hidden;
            dtgBasket.Columns[33].Visibility = Visibility.Hidden;
            dtgBasket.Columns[34].Visibility = Visibility.Hidden;
            dtgBasket.Columns[35].Visibility = Visibility.Hidden;
            dtgBasket.Columns[36].Visibility = Visibility.Hidden;
            dtgBasket.Columns[37].Visibility = Visibility.Hidden;
            dtgBasket.Columns[38].Visibility = Visibility.Hidden;
            dtgBasket.Columns[39].Visibility = Visibility.Hidden;
            dtgBasket.Columns[40].Visibility = Visibility.Hidden;
            dtgBasket.Columns[41].Visibility = Visibility.Hidden;
            dtgBasket.Columns[42].Visibility = Visibility.Hidden;
            dtgBasket.Columns[43].Visibility = Visibility.Hidden;
            dtgBasket.Columns[44].Header = "Тип запчасти";
            dtgBasket.Columns[45].Visibility = Visibility.Hidden;
            dtgBasket.Columns[46].Visibility = Visibility.Hidden;
            dtgBasket.Columns[47].Header = "Модель";
            dtgBasket.Columns[48].Visibility = Visibility.Hidden;
            dtgBasket.Columns[49].Visibility = Visibility.Hidden;
            dtgBasket.Columns[50].Header = "Бренд";
            dtgBasket.Columns[51].Visibility = Visibility.Hidden;


        }
        //событие нажатия на строку и заполнение полей
        private void dtgBasket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgBasket.Items.Count != 0 & dtgBasket.SelectedItems.Count != 0)
            {
                DataRowView dataRow = (DataRowView)dtgBasket.SelectedItems[0];
                txtCount.Text = dataRow[1].ToString();
                cmbuser.Text = dataRow[5].ToString();
                cmbpart.SelectedItem = dataRow[13].ToString();


            }
        }
        //событие срабатывает при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _basket();
            _partFill();
            _userFill();
            
        }
    }
}

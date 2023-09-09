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
    /// Логика взаимодействия для StatisticPeriod.xaml
    /// </summary>
    public partial class StatisticPeriod : Window
    {
        //запрос на выборку данных таблицы "Заказ"
        string qrOrder = "select [ID_Order],[Number_Order],[Amount],[Status],[Date],[Basket_ID],[ID_Basket],[Count_Part_Basket],[User_ID],[ID_User],[Email_User],[Login_User],[Password_User],[Role_ID],[ID_Role],[Name_Role],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Damage],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Order] inner join [dbo].[Basket] on [Basket_ID] = [ID_Basket] inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role] inner join [dbo].[Part] on [Part_ID] = [ID_Part] inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";

        public StatisticPeriod()
        {
            InitializeComponent();
            
        }
        //вывод данных в соответствии с выбранным периодом
        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var startDate = datebeforeSale.Text;
                var endDate = dateafterSale.Text;
                string qrOrderFilter = String.Format("select [Number_Order] as 'Номер заказа',[Amount] as 'Сумма заказа',[Status] as 'Статус заказа',[Date] as 'Дата заказа',[Count_Part_Basket] as 'Количество товара',[Login_User] as 'Логин пользователя'," +
                    "[Name_Part] as 'Название товара',[Price_Part] as 'Цена товара',[Name_Firm] as 'Название фирмы',[Name_Country] as 'Страна'," +
                    "[Name_Model] as 'Модель',[Name_Brand] as 'Бренд',[Count] as 'Количество' from [dbo].[Order] inner join [dbo].[Basket] on [Basket_ID] = [ID_Basket] " +
                "inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role] " +
                "inner join [dbo].[Part] on [Part_ID] = [ID_Part] inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] " +
                "inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] " +
                "inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] " +
                "inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] " +
                "inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand] where [dbo].[Order].[Date] BETWEEN CONVERT(DATE, '{0}', 104) AND CONVERT(DATE, '{1}', 104) ", startDate, endDate);
                DataSetClass dataSet = new DataSetClass();
                dataSet.DataSetFill(qrOrderFilter, "Order", DataSetClass.Function.select, null);
                dtgSales.ItemsSource = DataSetClass.dataSet.Tables["Order"].DefaultView;
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            
        }
        //переход на окно сотрудника
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow worker = new WorkerWindow();
            worker.Show();
            Close();
        }

        
    }
}

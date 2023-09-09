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
    /// Логика взаимодействия для Contracts.xaml
    /// </summary>
    public partial class Contracts : Window
    {
        //запрос на выборку данных таблицы "Контракт"
        string qrContract = "select [ID_Contract],[Number_Contract],[Date_Contract],[Express_Contract],[Sostav_Contract],[Type_Contract_ID],[ID_Type_Contract],[Name_Type_Contract],[Store_ID],[ID_Store],[Name_Store],[Address_Store],[Storehouse_ID],[ID_Storehouse],[Count_Storehouse],[Number_Storehouse],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Damage],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Contract] inner join [dbo].[Type_Contract] on [Type_Contract_ID] = [ID_Type_Contract] inner join [dbo].[Store] on [Store_ID] = [ID_Store] inner join [dbo].[Storehouse] on [Storehouse_ID] = [ID_Storehouse] inner join [dbo].[Part] on [Part_ID] = [ID_Part] inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";
        public Contracts()
        {
            InitializeComponent();
        }
        //переход на окно добавления контракта
        private void btnToContract_Click(object sender, RoutedEventArgs e)
        {
            NewContract newContract = new NewContract();
            newContract.Show();
            Close();
        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _contractFill();
        }
        //метод вывода данных в таблицу
        private void _contractFill()
        {
            //создание экземпляра класса для работы с БД
            DataSetClass dataSet = new DataSetClass();
            //запрос на выборку данных из таблицы "Контракт"
            dataSet.DataSetFill(qrContract, "Contract", DataSetClass.Function.select, null);
            dtgContract.ItemsSource = DataSetClass.dataSet.Tables["Contract"].DefaultView;
            dtgContract.Columns[0].Visibility = Visibility.Hidden;
            dtgContract.Columns[1].Header = "Номер контракта";
            dtgContract.Columns[2].Header = "Дата заключения";
            dtgContract.Columns[3].Header = "Срочность контракта";
            dtgContract.Columns[4].Header = "Состав контракта";
            dtgContract.Columns[5].Visibility = Visibility.Hidden;
            dtgContract.Columns[6].Visibility = Visibility.Hidden;
            dtgContract.Columns[7].Header = "Название типа контракта";
            dtgContract.Columns[8].Visibility = Visibility.Hidden;
            dtgContract.Columns[9].Visibility = Visibility.Hidden;
            dtgContract.Columns[10].Header = "Название магазина";
            dtgContract.Columns[11].Header = "Адрес магазина";
            dtgContract.Columns[12].Visibility = Visibility.Hidden;
            dtgContract.Columns[13].Visibility = Visibility.Hidden;
            dtgContract.Columns[14].Header = "Количество";
            dtgContract.Columns[15].Header = "Номер на складе";
            dtgContract.Columns[16].Visibility = Visibility.Hidden;
            dtgContract.Columns[17].Visibility = Visibility.Hidden;
            dtgContract.Columns[18].Header = "Статус запчасти";
            dtgContract.Columns[19].Header = "Название запчасти";
            dtgContract.Columns[20].Header = "Цена запчасти";
            dtgContract.Columns[21].Visibility = Visibility.Hidden;
            dtgContract.Columns[22].Visibility = Visibility.Hidden;
            dtgContract.Columns[23].Visibility = Visibility.Hidden;
            dtgContract.Columns[24].Visibility = Visibility.Hidden;
            dtgContract.Columns[25].Header = "Название поставщика";
            dtgContract.Columns[26].Header = "Адрес поставщика";
            dtgContract.Columns[27].Visibility = Visibility.Hidden;
            dtgContract.Columns[28].Visibility = Visibility.Hidden;
            dtgContract.Columns[29].Header = "Название типа поставщика";
            dtgContract.Columns[30].Visibility = Visibility.Hidden;
            dtgContract.Columns[31].Visibility = Visibility.Hidden;
            dtgContract.Columns[32].Header = "Название фирмы";
            dtgContract.Columns[33].Header = "Юридический адрес";
            dtgContract.Columns[34].Header = "Физический адрес";
            dtgContract.Columns[35].Header = "Номер телефона";
            dtgContract.Columns[36].Header = "Электронная почта";
            dtgContract.Columns[37].Header = "БИК";
            dtgContract.Columns[38].Header = "КПП";
            dtgContract.Columns[39].Header = "ОГРН";
            dtgContract.Columns[40].Header = "ИНН";
            dtgContract.Columns[41].Header = "Брак";
            dtgContract.Columns[42].Visibility = Visibility.Hidden;
            dtgContract.Columns[43].Visibility = Visibility.Hidden;
            dtgContract.Columns[44].Header = "Название типа фирмы";
            dtgContract.Columns[45].Visibility = Visibility.Hidden;
            dtgContract.Columns[46].Visibility = Visibility.Hidden;
            dtgContract.Columns[47].Header = "Страна";
            dtgContract.Columns[48].Visibility = Visibility.Hidden;
            dtgContract.Columns[49].Visibility = Visibility.Hidden;
            dtgContract.Columns[50].Header = "Тип запчасти";
            dtgContract.Columns[51].Visibility = Visibility.Hidden;
            dtgContract.Columns[52].Visibility = Visibility.Hidden;
            dtgContract.Columns[53].Header = "Модель";
            dtgContract.Columns[54].Visibility = Visibility.Hidden;
            dtgContract.Columns[55].Visibility = Visibility.Hidden;
            dtgContract.Columns[56].Header = "Бренд";
            dtgContract.Columns[57].Header = "Количество";

        }
    }
}

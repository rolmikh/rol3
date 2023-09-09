using System;
using System.Collections;
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
    /// Логика взаимодействия для NewContract.xaml
    /// </summary>
    public partial class NewContract : Window
    {
        //запрос на выборку данных из таблицы "КОнтракт"
        string qrContract = "select [ID_Contract],[Number_Contract],[Date_Contract],[Express_Contract],[Sostav_Contract],[Type_Contract_ID],[ID_Type_Contract],[Name_Type_Contract],[Store_ID],[ID_Store],[Name_Store],[Address_Store],[Storehouse_ID],[ID_Storehouse],[Count_Storehouse],[Number_Storehouse],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Damage],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Contract] inner join [dbo].[Type_Contract] on [Type_Contract_ID] = [ID_Type_Contract] inner join [dbo].[Store] on [Store_ID] = [ID_Store] inner join [dbo].[Storehouse] on [Storehouse_ID] = [ID_Storehouse] inner join [dbo].[Part] on [Part_ID] = [ID_Part] inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";
        //создание листа для добавления данных
        ArrayList value = new ArrayList();
        //создание листа для вывода данных из таблицы в выпадающий список
        ArrayList type = new ArrayList();
        //создание листа для вывода данных из таблицы в выпадающий список
        ArrayList provider = new ArrayList();

        public NewContract()
        {
            InitializeComponent();
        }
        //добавление данных
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //очистка листа
                value.Clear();
                if(!string.IsNullOrEmpty(txtNumber.Text))
                {
                    if(cmbType.SelectedItem != null)
                    {
                        if(!string.IsNullOrEmpty(txtExpress.Text))
                        {
                            if(!string.IsNullOrEmpty(txtSostav.Text))
                            {
                                if(cmbProvider.SelectedItem != null)
                                {
                                    if(!string.IsNullOrEmpty(date.Text))
                                    {
                                        DataSetClass dataSetClass = new DataSetClass();
                                        //Выборка из таблицы бд Type_Contract значений
                                        dataSetClass.DataSetFill(string.Format("select * from [dbo].[Type_Contract] where [Name_Type_Contract] = '{0}'", cmbType.SelectedItem.ToString()), "Type_Contract", DataSetClass.Function.select, null);
                                        //Присвоение ID номера из запроса выборки
                                        int IdTypeContract = Convert.ToInt32(DataSetClass.dataSet.Tables["Type_Contract"].Rows[0][0]);
                                        //Выборка из таблицы бд Store значений
                                        dataSetClass.DataSetFill(string.Format("select * from [dbo].[Store] where [Name_Store] = '{0}'", cmbProvider.SelectedItem.ToString()), "Store", DataSetClass.Function.select, null);
                                        //Присвоение ID номера из запроса выборки
                                        int IdProvider = Convert.ToInt32(DataSetClass.dataSet.Tables["Store"].Rows[0][0]);
                                        //заполнение данных
                                        value.Add(txtNumber.Text);
                                        value.Add(date.Text);
                                        value.Add(txtExpress.Text);
                                        value.Add(txtSostav.Text);
                                        value.Add(IdTypeContract);
                                        value.Add(IdProvider);
                                        //запрос на добавление данных
                                        dataSetClass.DataSetFill(qrContract, "Contract", DataSetClass.Function.insert, value);

                                        txtNumber.Text = string.Empty;
                                        date.Text = string.Empty;
                                        txtExpress.Text = string.Empty;
                                        txtSostav.Text = string.Empty;
                                        cmbType.SelectedItem = null;
                                        cmbProvider.SelectedItem = null;
                                        //открытие предыдущего окна
                                        Contracts contracts = new Contracts();
                                        contracts.Show();
                                        Close();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Выберите дату!");
                                    }



                                }
                                else
                                {
                                    MessageBox.Show("Выберите поставщика");
                                    cmbProvider.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Поле 'Состав договора' должно быть заполнено!");
                                txtSostav.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите срочность договора!");
                            txtExpress.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите тип договора!");
                        cmbType.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'Номер договора' должно быть заполнено!");
                    txtNumber.Focus(); 
                }

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
        //переход на окно всех контрактов
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Contracts contracts = new Contracts();  
            contracts.Show();
            Close();
        }
        //метод для заполнения выпадающего списка 
        private void _typeContract()
        {
            //Создание экземпляра класса для работы с БД
            DataSetClass dataSetClass = new DataSetClass();
            //запрос на выборку данных из таблицы "Тип контракта"
            dataSetClass.DataSetFill("select * from [dbo].[Type_Contract]", "Type_Contract", DataSetClass.Function.select, null);
           //очистка листа
            type.Clear();
            //перебор значений и заполнение выпадающего списка значениями определенного столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Type_Contract"].Rows.Count; i++)
            {
                type.Add(DataSetClass.dataSet.Tables["Type_Contract"].Rows[i][1]);
            }
            cmbType.ItemsSource = type;
        }
        //метод для заполнения выпадающего списка 
        private void _provider()
        {
            //создание экземпляра класса для работы с БД
            DataSetClass dataSetClass = new DataSetClass();
            //запрос на выборку данных из таблицы "Магазиин"
            dataSetClass.DataSetFill("select * from [dbo].[Store]", "Store", DataSetClass.Function.select, null);
            //очистка листа
            provider.Clear();
            //перебор значений и заполнение выпадающего списка значениями определенного столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Store"].Rows.Count; i++)
            {
                provider.Add(DataSetClass.dataSet.Tables["Store"].Rows[i][1]);
            }
            cmbProvider.ItemsSource = provider;
        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _typeContract();
            _provider();
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace auto_up
{
    /// <summary>
    /// Логика взаимодействия для NewFirm.xaml
    /// </summary>
    public partial class NewFirm : Window
    {
        //создание листа для вывода данных из таблицы в выпадающий список
        ArrayList value = new ArrayList();
        //создание листа для вывода данных из таблицы в выпадающий список
        ArrayList type = new ArrayList();
        //создание листа для вывода данных из таблицы в выпадающий список
        ArrayList country = new ArrayList();
        //создание запроса на выборку данных из таблицы "Фирма"
        string qrFirm = "select [ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country] from [dbo].[Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm]";

        public NewFirm()
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
                if (!string.IsNullOrEmpty(txtTitle.Text))
                {

                    if(!string.IsNullOrEmpty(txtLegalAddress.Text))
                    {

                        if(!string.IsNullOrEmpty(txtPhysicalAddress.Text))
                        {
                            if (!string.IsNullOrEmpty(txtNumber.Text))
                            {

                                if (!string.IsNullOrEmpty(txtEmail.Text))
                                {

                                    if (!string.IsNullOrEmpty(txtBIC.Text))
                                    {

                                        if(!string.IsNullOrEmpty(txtKPP.Text))
                                        {

                                            if(!string.IsNullOrEmpty(txtOGRN.Text))
                                            {

                                                if (!string.IsNullOrEmpty(txtINN.Text))
                                                {
                                                    if (cmbType.SelectedItem != null)
                                                    {

                                                        if (cmbCountry.SelectedItem != null)
                                                        {

                                                            //создание экземпляра класса для работы с БД
                                                            DataSetClass dataSetClass = new DataSetClass();

                                                            //Выборка из таблицы бд Type_Firm значений
                                                            dataSetClass.DataSetFill(string.Format("select * from [dbo].[Type_Firm] where [Name_Type_Firm] = '{0}'", cmbType.SelectedItem.ToString()), "Type_Firm", DataSetClass.Function.select, null);
                                                            //Присвоение ID номера из запроса выборки
                                                            int IdTypeFirm = Convert.ToInt32(DataSetClass.dataSet.Tables["Type_Firm"].Rows[0][0]);
                                                            //Выборка из таблицы бд Country значений
                                                            dataSetClass.DataSetFill(string.Format("select * from [dbo].[Country] where [Name_Country] = '{0}'", cmbCountry.SelectedItem.ToString()), "Country", DataSetClass.Function.select, null);
                                                            //Присвоение ID номера из запроса выборки
                                                            int IdCountry = Convert.ToInt32(DataSetClass.dataSet.Tables["Country"].Rows[0][0]);
                                                            //заполнение листа
                                                            value.Add(txtTitle.Text);
                                                            value.Add(txtLegalAddress.Text);
                                                            value.Add(txtPhysicalAddress.Text);
                                                            value.Add(txtNumber.Text);
                                                            value.Add(txtEmail.Text);
                                                            value.Add(txtBIC.Text);
                                                            value.Add(txtKPP.Text);
                                                            value.Add(txtOGRN.Text);
                                                            value.Add(txtINN.Text);
                                                            value.Add(IdTypeFirm);
                                                            value.Add(IdCountry);
                                                            //запрос на добавление данных
                                                            dataSetClass.DataSetFill(qrFirm, "Firm", DataSetClass.Function.insert, value);
                                                            //вызов метода вывод данных в таблицу
                                                            _firmFill();
                                                            //очистка полей
                                                            cmbType.SelectedItem = null;
                                                            txtTitle.Text = string.Empty;
                                                            txtLegalAddress.Text = string.Empty;
                                                            txtPhysicalAddress.Text = string.Empty;
                                                            txtBIC.Text = string.Empty;
                                                            txtINN.Text = string.Empty;
                                                            txtKPP.Text = string.Empty;
                                                            txtOGRN.Text = string.Empty;
                                                            txtNumber.Text = string.Empty;
                                                            txtEmail.Text = string.Empty;
                                                            cmbCountry.SelectedItem = null;

                                                        }
                                                        else
                                                        {
                                                                MessageBox.Show("Выберите страну!");
                                                                cmbCountry.Focus();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Выберите тип фирмы!");
                                                        cmbType.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Поле 'ИНН' должно быть заполено!");
                                                    txtINN.Focus();
                                                }

                                            }
                                            else
                                            {
                                               MessageBox.Show("Поле 'ОГРН' должно быть заполено!");
                                               txtOGRN.Focus();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Поле 'КПП' должно быть заполнено");
                                            txtKPP.Focus();
                                        }

                                   
                                    }
                                    else
                                    {
                                        MessageBox.Show("Поле 'БИК' должно быть заполнено!");
                                        txtBIC.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Поле 'Электронная почта' должно быть заполнено!");
                                    txtEmail.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Поле 'Номер телефона' должно быть заполнено!");
                                txtNumber.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Поле 'Физический адрес' должно быть заполнено!");
                            txtPhysicalAddress.Focus();
                        }

                    }
                    else
                    {
                       MessageBox.Show("Поле 'Юридический адрес' должно быть заполнено!");
                       txtLegalAddress.Focus();
                    }
                   
                
                }
                else
                {
                    MessageBox.Show("Поле 'Название' должно быть заполнено!");
                    txtTitle.Focus();
                }
            }
            catch
            {

                MessageBox.Show("Ошибка!");
            }
        }
        //метод для вывод данных в таблицу 
        private void _firmFill()
        {
            try
            {
                //создание экземпляра класса для работы с БД
                DataSetClass dataSet = new DataSetClass();
                //запрос на выборку данных из таблицы "ФИрма"
                dataSet.DataSetFill(qrFirm, "Firm", DataSetClass.Function.select, null);
                dtgFirms.ItemsSource = DataSetClass.dataSet.Tables["Firm"].DefaultView;
                dtgFirms.Columns[0].Visibility = Visibility.Hidden;
                dtgFirms.Columns[1].Header = "Название фирмы";
                dtgFirms.Columns[2].Header = "Юридический адрес";
                dtgFirms.Columns[3].Header = "Физический адрес";
                dtgFirms.Columns[4].Header = "Номер телефона";
                dtgFirms.Columns[5].Header = "Электронная почта";
                dtgFirms.Columns[6].Header = "БИК";
                dtgFirms.Columns[7].Header = "КПП";
                dtgFirms.Columns[8].Header = "ОГРН";
                dtgFirms.Columns[9].Header = "ИНН";
                dtgFirms.Columns[10].Visibility = Visibility.Hidden;
                dtgFirms.Columns[11].Visibility = Visibility.Hidden;
                dtgFirms.Columns[12].Header = "Тип фирмы";
                dtgFirms.Columns[13].Visibility = Visibility.Hidden;
                dtgFirms.Columns[14].Visibility = Visibility.Hidden;
                dtgFirms.Columns[15].Header = "Страна";



            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }

        }
        //метод для заполнения выпадающего списка
        private void _typeFill()
        {
            DataSetClass dataSetClass = new DataSetClass();

            dataSetClass.DataSetFill("select * from [dbo].[Type_Firm]", "Type_Firm", DataSetClass.Function.select, null);
            type.Clear();
            for (int i = 0; i < DataSetClass.dataSet.Tables["Type_Firm"].Rows.Count; i++)
            {
                type.Add(DataSetClass.dataSet.Tables["Type_Firm"].Rows[i][1]);
            }
            cmbType.ItemsSource = type;

        }
        //метод для заполнения выпадающего списка
        private void _countryFill()
        {
            DataSetClass dataSetClass = new DataSetClass();

            dataSetClass.DataSetFill("select * from [dbo].[Country]", "Country", DataSetClass.Function.select, null);
            country.Clear();
            for (int i = 0; i < DataSetClass.dataSet.Tables["Country"].Rows.Count; i++)
            {
                country.Add(DataSetClass.dataSet.Tables["Country"].Rows[i][1]);
            }
            cmbCountry.ItemsSource = country;

        }
        //переход на другое окно для измения данных
        private void btnToChange_Click(object sender, RoutedEventArgs e)
        {
            ChangeFirm changeFirm = new ChangeFirm();
            
            changeFirm.Show();
            Close();
        }
        //метод удаления данных
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Создание экземпляра класса, кэш представление строки данных, с присвоением, с явным преобразованием, выбранной строки таблицы
                DataRowView rowView = (DataRowView)dtgFirms.SelectedItems[0];
                //очистка листа
                value.Clear();
                //Условие с проверкой того, не является ли, первый столбец кэш таблицы пустым, который отвечет за значение первичного ключа таблицы "Фирма"
                if (rowView[0] != null)
                {
                    //Добавление в не типизированную коллекцию, значения кэш строки из первого столбца, значение первичного ключа таблицы "Фирма"
                    value.Add(rowView[0]);
                    //Создание экземпляра класса работы с базой данных
                    DataSetClass dataSetClass = new DataSetClass();
                    //Вызов метода работы с запросами базы данных, с передачей аргументов: строковой переменной с запросом на выборку данных из таблицы "Фирма",
                    // название кэш таблицы, иструкции к алгоритму формирования запроса на удаление данных, не типизированный список с входными данными в запрос
                    dataSetClass.DataSetFill(qrFirm, "Firm", DataSetClass.Function.delete, value);
                    //вызов метода заполнения таблицы
                    _firmFill();
                    //очистка полей
                    cmbType.SelectedItem = null;
                    txtTitle.Text = string.Empty;
                    txtLegalAddress.Text = string.Empty;
                    txtPhysicalAddress.Text = string.Empty;
                    txtBIC.Text = string.Empty;
                    txtINN.Text = string.Empty;
                    txtKPP.Text = string.Empty;
                    txtOGRN.Text = string.Empty;
                    txtNumber.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    cmbCountry.SelectedItem = null;
                }
                else
                {
                    //Вывод сообщения об ошибке, что запись не выбрана в элемента управления
                    MessageBox.Show("Выберите запись которую хотите удалить!");
                    //Перевод курсора и фокуса на указанный визуальный элемент управления
                    dtgFirms.Focus();
                }



            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        //переход на окно администратора
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _firmFill();
            _typeFill();
            _countryFill();
        }
        //событие срабатывающее при нажатии на строку в таблице
        private void dtgFirms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgFirms.Items.Count != 0 & dtgFirms.SelectedItems.Count != 0)
            {
                DataRowView dataRow = (DataRowView)dtgFirms.SelectedItems[0];
                txtTitle.Text = dataRow[1].ToString();

            }
        }
    }
}

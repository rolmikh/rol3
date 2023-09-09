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

namespace auto_up
{
    /// <summary>
    /// Логика взаимодействия для ChangeFirm.xaml
    /// </summary>
    public partial class ChangeFirm : Window
    {
        //создание листа для добавления данных
        ArrayList value = new ArrayList();
        //создание листа для вывода данных из таблицы в выпадающий список
        ArrayList type = new ArrayList();
        //создание листа для вывода данных из таблицы в выпадающий список
        ArrayList country = new ArrayList();
        //запрос на выборку данных ищ таблицы "Фирма"
        string qrFirm = "select [ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country] from [dbo].[Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm]";

        
        public ChangeFirm()
        {
            InitializeComponent();
        }
        //событие изменения данных
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Создание экземпляра класса, кэш представление строки данных, с присвоением, с явным преобразованием, выбранной строки таблицы

                DataRowView rowView = (DataRowView)dtgFirms.SelectedItems[0];
                //очистка листа
                value.Clear();
                //проверка выбрана ли строка
                if (rowView[0] != null)
                {
             
                    value.Add(rowView[0]);

                    if (cmbType.SelectedItem != null)
                    {
                        if (!string.IsNullOrEmpty(txtTitle.Text))
                        {
                            if (!string.IsNullOrEmpty(txtLegalAddress.Text))
                            {
                                if (!string.IsNullOrEmpty(txtPhysicalAddress.Text))
                                {
                                    if (!string.IsNullOrEmpty(txtNumber.Text))
                                    {
                                        if (!string.IsNullOrEmpty(txtEmail.Text))
                                        {

                                            if (cmbCountry.SelectedItem != null)
                                            {
                                                //создание экземпляра класса
                                                DataSetClass dataSetClass = new DataSetClass();

                                                //Выборка из таблицы бд Type_Firm значений
                                                dataSetClass.DataSetFill(string.Format("select * from [dbo].[Type_Firm] where [Name_Type_Firm] = '{0}'", cmbType.SelectedItem.ToString()), "Type_Firm", DataSetClass.Function.select, null);
                                                //Присвоение ID номера из запроса выборки
                                                int IdTypeFirm = Convert.ToInt32(DataSetClass.dataSet.Tables["Type_Firm"].Rows[0][0]);
                                                //Выборка из таблицы бд Type_Firm значений
                                                dataSetClass.DataSetFill(string.Format("select * from [dbo].[Country] where [Name_Country] = '{0}'", cmbCountry.SelectedItem.ToString()), "Country", DataSetClass.Function.select, null);
                                                //Присвоение ID номера из запроса выборки
                                                int IdCountry = Convert.ToInt32(DataSetClass.dataSet.Tables["Country"].Rows[0][0]);
                                                //заполение данных
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
                                                //запрос на изменение данных
                                                var query = String.Format("Update [dbo].[Firm] set [Name_Firm] = '{1}', [Legal_Address] = '{2}', [Physical_Address] = '{3}', " +
                                                    "[Phone_Number_Firm] = '{4}', [Email_Firm] = '{5}', [BIC] = '{6}', [CHECKPOINT] = '{7}', [OGRN] = '{8}', [INN] = '{9}', [Type_Firm_ID] = '{10}', [Country_ID] = '{11}'" +
                                                    " where [ID_Firm] = '{0}'",
                                                    value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8], value[9], value[10], value[11]);
                                                dataSetClass.QueryDG(query, "Firm");
                                                //вызов метода вывода данных в таблицу
                                                _firmFill();
                                                //очистка полей
                                                txtTitle.Text = string.Empty;
                                                txtLegalAddress.Text = string.Empty;
                                                txtPhysicalAddress.Text = string.Empty;
                                                txtNumber.Text = string.Empty;
                                                txtEmail.Text = string.Empty;
                                                txtBIC.Text = string.Empty;
                                                txtKPP.Text = string.Empty;
                                                txtOGRN.Text = string.Empty;
                                                txtINN.Text = string.Empty;
                                                cmbType.SelectedItem = null;
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
                            MessageBox.Show("Поле 'Название' должно быть заполено!");
                            txtTitle.Focus();
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
                    MessageBox.Show("Ошибка!");
                }

            }
            catch (Exception ex) { }





        }
        //метод заполения выпадающего списка "Тип фирмы"
        private void _typeFill()
        {
            //создание экземпляра класса
            DataSetClass dataSetClass = new DataSetClass();
            //выборка данных из таблицы "Тип фирмы"
            dataSetClass.DataSetFill("select * from [dbo].[Type_Firm]", "Type_Firm", DataSetClass.Function.select, null);
            //очистка листа
            type.Clear();
            //заполнение выпадающего списка значениями из соответствующего столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Type_Firm"].Rows.Count; i++)
            {
                type.Add(DataSetClass.dataSet.Tables["Type_Firm"].Rows[i][1]);
            }
            cmbType.ItemsSource = type;

        }
        //метод заполения выпадающего списка "Тип фирмы"

        private void _countryFill()
        {
            //создание экземляра класса для работы с БД
            DataSetClass dataSetClass = new DataSetClass();
            //запрос на выборку данных из таблицы "Страна"
            dataSetClass.DataSetFill("select * from [dbo].[Country]", "Country", DataSetClass.Function.select, null);
           //очистка листа
            country.Clear();
            //заполнение выпадающего списка значениями из соответствующего столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Country"].Rows.Count; i++)
            {
                country.Add(DataSetClass.dataSet.Tables["Country"].Rows[i][1]);
            }
            cmbCountry.ItemsSource = country;

        }
        //переход на окно добавления фирмы
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NewFirm newFirm = new NewFirm();
            newFirm.Show();
            Close();
        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _countryFill();
            _typeFill();
            _firmFill();
            

        }
        //метод вывода данных в таблицу
        private void _firmFill()
        {
            try
            {
                //создание экземпляра класса для работы с БД
                DataSetClass dataSet = new DataSetClass();
                //запрос на выборку данных из таблицв "Фирма"
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
        //событие выбора определенной строки
        private void dtgFirms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dtgFirms.Items.Count != 0 & dtgFirms.SelectedItems.Count != 0)
                {
                    DataRowView dataRow = (DataRowView)dtgFirms.SelectedItems[0];
                    cmbType.Text = dataRow[12].ToString();
                    txtTitle.Text = dataRow[1].ToString();
                    txtLegalAddress.Text = dataRow[2].ToString();
                    txtPhysicalAddress.Text = dataRow[3].ToString();
                    txtNumber.Text = dataRow[4].ToString();
                    txtEmail.Text = dataRow[5].ToString();
                    txtBIC.Text = dataRow[6].ToString();
                    txtKPP.Text = dataRow[7].ToString();
                    txtOGRN.Text = dataRow[8].ToString();
                    txtINN.Text = dataRow[9].ToString();
                    cmbCountry.Text = dataRow[15].ToString();

                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            
        }

       
    }
}

﻿using System;
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
    /// Логика взаимодействия для ChangePart.xaml
    /// </summary>
    public partial class ChangePart : Window
    {
        //создание листа для добавления данных
        ArrayList value = new ArrayList();
        //создание листа для заполнения выпадабщего списка "Тип запчасти"
        ArrayList type = new ArrayList();
        //создание листа для заполнения выпадабщего списка "Поставщик"
        ArrayList provider = new ArrayList();
        //создание листа для заполнения выпадабщего списка "Модель"
        ArrayList model = new ArrayList();
        //создание листа для заполнения выпадабщего списка "Бренда"
        ArrayList brand = new ArrayList();
        //Запрос на выборку данных таблицы "Запчасть"
        string qrPart = "select [ID_Part],[Part_Status],[Name_Part],[Price_Part],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Damage],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Part]  inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] inner join [dbo].[Model] on [Model_ID] = [ID_Model] inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]";

        public ChangePart()
        {
            InitializeComponent();
        }
        //переход на окно добавления запчасти
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NewPart newPart = new NewPart();
            newPart.Show();
            Close();
        }
        //изменение данных о запчасти
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                //Создание экземпляра класса, кэш представление строки данных, с присвоением, с явным преобразованием, выбранной строки таблицы

                DataRowView rowView = (DataRowView)dtgParts.SelectedItems[0];
                //очистка листа
                value.Clear();
                //проверка выделена ли строка
                if (rowView[0] != null)
                {
                    value.Add(rowView[0]);
                    if (!string.IsNullOrEmpty(txtTitle.Text))
                    {
                        if (!string.IsNullOrEmpty(txtPrice.Text))
                        {
                            if (!string.IsNullOrEmpty(txtCount.Text))
                            {
                                //создание экземпляра класса
                                DataSetClass dataSetClass = new DataSetClass();
                                //Выборка из таблицы бд Provider значений
                                dataSetClass.DataSetFill(string.Format("select * from [dbo].[Provider] where [Name_Provider] = '{0}'", cmbProvider.SelectedItem.ToString()), "Provider", DataSetClass.Function.select, null);
                                //Присвоение ID номера из запроса выборки
                                int IdProvider = Convert.ToInt32(DataSetClass.dataSet.Tables["Provider"].Rows[0][0]);
                                //Выборка из таблицы бд Type_Part значений
                                dataSetClass.DataSetFill(string.Format("select * from [dbo].[Type_Part] where [Name_Type_Part] = '{0}'", cmbType.SelectedItem.ToString()), "Type_Part", DataSetClass.Function.select, null);
                                //Присвоение ID номера из запроса выборки
                                int Idtype = Convert.ToInt32(DataSetClass.dataSet.Tables["Type_Part"].Rows[0][0]);
                                //Выборка из таблицы бд Model значений
                                dataSetClass.DataSetFill(string.Format("select * from [dbo].[Model] where [Name_Model] = '{0}'", cmbModel.SelectedItem.ToString()), "Model", DataSetClass.Function.select, null);
                                //Присвоение ID номера из запроса выборки
                                int Idmodel = Convert.ToInt32(DataSetClass.dataSet.Tables["Model"].Rows[0][0]);
                                //Выборка из таблицы бд Brand значений
                                dataSetClass.DataSetFill(string.Format("select * from [dbo].[Brand] where [Name_Brand] = '{0}'", cmbBrend.SelectedItem.ToString()), "Brand", DataSetClass.Function.select, null);
                                //Присвоение ID номера из запроса выборки
                                int Idbrand = Convert.ToInt32(DataSetClass.dataSet.Tables["Brand"].Rows[0][0]);
                                //заполнение листа
                                value.Add(txtStatus.Text);
                                value.Add(txtTitle.Text);
                                value.Add(txtPrice.Text);
                                value.Add(cmbDamage.Text);
                                value.Add(IdProvider);
                                value.Add(Idtype);
                                value.Add(Idmodel);
                                value.Add(Idbrand);
                                value.Add(txtCount.Text);
                                //запрос на изменение данных таблицы "Запчасть"
                                dataSetClass.DataSetFill(qrPart, "Part", DataSetClass.Function.update, value);
                                //очистка полей
                                txtStatus.Text = string.Empty;
                                txtTitle.Text = string.Empty;
                                txtPrice.Text = string.Empty;
                                cmbDamage.Text = string.Empty;
                                cmbType.SelectedItem = null;
                                cmbProvider.SelectedItem = null;
                                cmbModel.SelectedItem = null;
                                cmbBrend.SelectedItem = null;
                                txtCount.Text = string.Empty;
                                //вызов метода вывода данных в таблицу
                                _partsfill();



                            }
                            else
                            {
                                MessageBox.Show("Поле 'Число товаров' должно быть заполнено");
                                txtCount.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Поле 'Стоимость товара' должно быть заполнено!");
                            txtPrice.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Поле 'Название товара' должно быть заполнено!");
                        txtTitle.Focus();
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
        //событие выбора строки
        private void dtgParts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgParts.Items.Count != 0 & dtgParts.SelectedItems.Count != 0)
            {
                DataRowView dataRow = (DataRowView)dtgParts.SelectedItems[0];
                txtStatus.Text = dataRow[1].ToString();
                txtTitle.Text = dataRow[2].ToString();
                txtPrice.Text = dataRow[3].ToString();
                cmbDamage.Text = dataRow[24].ToString();
                cmbProvider.SelectedItem = dataRow[8].ToString();
                cmbType.SelectedItem = dataRow[33].ToString();
                cmbModel.SelectedItem = dataRow[36].ToString();
                cmbBrend.SelectedItem = dataRow[39].ToString();
                txtCount.Text = dataRow[40].ToString();
                

            }
        }
        //событие вывода данных в таблицу
        private void _partsfill()
        {
            DataSetClass dataSet = new DataSetClass();
            dataSet.DataSetFill(qrPart, "Part", DataSetClass.Function.select, null);
            dtgParts.ItemsSource = DataSetClass.dataSet.Tables["Part"].DefaultView;
            dtgParts.Columns[0].Visibility = Visibility.Hidden;
            dtgParts.Columns[1].Header = "Статус запчасти";
            dtgParts.Columns[2].Header = "Название запчасти";
            dtgParts.Columns[3].Header = "Цена запчасти";
            dtgParts.Columns[4].Visibility = Visibility.Hidden;
            dtgParts.Columns[5].Visibility = Visibility.Hidden;
            dtgParts.Columns[6].Visibility = Visibility.Hidden;
            dtgParts.Columns[7].Visibility = Visibility.Hidden;
            dtgParts.Columns[8].Header = "Название поставщика";
            dtgParts.Columns[9].Header = "Адрес поставщика";
            dtgParts.Columns[10].Visibility = Visibility.Hidden;
            dtgParts.Columns[11].Visibility = Visibility.Hidden;
            dtgParts.Columns[12].Visibility = Visibility.Hidden;
            dtgParts.Columns[13].Visibility = Visibility.Hidden;
            dtgParts.Columns[14].Visibility = Visibility.Hidden;
            dtgParts.Columns[15].Visibility = Visibility.Hidden;
            dtgParts.Columns[16].Visibility = Visibility.Hidden;
            dtgParts.Columns[17].Visibility = Visibility.Hidden;
            dtgParts.Columns[18].Visibility = Visibility.Hidden;
            dtgParts.Columns[19].Visibility = Visibility.Hidden;
            dtgParts.Columns[20].Visibility = Visibility.Hidden;
            dtgParts.Columns[21].Visibility = Visibility.Hidden;
            dtgParts.Columns[22].Visibility = Visibility.Hidden;
            dtgParts.Columns[23].Visibility = Visibility.Hidden;
            dtgParts.Columns[24].Header = "Брак";
            dtgParts.Columns[25].Visibility = Visibility.Hidden;
            dtgParts.Columns[26].Visibility = Visibility.Hidden;
            dtgParts.Columns[27].Visibility = Visibility.Hidden;
            dtgParts.Columns[28].Visibility = Visibility.Hidden;
            dtgParts.Columns[29].Visibility = Visibility.Hidden;
            dtgParts.Columns[30].Visibility = Visibility.Hidden;
            dtgParts.Columns[31].Visibility = Visibility.Hidden;
            dtgParts.Columns[32].Visibility = Visibility.Hidden;
            dtgParts.Columns[33].Header = "Тип запчасти";
            dtgParts.Columns[34].Visibility = Visibility.Hidden;
            dtgParts.Columns[35].Visibility = Visibility.Hidden;
            dtgParts.Columns[36].Header = "Модель";
            dtgParts.Columns[37].Visibility = Visibility.Hidden;
            dtgParts.Columns[38].Visibility = Visibility.Hidden;
            dtgParts.Columns[39].Header = "Бренд";
            dtgParts.Columns[40].Header = "Количество";


        }
        //метод заполения выпадающего списка "Поставщики"
        private void _providerFill()
        {
            //Создание экземпляра класса
            DataSetClass dataSetClass = new DataSetClass();
            //создание запроса на выборку данных их таблицы "Поставщики"
            dataSetClass.DataSetFill("select * from [dbo].[Provider]", "Provider", DataSetClass.Function.select, null);
            //Очистка листа
            provider.Clear();
            //Перебор значений и заполнение выпадающего списка соответсвующими значениями столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Provider"].Rows.Count; i++)
            {
                provider.Add(DataSetClass.dataSet.Tables["Provider"].Rows[i][1]);
            }
            cmbProvider.ItemsSource = provider;
        }

        //метод заполения выпадающего списка "ТИп запчасти"
        private void _typeFill()
        {           
            //Создание экземпляра класса

            DataSetClass dataSetClass = new DataSetClass();
            //создание запроса на выборку данных их таблицы "Тип запчасти"
            dataSetClass.DataSetFill("select * from [dbo].[Type_Part]", "Type_Part", DataSetClass.Function.select, null);
            //очистка листа
            type.Clear();
            //Перебор значений и заполнение выпадающего списка соответсвующими значениями столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Type_Part"].Rows.Count; i++)
            {
                type.Add(DataSetClass.dataSet.Tables["Type_Part"].Rows[i][1]);
            }
            cmbType.ItemsSource = type;
        }

        //метод заполения выпадающего списка "Модель"
        private void _modelFill()
        {
            //Создание экземпляра класса
            DataSetClass dataSetClass = new DataSetClass();
            //создание запроса на выборку данных их таблицы "Модель"
            dataSetClass.DataSetFill("select * from [dbo].[Model]", "Model", DataSetClass.Function.select, null);
            //очистка листа
            model.Clear();  
            //Перебор значений и заполнение выпадающего списка соответсвующими значениями столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Model"].Rows.Count; i++)
            {
                model.Add(DataSetClass.dataSet.Tables["Model"].Rows[i][1]);
            }
            cmbModel.ItemsSource = model;
        }

        //метод заполения выпадающего списка "Бренд"
        private void _brendFill()
        {
            //Создание экземпляра класса
            DataSetClass dataSetClass = new DataSetClass();
            //создание запроса на выборку данных их таблицы "Бренд"
            dataSetClass.DataSetFill("select * from [dbo].[Brand]", "Brand", DataSetClass.Function.select, null);
            //очистка листа
            brand.Clear();
            //Перебор значений и заполнение выпадающего списка соответсвующими значениями столбца
            for (int i = 0; i < DataSetClass.dataSet.Tables["Brand"].Rows.Count; i++)
            {
                brand.Add(DataSetClass.dataSet.Tables["Brand"].Rows[i][1]);
            }
            cmbBrend.ItemsSource = brand;
        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _partsfill();

            _typeFill();
            _providerFill();
            _modelFill();
            _brendFill();
        }
    }
}

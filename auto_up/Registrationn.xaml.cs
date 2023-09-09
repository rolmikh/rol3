using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registrationn.xaml
    /// </summary>
    public partial class Registrationn : Window
    {
        //запрос на выборку данных из таблицы "Пользователи"
        string qrUser = "select [ID_User],[Email_User],[Login_User],[Password_User],[Role_ID],[ID_Role],[Name_Role] inner join [dbo].[Role] on [Role_ID] = [ID_Role] from [dbo].[User]";
        //создание листа для добавления данных
        ArrayList values = new ArrayList();
        //переменная для роли пользователя
        int role = 3;
        public Registrationn()
        {
            InitializeComponent();
        }
        //переход на авторизацию
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow autorisation = new MainWindow();
            autorisation.Show();
            Close();
        }
        //регистрация
        private void btnAllow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //очистка листа
                values.Clear();
                if(!string.IsNullOrEmpty(txtLogin.Text))
                {
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        if (!string.IsNullOrEmpty(txtPassword.Text))
                        {
                            if(!string.IsNullOrEmpty(txtRepeatPassword.Text))
                            {
                                if (txtPassword.Text == txtRepeatPassword.Text)
                                {
                                    //создание экземпляра класса для работы с БД
                                    DataSetClass dataSetClass = new DataSetClass();
                                    //заполнение данных
                                    values.Add(txtEmail.Text);
                                    values.Add(txtLogin.Text);
                                    values.Add(txtPassword.Text);
                                    values.Add(role);
                                    //запрос на добавление данных
                                    dataSetClass.DataSetFill(qrUser, "User", DataSetClass.Function.insert, values);
                                    //очистка полей
                                    txtLogin.Text = null;
                                    txtEmail.Text = null;
                                    txtPassword.Text = null;
                                    txtRepeatPassword.Text = null;
                                    MessageBox.Show("Регистрация завершена!");
                                    //переход на окно авторизации
                                    MainWindow mainWindow = new MainWindow();
                                    mainWindow.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Ошибка пароля");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Поле 'Повтор пароля' должно быть заполнено");
                                txtRepeatPassword.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Поле 'Пароль' должно быть заполнено");
                            txtPassword.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Поле 'Электронная почта' должно быть заполнено");
                        txtEmail.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'Логин' должно быть заполнено");
                    txtLogin.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            
        }

        

        

    }
}

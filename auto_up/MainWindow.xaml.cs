using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace auto_up
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //переход на окно регистрации
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registrationn registrationn = new Registrationn();
            registrationn.Show();
            Close();
        }
        //авторизация пользователя
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //создание экземпляра класса для работы с БД
                DataSetClass dataSet = new DataSetClass();
                //выборка данных из таблицы "ПОльзователь" с вводом логина и пароля
                dataSet.DataSetFill(String.Format("select * from [dbo].[User] where [Login_User] = '{0}' and [Password_User] = '{1}'", txtLogin.Text, txtPassword.Password), "User", DataSetClass.Function.select, null);
                //проверка на наличие записей в таблице
                if (DataSetClass.dataSet.Tables["User"].Rows.Count != 0)
                {
                    //в переменную записываем значения из столбца таблицы
                    int role = Convert.ToInt32(DataSetClass.dataSet.Tables["User"].Rows[0][4]);
                    //если роль = 1 то осущетсвляется переход на окно администратора
                    if (role == 1)
                    {
                        App.Role = 1;
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        Close();
                        MessageBox.Show("Добро пожаловать!");
                        
                    }
                    //если роль = 2 то осущетсвляется переход на окно сотрудника
                    if (role == 2)
                    {
                        App.Role = 2;
                        WorkerWindow workerWindow = new WorkerWindow();
                        workerWindow.Show();
                        Close();
                        MessageBox.Show("Добро пожаловать!");
                       
                    }
                    //если роль = 3 то осущетсвляется переход на окно пользователя
                    if (role == 3)
                    {
                        App.Role = 3;
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        Close();
                        MessageBox.Show("Добро пожаловать!");

                    }

                }
                else
                {
                    MessageBox.Show("Ошибка ввода логина или пароля!");
                    txtLogin.Clear();
                    txtPassword.Clear();
                }
                
            }
            catch
            {
                MessageBox.Show("ОШИБКА!");
            }
            
            
        }
        //событие срабатывающее при открытии окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Объявление экземпляра класса для работы с запросами к конкретной БД
            DataSetClass dataSetClasss = new DataSetClass();
            //Организация переключателя в результате проверки подключения к БД
            switch (dataSetClasss.connection_Checking())
            {

                //Если подключение всё ещё закрыто
                case false:
                    //Запросить пользователя о продолжении настройки строки подключения
                    MessageBox.Show("Подключение не было настроено! Завершить работу приложения?", "Настройка подключения");
                    break;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;       //Пространство имён, необходимое для обращение к классу ArrayList
using System.Windows;
using System.Data;              //Пространство имён для работы с кэш таблицами, строками, столбцами и данными
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_up
{
    class DataSetClass
    {
        
        //Строка подключения
        private SqlConnection connection = new SqlConnection(@"Data Source=KTS\VETA;Initial Catalog=Auto_Shop_Database;Persist Security Info=True;User ID=sa;Password=1505");
        /// Кэш данных в памяти ПК, в котором будут раполагаться DataTable для работы с БД
        public static DataSet dataSet = new DataSet();
        /// Кэш таблица, для вывода данных о пользователях в системе
        private DataTable dtUser = new DataTable("User");
        /// Кэш таблица, для вывода данных о типах контракта в системе
        private DataTable dtType_Contract = new DataTable("Type_Contract");
        /// Кэш таблица, для вывода данных о моделях в системе
        private DataTable dtModel = new DataTable("Model");
        /// Кэш таблица, для вывода данных о бренде в системе
        private DataTable dtBrand = new DataTable("Brand");
        /// Кэш таблица, для вывода данных о типах запчасти в системе
        private DataTable dtType_Part = new DataTable("Type_Part");
        /// Кэш таблица, для вывода данных о типах поставщика в системе
        private DataTable dtType_Provider = new DataTable("Type_Provider");
        /// Кэш таблица, для вывода данных о типах фирмы в системе
        private DataTable dtType_Firm = new DataTable("Type_Firm");
        /// Кэш таблица, для вывода данных о странах в системе
        private DataTable dtCountry = new DataTable("Country");
        /// Кэш таблица, для вывода данных о должностях в системе
        private DataTable dtPost = new DataTable("Post");
        /// Кэш таблица, для вывода данных о поставщиках в системе
        private DataTable dtProvider = new DataTable("Provider");
        /// Кэш таблица, для вывода данных о фирмах в системе
        private DataTable dtFirm = new DataTable("Firm");
        /// Кэш таблица, для вывода данных о фирмах поставщика в системе
        private DataTable dtFirm_Provider = new DataTable("Firm_Provider");
        /// Кэш таблица, для вывода данных о запчастях в системе
        private DataTable dtPart = new DataTable("Part");
        /// Кэш таблица, для вывода данных о складах в системе
        private DataTable dtStoreHouse = new DataTable("StoreHouse");
        /// Кэш таблица, для вывода данных о магазинах в системе
        private DataTable dtStore = new DataTable("Store");
        /// Кэш таблица, для вывода данных о сотрудниках в системе
        private DataTable dtWorker = new DataTable("Worker");
        /// Кэш таблица, для вывода данных о корзине в системе
        private DataTable dtBasket = new DataTable("Basket");
        /// Кэш таблица, для вывода данных о контрактах в системе
        private DataTable dtContract = new DataTable("Contract");
        /// Кэш таблица, для вывода данных о кассе в системе
        private DataTable dtBox_Office = new DataTable("Box_Office");
        /// Кэш таблица, для вывода данных о заказах в системе
        private DataTable dtOrder = new DataTable("Order");
        /// Кэш таблица, для вывода данных о браке в системе
        private DataTable dtDamage = new DataTable("Damage");
        /// Кэш таблица, для вывода данных о составах заявок на покупку товара в системе
        private DataTable dtComposition_Request_Buying = new DataTable("Composition_Request_Buying");
        /// Кэш таблица, для вывода данных о заявках на покупку товара в системе
        private DataTable dtRequest_Buying = new DataTable("Request_Buying");
        /// Кэш таблица, для вывода данных о составах заявок на возврат товара в системе
        private DataTable dtComposition_Request_Return = new DataTable("Composition_Request_Return");
        /// Кэш таблица, для вывода данных о заявках на возврат товара в системе
        private DataTable dtRequest_Return = new DataTable("Request_Return");
        /// Кэш таблица, для вывода данных о составах заявок на заказ товара в системе
        private DataTable dtComposition_Request_Part = new DataTable("Composition_Request_Part");
        /// Кэш таблица, для вывода данных о заявках на заказ товара в магазин в системе
        private DataTable dtRequest_Part = new DataTable("Request_Part");
        /// Колекция определения функции работы с базой данных, где
        /// select - опредяет алгорит выборки и фильтрации данных из базы данных 
        /// insert - определяет алгоритм формирования уникального запроса на добавление данных, без PK
        /// update - определяет алгоритм формирования уникального запроса на изменение данных, все поля таблицы
        /// delete - определяет алгоритм формирования уникального запроса на удаление данных, только PK
        public enum Function { select, insert, update, delete };

        public bool connection_Checking()
        {
            try
            {
                connection.Open();
                    dataSet.Tables.Clear();
                    //Добавление в кэш данных, кэш таблицы "Пользователи"
                    dataSet.Tables.Add(dtUser);
                    //Добавление в кэш данных, кэш таблицы "Тип контракта"
                    dataSet.Tables.Add(dtType_Contract);
                    //Добавление в кэш данных, кэш таблицы "Модель"
                    dataSet.Tables.Add(dtModel);
                    //Добавление в кэш данных, кэш таблицы "Бренд"
                    dataSet.Tables.Add(dtBrand);
                    //Добавление в кэш данных, кэш таблицы "Тип запчасти"
                    dataSet.Tables.Add(dtType_Part);
                    //Добавление в кэш данных, кэш таблицы "Тип поставщика"
                    dataSet.Tables.Add(dtType_Provider);
                    //Добавление в кэш данных, кэш таблицы "Тип фирмы
                    dataSet.Tables.Add(dtType_Firm);
                    //Добавление в кэш данных, кэш таблицы "Страна"
                    dataSet.Tables.Add(dtCountry);
                    //Добавление в кэш данных, кэш таблицы "Должность"
                    dataSet.Tables.Add(dtPost);
                    //Добавление в кэш данных, кэш таблицы "Поставщик"
                    dataSet.Tables.Add(dtProvider);
                    //Добавление в кэш данных, кэш таблицы "Фирма"
                    dataSet.Tables.Add(dtFirm);
                    //Добавление в кэш данных, кэш таблицы "Фирма поставщика"
                    dataSet.Tables.Add(dtFirm_Provider);
                    //Добавление в кэш данных, кэш таблицы "Запчасть
                    dataSet.Tables.Add(dtPart);
                    //Добавление в кэш данных, кэш таблицы "Склад"
                    dataSet.Tables.Add(dtStoreHouse);
                    //Добавление в кэш данных, кэш таблицы "Магазин"
                    dataSet.Tables.Add(dtStore);
                    //Добавление в кэш данных, кэш таблицы "Сотрудник"
                    dataSet.Tables.Add(dtWorker);
                    //Добавление в кэш данных, кэш таблицы "Корзина"
                    dataSet.Tables.Add(dtBasket);
                    //Добавление в кэш данных, кэш таблицы "Контракт"
                    dataSet.Tables.Add(dtContract);
                    //Добавление в кэш данных, кэш таблицы "Касса"
                    dataSet.Tables.Add(dtBox_Office);
                    //Добавление в кэш данных, кэш таблицы "Заказ"
                    dataSet.Tables.Add(dtOrder);
                    //Добавление в кэш данных, кэш таблицы "Брак"
                    dataSet.Tables.Add(dtDamage);
                    //Добавление в кэш данных, кэш таблицы "Состав заявки на покупку товара"
                    dataSet.Tables.Add(dtComposition_Request_Buying);
                    //Добавление в кэш данных, кэш таблицы "Заяква на покупку товара"
                    dataSet.Tables.Add(dtRequest_Buying);
                    //Добавление в кэш данных, кэш таблицы "Состав заявки на возврат товара"
                    dataSet.Tables.Add(dtComposition_Request_Return);
                    //Добавление в кэш данных, кэш таблицы "Заявка на возврат товара"
                    dataSet.Tables.Add(dtRequest_Return);
                    //Добавление в кэш данных, кэш таблицы "Состав заявки на заказ товара в магазин"
                    dataSet.Tables.Add(dtComposition_Request_Part);
                    //Добавление в кэш данных, кэш таблицы "Заявка на заказ товара в магазин"
                    dataSet.Tables.Add(dtRequest_Part);
                
                return true;
            }
            catch (SqlException ex)
            {
                bool b = false;
                if (b != true)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void QueryDG(string SQLQuery, string TableName)
        {
            SqlCommand command = new SqlCommand(SQLQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            dataSet.Tables[TableName].Columns.Clear();
            dataSet.Tables[TableName].Rows.Clear();
            adapter.Fill(dataSet.Tables[TableName]);
        }

        /// Метод работы с любым запросом DML SQL
        /// <param name="SQLQuery">Обязательный запрос на выборку данных</param>
        /// <param name="TableName">Обязательная результирующая таблица</param>
        /// <param name="function">Вид манипуляции select, insert, update, delete</param>
        /// <param name="valueList">Коллекция передаваемых значений, если select то передать null</param>
        public void DataSetFill(string SQLQuery, string TableName, Function function, ArrayList valueList)
        {
            //Создание экземпляра класса Адаптера - включает в себя свойства и методыв по выборке, добавлению, изменению и удалению данных, в конструкторе данный запрос помещается в свойство SelectCommand
            SqlDataAdapter adapter = new SqlDataAdapter(SQLQuery, connection);
            //Создание экземпляра класса кэш таблицы для выборки объектов из базы данных
            DataTable table = new DataTable();
            //Создание экзмепляра класса обработчика SQL команд, для выборки данных об объектах базы данных
            SqlCommand command = new SqlCommand("", connection);
            try
            {
                connection.Open();
                //Отчистка, в кэше данных, у указанной таблицы, столбцов, для избежания аккамулирования столбцов
                dataSet.Tables[TableName].Columns.Clear();
                //Отчистка, в кэше данных, у указанной таблицы, строк, для избежания аккамулирования строк
                dataSet.Tables[TableName].Rows.Clear();
                //Переключатель на выполнение одного из 4 действий
                switch (function)
                {
                    case Function.select:
                        //Заполнение, в кэше данных, указанной таблицы, запросом на выборку данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                    case Function.insert:
                        //Формирование запроса на выборку объектов базы данных, а именно столбцов таблиц, с фильтрацией, где id таблицы равен введённому названию в метод и где поля не имеют свойство is_identity 1, то есть не являются PK
                        command.CommandText = string.Format("select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}') and is_identity <> 1", TableName);
                        //Заполнение кэш таблицы, реузльтатом выборки обектов из БД
                        table.Load(command.ExecuteReader());
                        //Формирование строки запроса на добавление данных в указанную таблицу
                        string insertquery = string.Format("insert into [dbo].[{0}] (", TableName);
                        //Организация цикла, для заполнения названия толбцов в соотвествии с запросом на выборку названий столбцов конкретной таблицы
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            insertquery += string.Format(" [{0}]", table.Rows[i][0]);
                            //Проверка на то, является ли перечисленное поле не последнее в цикле, если да то ставим после названия столбца запятую 
                            if (i < table.Rows.Count - 1)
                                insertquery += ",";
                        }
                        //Дополнение строки запроса на выборку данных, командой values, которая раздеяет область описания столбцов и параметров
                        insertquery += ") values (";
                        //Организация цикла, для заполнения названия параметров к соотвествующим столбцам таблицы, куда будут добавлены данные
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            //Дополнение запроса новыми параметрами
                            insertquery += string.Format(" @{0}", table.Rows[i][0]);
                            //Проверка на то, является ли перечисленный параметр не последнее в цикле, если да то ставим после названия параметра запятую 
                            if (i < table.Rows.Count - 1)
                                insertquery += ",";
                        }
                        //Дополнение запроса на добавление данных, закрывающей скобкой
                        insertquery += ")";
                        //Присвоение полученного запроса в свойство InsertCommand, через инициализацию нового обработчика SQL корманд
                        adapter.InsertCommand = new SqlCommand(insertquery);
                        //Инициализация свойству InsertCommand, свойству Connection экземпляра класса SQLConnection
                        adapter.InsertCommand.Connection = connection;
                        //Принудительная отчистка параметров у свойства InsertCommand, для избежания аккамулирования параметров
                        adapter.InsertCommand.Parameters.Clear();
                        //Организация цикла для присвоения полученного списка значений в параметры запроса на добавление данных
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            //Добавление, в коллекцию свойства InsertCommand, значений в параметры по его названию
                            adapter.InsertCommand.Parameters.AddWithValue(string.Format("@{0}", table.Rows[i][0]), valueList[i]);
                        }
                        //Выполнение вложенного запроса на добавление данных
                        adapter.InsertCommand.ExecuteNonQuery();
                        //Перезапись кэш таблицы, с помощью запроса на выборку данных, для визуального обновления данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                    case Function.update:
                        //Формирование запроса на выборку объектов базы данных, а именно столбцов таблиц, с фильтрацией, где id таблицы равен введённому названию в метод
                        command.CommandText = string.Format("select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}')", TableName);
                        //Заполнение кэш таблицы, реузльтатом выборки обектов из БД
                        table.Load(command.ExecuteReader());
                        //Формирование строки для изменения данных в указанной таблице базы данных
                        string updatequery = string.Format("update [dbo].[{0}] set", TableName);
                        //Организация цикла, для дополнения строки изменения базы данных, с учётом того, что цикл начинается не с 0-ой строки (PK), а с неключевых элементов данных
                        for (int i = 1; i <= table.Rows.Count - 1; i++)
                        {
                            //Дполнение запроса на изменение данных, строкой присвоения к полю таблицы, соответствующего параметра
                            updatequery += string.Format(" {0} = @{0}", table.Rows[i][0]);
                            //Проверка на то, является ли перечисленное поле не последнее в цикле, если да то ставим после названия поля запятую
                            if (i < table.Rows.Count - 1)
                                updatequery += ",";
                        }
                        //Дополнение запроса на изменение данных, условием и присвоением в поле первичного ключа соответствующего параметра
                        updatequery += string.Format(" where {0} = @{0}", table.Rows[0][0]);
                        //Присвоение полученного запроса в свойство UpdateCommand, через инициализацию нового обработчика SQL корманд
                        adapter.UpdateCommand = new SqlCommand(updatequery);
                        //Инициализация свойству UpdateCommand, свойству Connection экземпляра класса SQLConnection
                        adapter.UpdateCommand.Connection = connection;
                        //Принудительная отчистка параметров у свойства UpdateCommand, для избежания аккамулирования параметров
                        adapter.UpdateCommand.Parameters.Clear();
                        //Организация цикла для присвоения полученного списка значений в параметры запроса на изменение данных
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            //Добавление, в коллекцию свойства UpdateCommand, значений в параметры по его названию
                            adapter.UpdateCommand.Parameters.AddWithValue(string.Format("@{0}", table.Rows[i][0]), valueList[i]);
                        }
                        //Выполнение вложенного запроса на изменение данных
                        adapter.UpdateCommand.ExecuteNonQuery();
                        //Перезапись кэш таблицы, с помощью запроса на выборку данных, для визуального обновления данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                    case Function.delete:
                        //Формирование запроса на выборку объектов базы данных, а именно столбцов таблиц, с фильтрацией, где id таблицы равен введённому названию в метод и где поля имеют свойство is_identity 1, то есть являются PK
                        command.CommandText = string.Format("select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}') and is_identity = 1", TableName);
                        //Заполнение кэш таблицы, реузльтатом выборки обектов из БД
                        table.Load(command.ExecuteReader());
                        //Формирование строки запроса на удаление данных из указанной таблицы базы данных
                        string deletequery = string.Format("delete from [dbo].[{0}] where [{1}] = @{1}", TableName, table.Rows[0][0]);
                        //Присвоение полученного запроса в свойство DeleteCommand, через инициализацию нового обработчика SQL корманд
                        adapter.DeleteCommand = new SqlCommand(deletequery);
                        //Инициализация свойству DeleteCommand, свойству Connection экземпляра класса SQLConnection
                        adapter.DeleteCommand.Connection = connection;
                        //Принудительная отчистка параметров у свойства DeleteCommand, для избежания аккамулирования параметров
                        adapter.DeleteCommand.Parameters.Clear();
                        //Добавление в коллекцию свойства DeleteCommand значения с названием параметра для дальнейшего удаления данных
                        adapter.DeleteCommand.Parameters.AddWithValue(string.Format("@{0}", table.Rows[0][0]), valueList[0]);
                        //Выполнение вложенного запроса на удаление данных
                        adapter.DeleteCommand.ExecuteNonQuery();
                        //Перезапись кэш таблицы, с помощью запроса на выборку данных, для визуального обновления данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                }
            }
            catch (SqlException ex)
            {
                //Вывод сообщения об ошибке при работе с базой данных
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                //Закрытие подключения к базе данных
                connection.Close();
            }
        }
    }
}


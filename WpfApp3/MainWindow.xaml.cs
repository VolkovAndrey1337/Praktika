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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.ComponentModel;

namespace WpfApp3
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void select() //Отобразить данные ФИО, группа, возраст
        {
            string tablica = "tablica"; //Имя таблицы
            string ssql = $"SELECT * FROM {tablica} "; //Запрос
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=practica;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {

               fio.Text = reader[1] + " ";
                grupa.Text = reader[2] + " ";
                age.Text = reader[3] + " ";
            }
        }

        void updat() //Изменить данные ФИО, группа, возраст
        {
            string fio1 = fio_Copy.Text;
            string fio2 = fio.Text;
            string ssql = $"UPDATE tablica  SET fio = '{fio1}' WHERE fio = '{fio2}'";

            string group1 = grupa_Copy.Text;
            string group2 = grupa.Text;
            string ssql1 = $"UPDATE tablica SET grupa = '{group1}' WHERE grupa = '{group2}'";

            string age1 = age_Copy.Text;
            string age2 = age.Text;
            string ssql2 = $"UPDATE tablica SET age = '{age1}' WHERE age = '{age2}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=practica;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlCommand command1 = new SqlCommand(ssql1, conn);// Объект вывода запросов
            SqlCommand command2 = new SqlCommand(ssql2, conn);// Объект вывода запросов

            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {

                fio.Text = reader[0] + " ";
                grupa.Text = reader[1] + " ";
                age.Text = reader[2] + " ";
            }
            reader.Close();
            SqlDataReader reader1 = command1.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader1.Read())
            {

                fio.Text = reader1[0] + " ";
                grupa.Text = reader1[1] + " ";
                age.Text = reader1[2] + " ";
            }
            reader1.Close();
            SqlDataReader reader2 = command2.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader2.Read())
            {

                fio.Text = reader2[0] + " ";
                grupa.Text = reader2[1] + " ";
                age.Text = reader2[2] + " ";
            }
            conn.Close();
            MessageBox.Show("Данные изменены!");
            fio_Copy.Text = "";
            grupa_Copy.Text = "";
            age_Copy.Text = "";
            select();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Отобразить данные ФИО, группа, возраст
        {
            select();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)//Изменить данные ФИО, группа, возраст
        {
            updat();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)//Добавить данные дата, задание, оценка
        {
            string data = Data.Text;
            string zadanie = Zadanie.Text;
            string ocenka = Ocenka.Text;
            string ssql = $"INSERT INTO table2 (data,zadanie,ocenka) VALUES ('{data}', '{zadanie}', '{ocenka}')"; //Запрос
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=practica;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            MessageBox.Show("Данные добавлены!");
            Data.Clear();
            Zadanie.Clear();
            Ocenka.Clear();
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())

            {
                Spisok.Text += "Дата: " + reader[0] + " Задание: " + reader[1] + " Оценка: " + reader[2] + "\n";
            }
            reader.Close();
            conn.Close();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)//Отобразить данные дата, задание, оценка
        {
            Spisok.Clear();
            string tablica = "tablica"; //Имя таблицы
            string ssql = $"SELECT * FROM {tablica} "; //Запрос
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=practica;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                Spisok.Text += "Дата: " + reader[0] + " Задание: " + reader[1] + " Оценка: " + reader[2] + "\n";
            }
            reader.Close();
            conn.Close();

            MessageBox.Show("Данные обновлены!");
        }
        private void Button4_Click(object sender, RoutedEventArgs e)//Изменить данные по дате - задание, оценка
        {
            string data = Data.Text;
            string zadanie = Zadanie.Text;
            string ocenka = Ocenka.Text;
            string ssql = $"UPDATE table2 SET zadanie = '{zadanie}' WHERE data = '{data}'"; //Запрос
            string ssql1 = $"UPDATE table2 SET ocenka = '{ocenka}' WHERE data = '{data}'"; //Запрос
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=practica;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                Spisok.Text += "Дата: " + reader[0] + " Задание: " + reader[1] + " Оценка: " + reader[2] + "\n";
            }
            reader.Close();
            SqlCommand command1 = new SqlCommand(ssql1, conn);// Объект вывода запросов
            SqlDataReader reader1 = command1.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader1.Read())
            {
                Spisok.Text += "Дата: " + reader1[0] + " Задание: " + reader1[1] + " Оценка: " + reader1[2] + "\n";
            }
            reader1.Close();
            Data.Clear();
            Zadanie.Clear();
            Ocenka.Clear();
            MessageBox.Show("Данные изменены!");
        }
        private void Button5_Click(object sender, RoutedEventArgs e)//Удалить данные по дате - дата, задание, оценка
        {
            string data = Data.Text;
            string ssql = $"DELETE FROM table2 WHERE data = '{data}'"; //Запрос
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=practica;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                Spisok.Text += "Дата: " + reader[0] + " Задание: " + reader[1] + " Оценка: " + reader[2] + "\n";
            }
            reader.Close();
            Data.Clear();
            MessageBox.Show("Данные Изменены ");
        }

        private void Data_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
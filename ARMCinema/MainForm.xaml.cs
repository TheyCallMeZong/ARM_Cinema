using ARMCinema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ARMCinema
{
    /// <summary>
    /// Структура для хранении информации о месте в зале кинотеатра
    /// </summary>
    public struct Seat
    {
        //Ряд
        public int Row { get; }
        //Место
        public int Place { get; }
        //Конструктор
        public Seat(int _row = 0, int _place = 0)
        {
            Row = _row;
            Place = _place;
        }
    }

    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        /// <summary>
        /// Список,хранящий все фильмы и сериалы.
        /// </summary>
        private List<Show> films = new List<Show>();
        /// <summary>
        /// Индекс выбранного покупателем фильма.
        /// </summary>
        private byte selected_film_index;
        /// <summary>
        /// Индекс сеанса, выбранного покупателем.
        /// </summary>
        private byte selected_session_index;
        /// <summary>
        /// Общая цена всех выбранных билетов.
        /// </summary>
        private int total_price;
        /// <summary>
        /// Общий доход за смену
        /// </summary>
        private double totalIncome;
        /// <summary>
        /// Корзина,куда помещаются выбранные места для покупки билетов.
        /// </summary>
        private List<Seat> basket = new List<Seat>();

        public MainForm(List<Show> shows)
        {
            InitializeComponent();
            films = shows;
            FilmListViewModel f = new FilmListViewModel(films);
            DataContext = f;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            switch (MessageBox.Show(this, "При выходе данные не будут сохранены! Вы действительно хотите выйти?",
                              "Предупреждение!",
                              MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                case MessageBoxResult.No:
                    // Остаемся в этой форме
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void SessionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionList.SelectedIndex != -1)
            {
                selected_session_index = (byte)SessionList.SelectedIndex;
                selected_film_index = (byte)showList.SelectedIndex;
                SessionList.IsEnabled = false; //Делаем недоступным поле с выбором сеанса
                showList.IsEnabled = false;
                print_seatsMatrix(); //Выводим места
            }
        }

        private void print_seatsMatrix()
        {
            SeatsPanelGrid.Children.Clear();
         
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button b = new Button { Content = (j + 1).ToString(), Width = 30, Height = 30 };
                    if (films[selected_film_index].Sessions[selected_session_index].Seats[i][j] == true)
                        b.Background = Brushes.LightGreen;
                    else
                    {
                        b.Background = Brushes.LightGray;
                        b.IsEnabled = false; //Делаем кнопку недоступной для нажатия
                    }
                    b.Foreground = Brushes.Red;
                    SeatsPanelGrid.Children.Add(b);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);

                    if (j == 9)
                    {
                        Label label = new Label();
                        label.Foreground= Brushes.Black;
                        label.Content = (i + 1).ToString();
                        Grid.SetColumn(label, j + 1);
                        Grid.SetRow(label, i);
                        SeatsPanelGrid.Children.Add(label);
                    }
                    b.Name = "B" + i;
                    buttons.Add(b);
                }
            }

            foreach (Button btn in buttons)
            {
                btn.Click += (b, eArgs) =>
                {
                    var button = (Button)b;
                    var columnStr = button.Content.ToString();
                    var rowStr = button.Name.Substring(1);
                    var row = int.Parse(rowStr);
                    var column = int.Parse(columnStr);
                    //Меняем цвет кнопки на желтый и делаем ее недоступной для повторного выбора
                    button.Background = Brushes.Yellow;
                    button.IsEnabled = false;
                    //Выводим выбранное место на basketTextBox
                    BasketBox.AppendText("Добавлен билет: ряд - " + (row + 1) + " ; место - " + (column) + "\r\n");
                    //Добавляем стоимость места к общей стоимости билетов и выводим ее на resultSum
                    total_price += films[selected_film_index].Sessions[selected_session_index].Ticket_price;
                    resultSum.Clear();
                    resultSum.Text = "Общая стоимость: " + total_price.ToString() + " рублей.";
                    basket.Add(new Seat(column - 1, row));
                };
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            returnAll();
        }

        private void returnAll()
        {
            //Очищаем вспомогательные переменные
            selected_film_index = 0;
            selected_session_index = 0;
            total_price = 0;
            //Очищаем все поля
            basket.Clear();
            SeatsPanelGrid.Children.Clear();
            resultSum.Clear();
            BasketBox.Clear();
            //Делаем доступными для выбора поля showList и sessionList
            showList.IsEnabled = true;
            showList.SelectedIndex = -1;
            SessionList.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Проверяем пуста ли корзина. Если пуста - выводим сообщение на экран. Иначе - покупаем билеты.
            if (basket.Count() != 0)
            {
                //Делаем недоступными для дальнейшей продажи все купленные билеты
                foreach (var ticket in basket)
                {
                    films[selected_film_index].Sessions[selected_session_index].sellTicket(ticket.Place, ticket.Row);
                }
                totalIncome += total_price;
                //Создаем форму для печати текста и выводим ее
                CheckForm checkBox = new CheckForm(basket, films, selected_film_index, selected_session_index);
                checkBox.Show();
                //Очищаем все выбранные позиции.
                returnAll();
            }
            else
            {
                MessageBox.Show("Корзина пуста!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //При завершении работы записываем все данные в JSON-документ
            StreamWriter file = File.CreateText("TestWrite.json");

            foreach (Show show in films)
            {
                file.WriteLine(show.serializeShow());
            }
            file.Close();

            MessageBox.Show("Смена закрыта!\nДоход составил: " + totalIncome + " рублей.");
            Environment.Exit(0);
        }
    }
}

using ARMCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ARMCinema
{
    /// <summary>
    /// Логика взаимодействия для CheckForm.xaml
    /// </summary>
    public partial class CheckForm : Window
    {
        public const int sharpCount = 50;
        public CheckForm(List<Seat> basket,
                         List<Show> films,
                         int selected_film_index,
                         int selected_session_index)
        {
            InitializeComponent();
            //Отрисовывем декоративную верхнюю часть чека
            for (int i = 0; i < sharpCount; i++)
                check.Text += "#";
            check.Text += "\r\n#";
            for (int i = 0; i < 47; i++)
            {
                check.Text += " ";
            }
            check.Text += " Чек ";

            for (int i = 0; i < sharpCount - 3; i++)
            {
                check.Text += " ";
            }
            check.Text += "#\r\n";
            for (int i = 0; i < sharpCount; i++)
                check.Text += "#";
            check.Text += "\r\n";

            foreach (var ticket in basket)
            {
                check.Text += ("Название: " + films[selected_film_index].Title + "\r\n");
                check.Text += ("Жанр: " + films[selected_film_index].Genre + "\r\n");
                check.Text += ("Возрастное ограничение: " + films[selected_film_index].Age_limit + "+\r\n");
                check.Text += ("Время сеанса: " + films[selected_film_index].Sessions[selected_session_index].Session_date + "\r\n");
                check.Text += ("Зал: " + films[selected_film_index].Hall + "\r\n");
                check.Text += ("Билет: Ряд: " + (ticket.Place + 1) + " Место: " + (ticket.Row + 1) + "\r\n");
                check.Text += ("Цена билета: " + films[selected_film_index].Sessions[selected_session_index].Ticket_price + "\r\n");
                for (int i = 0; i < sharpCount; i++)
                    check.Text += ("#");
                check.Text += ("\r\n");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

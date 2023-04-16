using System;

namespace ARMCinema.Models
{
    public class Session : ICloneable
    {
        /// <summary>
        /// Цена билета.
        /// </summary>
        public int Ticket_price { get; set; }
        /// <summary>
        /// Дата сеанса.
        /// </summary>
        public DateTime Session_date { get; set; }
        /// <summary>
        /// Матрица мест.
        /// </summary>
        public bool[][] Seats { get; set; } = new bool[10][];
        /// <summary>
        /// Конструктор для Session.
        /// </summary>
        /// <param name="ticket_price"></param>
        /// <param name="session_time"></param>
        //Конструктор без параметров для сериализации
        public Session() { }
        public Session(int ticket_price = 0,
                       DateTime session_time = default(DateTime))
        {
            Session_date = session_time;
            Ticket_price = ticket_price;
            initSeats();
            for (int i = 0; i < 10; i++) // Делаем все места по умолчанию свободными.
                for (int j = 0; j < 10; j++)
                    Seats[i][j] = true;
        }
        public object Clone()
        {
            return new Session { Ticket_price = this.Ticket_price, Session_date = this.Session_date, Seats = this.Seats };
        }
        /// <summary>
        /// Метод устанавливает значение false для выбранного элемента seats.
        /// </summary>
        /// <param name="place"> Место </param> 
        /// <param name="row"> Ряд </param>
        //Создание матрицы мест
        private void initSeats()
        {
            for (int i = 0; i < 10; i++)
                Seats[i] = new bool[10];
        }
        public void sellTicket(int place, int row)
        {
            Seats[place][row] = false;
        }
    }
}

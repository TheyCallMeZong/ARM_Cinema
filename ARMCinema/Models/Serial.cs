using System.Collections.Generic;
using System.Text.Json;

namespace ARMCinema.Models
{
    public class Serial : Show
    {
        /// <summary>
        /// Количество серий в сериале.
        /// </summary>
        public int Count_of_series { get; set; }
        /// <summary>
        /// Длительность сеанса в минутах.
        /// </summary>
        public int Serial_duration { get; set; }
        /// <summary>
        /// Массив сеансов.
        /// Количество сериалов по умолчанию - 2.
        /// </summary>
        public List<Session> sessions { get; set; } = new List<Session>();
        /// <summary>
        /// Конструктор для Serial.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="age_limit"></param>
        /// <param name="hall"></param>
        /// <param name="count_of_series"></param>
        /// <param name="serial_duration"></param>
        //Конструктор без параметров для сериализации
        public Serial() { }
        public Serial(string title = "",
                      string genre = "",
                      int age_limit = 0,
                      int hall = 0,
                      int count_of_series = 0,
                      int serial_duration = 0,
                      List<Session> session = null) : base(title, genre, age_limit, hall)
        {
            sessions = session;
            Count_of_series = count_of_series;
            Serial_duration = serial_duration;
        }

        public override List<Session> Sessions
        {
            get { return sessions; }
        }
        //Сериализация
        public override string serializeShow()
        {
            return JsonSerializer.Serialize<Serial>(this);
        }
    }
}

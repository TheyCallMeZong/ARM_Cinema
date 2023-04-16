using System.Collections.Generic;
using System.Text.Json;

namespace ARMCinema.Models
{
    public class Film : Show
    {
        /// <summary>
        /// Длительность фильма в минутах.
        /// </summary>
        public int Film_duration { get; set; }
        /// <summary>
        /// Массив сеансов для фильма.
        /// По умолчанию количество сеансов - 5.
        /// </summary>
        public List<Session> sessions { get; set; } = new List<Session>();
        /// <summary>
        /// Конструктор для Film.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="age_limit"></param>
        /// <param name="hall"></param>
        /// <param name="film_duration"></param>
        //Конструктор без параметров для сериализации
        public Film() { }
        public Film(string title = "",
                    string genre = "",
                    int age_limit = 0,
                    int hall = 0,
                    int film_duration = 0,
                    List<Session> session = null) : base(title, genre, age_limit, hall)
        {
            Film_duration = film_duration;
            sessions = session;
        }

        public override List<Session> Sessions
        {
            get { return sessions; }
        }

        //Сериализация
        public override string serializeShow()
        {
            return JsonSerializer.Serialize<Film>(this);
        }
    }
}

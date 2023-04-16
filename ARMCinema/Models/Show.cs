using System.Collections.Generic;

namespace ARMCinema.Models
{
    public abstract class Show
    {
        /// <summary>
        /// Название фильма или сериала.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Жанр фильма или сериала.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Возрастное ограничение фильма или сериала.
        /// </summary>
        public int Age_limit { get; set; }

        /// <summary>
        /// Зал, в котором производится показ.
        /// </summary>
        public int Hall { get; set; }

        /// <summary>
        /// Минимальная цена билета.
        /// </summary>
        public const int minimal_ticket_price = 150;

        /// <summary>
        /// Конструктор для Show.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="age_limit"></param>
        /// <param name="hall"></param>
        //Конструктор без параметров для сериализации
        public Show() { }

        public Show(string title = "",
                    string genre = "",
                    int age_limit = 0,
                    int hall = 0)
        {
            Title = title;
            Genre = genre;
            Age_limit = age_limit;
            Hall = hall;
        }

        /// <summary>
        /// Метод, возвращающий массив сеансов данного фильма или сериала.
        /// </summary>
        public abstract List<Session> Sessions { get; }

        //Сериализация
        public abstract string serializeShow();
    }
}

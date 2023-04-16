using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMCinema.Models
{
    public class FilmListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Show> _films;
        public ObservableCollection<Show> Films
        {
            get { return _films; }
            set
            {
                _films = value;
                OnPropertyChanged("Films");
            }
        }

        private Show _selectedFilm;

        public Show SelectedFilm
        {
            get { return _selectedFilm; }
            set
            {
                _selectedFilm = value;
                OnPropertyChanged("SelectedFilm");
            }
        }

        public FilmListViewModel(List<Show> films)
        {
            Films = new ObservableCollection<Show>(films);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

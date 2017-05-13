using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hiper.Movie.Annotations;

namespace Hiper.Movie.Model
{
    public class NotifyService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
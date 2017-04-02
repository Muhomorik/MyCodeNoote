using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MediaPlayer.Annotations;
using MediaPlayer.Command;

namespace MediaPlayer.ViewModel
{
    public class SubWindowViewModel : INotifyPropertyChanged
    {
        public string Text { get; set; }

        /// <summary>
        /// OK button.
        /// </summary>
        public ICommand CommandSubWindowOk { get; private set; }

        public PlayerViewModel Parent { get; private set; }

        public SubWindowViewModel()
        {
            CommandSubWindowOk = new CommandSubWindowOk(this);

            Text = "My ctor text";
        }

        public SubWindowViewModel(PlayerViewModel parent)
        {
            Parent = parent;
            CommandSubWindowOk = new CommandSubWindowOk(this);

            Text = "My ctor text";
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

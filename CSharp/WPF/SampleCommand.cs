using System;
using System.Windows.Input;
using MediaPlayer.ViewModel;

namespace MediaPlayer.Command
{
    /// <summary>
    /// Sample command handler.
    /// </summary>
    public class SampleCommand :ICommand
    {
        private PlayerViewModel _playerViewModel;

        public SampleCommand(PlayerViewModel playerViewModel)
        {
            this._playerViewModel = playerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _playerViewModel.SomeFile = _playerViewModel.SomeFile + "_!";
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}

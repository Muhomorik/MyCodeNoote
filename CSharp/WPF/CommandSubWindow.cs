using System;
using System.Windows.Input;
using MediaPlayer.ViewModel;
using MediaPlayer.Views;

namespace MediaPlayer.Command
{
    internal class CommandSubWindow : ICommand
    {
        private PlayerViewModel _playerViewModel;

        public CommandSubWindow(PlayerViewModel playerViewModel)
        {
            this._playerViewModel = playerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Open Sub window with VM and content.

            //var win = new SubWindow(_playerViewModel);
            var vm = new SubWindowViewModel(_playerViewModel);

            var win = new SubWindow(vm);
            win.Show();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
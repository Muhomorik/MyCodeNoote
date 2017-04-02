using System;
using System.Windows.Input;
using MediaPlayer.ViewModel;

namespace MediaPlayer.Command
{
    internal class CommandSubWindowOk : ICommand
    {
        private readonly SubWindowViewModel _subWindowViewModel;

        public CommandSubWindowOk(SubWindowViewModel subWindowViewModel)
        {
            this._subWindowViewModel = subWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrWhiteSpace(_subWindowViewModel.Text);
        }

        public void Execute(object parameter)
        {
            _subWindowViewModel.Parent.SomeFile = _subWindowViewModel.Text;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
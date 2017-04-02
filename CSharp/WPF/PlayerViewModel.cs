using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using MediaPlayer.Annotations;
using MediaPlayer.Command;
using MediaPlayer.Helpers;

namespace MediaPlayer.ViewModel
{
    public class PlayerViewModel :INotifyPropertyChanged
    {
        private string _someFile;

        /// <summary>
        /// Some random string.
        /// </summary>
        public string SomeFile
        {
            get { return _someFile; }
            set
            {
                _someFile = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Sample button command.
        /// </summary>
        public ICommand SampleCommand { set; private get; }

        /// <summary>
        /// Pause video.
        /// </summary>
        public ICommand CommandPause { set; private get; }

        /// <summary>
        /// Play video.
        /// </summary>
        public ICommand CommandPlay { set; private get; }

        /// <summary>
        /// Stop video.
        /// </summary>
        public ICommand CommandStop { set; private get; }

        /// <summary>
        /// Open SubWindow command.
        /// </summary>
        public ICommand CommandSubWindow { set; private get; }

        /// <summary>
        /// Show playlist.
        /// </summary>
        public ICommand CommandShowPlaylist { set; private get; }

        /// <summary>
        /// Media player.
        /// </summary>
        private MediaElement _mediaElementObject;

        /// <summary>
        /// Media Player.
        /// </summary>
        public MediaElement MediaElementObject
        {
            get { return _mediaElementObject; }
            set { _mediaElementObject = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Read files in dir and so on.
        /// </summary>
        private DirectoryHelper _dirHelper;

        private ObservableCollection<string> _files; 

        public ObservableCollection<string> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        public PlayerViewModel()
        {
            SampleCommand = new SampleCommand(this);
            CommandPause = new CommandPause(this);
            CommandPlay = new CommandPlay(this);
            CommandStop = new CommandStop(this);
            CommandSubWindow = new CommandSubWindow(this);
            CommandShowPlaylist = new CommandShowPlaylist(this);

            SomeFile = "My ctor file";
            MediaElementObject = new MediaElement();
            MediaElementObject.LoadedBehavior = MediaState.Manual;
            MediaElementObject.Source = new Uri(@"D:\MITCTL3S2016-V006600 [HD, 720p].mp4");

            _dirHelper = new DirectoryHelper();
            Files = new ObservableCollection<string>();

            // try to make it async.
            var dirTask = _dirHelper.GetFilesInDirectoryAsync(Directory.GetCurrentDirectory());
            var res =  dirTask.Result; // TODO: osberv to list. .Result to binding.

            //var res = _dirHelper.GetFilesInDirectory(Directory.GetCurrentDirectory());
            foreach (var item in res)
            {
                Files.Add(item);
            }
        }

        #region OnPropertyChanged.

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
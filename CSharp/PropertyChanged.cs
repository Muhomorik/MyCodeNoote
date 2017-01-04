// Src: http://stackoverflow.com/questions/35582162/how-to-implement-inotifypropertychanged-in-c-sharp-6-0

public event PropertyChangedEventHandler PropertyChanged;
protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

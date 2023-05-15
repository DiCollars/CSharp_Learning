using System.ComponentModel;
using System.Runtime.CompilerServices;
//using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        //public MainViewModel()
        //{
        //    Task.Factory.StartNew(() =>
        //    {
        //        while (true)
        //        {
        //            Task.Delay(1000).Wait();

        //            Clicks++;
        //        }
        //    });
        //}

        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Clicks++;
                }, (obj) => Clicks < 10);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private int _clicks;
        public int Clicks
        {
            get
            {
                return _clicks;
            }
            set
            {
                _clicks = value;
                OnPropertyChanged();
            }
        }
    }
}

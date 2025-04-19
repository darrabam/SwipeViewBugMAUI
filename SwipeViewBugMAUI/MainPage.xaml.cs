using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SwipeViewBugMAUI
{
    public class NumberItem : INotifyPropertyChanged
    {
        int value;
        public int Value
        {
            get => value;
            set { this.value = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<NumberItem> Numbers { get; set; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public MainPage()
        {
            InitializeComponent();

            Numbers = new ObservableCollection<NumberItem>
        {
            new NumberItem { Value = 1 },
            new NumberItem { Value = 5 },
            new NumberItem { Value = 10 }
        };

            IncrementCommand = new Command<NumberItem>((item) => item.Value++);
            DecrementCommand = new Command<NumberItem>((item) => item.Value--);

            BindingContext = this;
        }
    }
}

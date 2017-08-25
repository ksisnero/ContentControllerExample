using DevExpress.Mvvm;
using Example_2._0.ViewModels;

namespace Example_2._0
{
    public class MainWindowViewModel : ViewModelBase 
    {
        public virtual IntroWindowViewModel IWindow { get; set; }

        public virtual SuspectWindowViewModel SWindow { get; set; }

        public virtual WindowOrganizer WindowSet { get; set; }

        public MainWindowViewModel()
        {
            IWindow = new IntroWindowViewModel();

            SWindow = new SuspectWindowViewModel();

            WindowSet = WindowOrganizer.Create(IWindow);
        }
    }
}

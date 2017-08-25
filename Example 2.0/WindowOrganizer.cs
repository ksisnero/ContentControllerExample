using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;

namespace Example_2._0
{
    public class WindowOrganizer
    {
        public virtual List<ViewModelBase> WindowList { get; set; }
        public virtual int CurrentWindowListIndex { get; set; }

        public virtual ViewModelBase PreviousWindow { get; set; }
        public virtual ViewModelBase CurrentWindow { get; set; }
        public virtual ViewModelBase NextWindow { get; set; }

        public WindowOrganizer(ViewModelBase firstWindow)
        {

            WindowList = new List<ViewModelBase>();
            CurrentWindowListIndex = 0;

            PreviousWindow = null;
            CurrentWindow = firstWindow;
            NextWindow = null;

            WindowList.Insert(CurrentWindowListIndex, CurrentWindow);
        }

        public virtual void TransitionTo(ViewModelBase newWindow)
        {
            PreviousWindow = CurrentWindow;
            CurrentWindow = newWindow;

            CurrentWindowListIndex++;

            for (int i = CurrentWindowListIndex; i < WindowList.Count; i++)
                WindowList.RemoveRange(i, WindowList.Count - i);

            WindowList.Add(CurrentWindow);
        }

        public static WindowOrganizer Create(ViewModelBase firstPage)
        {
            return ViewModelSource.Create(() => new WindowOrganizer(firstPage));
        }
    }
}

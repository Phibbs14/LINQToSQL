using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _415Project.ViewModels
{
    class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaiseProeprtyChanged(string pName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(pName));
        }
    }
}

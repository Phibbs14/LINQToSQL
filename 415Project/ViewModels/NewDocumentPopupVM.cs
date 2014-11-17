using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _415Project.ViewModels
{
    class NewDocumentPopupVM : BaseVM
    {
        private bool saveDocument;
        public bool SaveDocument
        {
            get { return saveDocument; }
            set
            {
                saveDocument = value;
                RaiseProeprtyChanged("SaveDocument");
            }
        }

        private readonly DAL.Document newDocument = new DAL.Document();
        public DAL.Document Document
        {
            get { return newDocument; }
        }

        
        public ICommand SaveCommand
        {
            get 
            { 
                return new GenericCommand(
                    (x) => { SaveDocument = true; Close(x as Window); },
                    (x) => { return Helper.IsValid(x as Window); }
                ); 
            }
        }

        public ICommand CancelCommand
        {
            get { return new GenericCommand((x) => { SaveDocument = false; Close(x as Window); }); }
        }

        private void Close(Window popup)
        {
            if (popup != null)
                popup.Close();
        }
    }
}

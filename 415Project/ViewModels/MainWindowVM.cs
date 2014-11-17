using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _415Project.ViewModels
{
    class MainWindowVM : BaseVM
    {
        private QueryVM query = new QueryVM();
        public QueryVM Query { get { return query; } }

        private IList<DAL.Document> matchedDocuments;
        public IList<DAL.Document> MatchedDocuments
        {
            get
            {
                return matchedDocuments;
            }
            set
            {
                matchedDocuments = value;
                RaiseProeprtyChanged("MatchedDocuments");
            }
        }

        private bool showWeights;
        public bool ShowWeights
        {
            get { return showWeights; }
            set
            {
                showWeights = value;
                RaiseProeprtyChanged("ShowWeights");
            }
        }

        public ICommand GetMatchedDocumentsCommand
        {
            get 
            { 
                return new GenericCommand((x) => GetMatchedDocuments(), 
                                            (x) => { return Helper.IsValid(x as System.Windows.DependencyObject); }
                                         );  
            }
        }

        public ICommand ClearMatchedDocumentsCommand
        {
            get { return new GenericCommand(ClearMatchedDocuments); }
        }

        public ICommand NewDocumentCommand
        {
            get { return new GenericCommand(DisplayNewDocumentWindow); }
        }

        private void GetMatchedDocuments()
        {
            MatchedDocuments = DAL.DatabaseAccess.GetMatchingDocuments(Query);
        }

        private void ClearMatchedDocuments()
        {
            MatchedDocuments = null;
            Query.Reset();
        }

        private void DisplayNewDocumentWindow()
        {
            NewDocumentPopupVM vm = new NewDocumentPopupVM();
            Views.NewDocumentPopup popup = new Views.NewDocumentPopup() { DataContext = vm, Owner = App.Current.MainWindow };
            popup.ShowDialog();
            if (vm.SaveDocument)
            {
                DAL.DatabaseAccess.AddDocument(vm.Document);
                if (vm.Document.Id > 0)
                    MessageBox.Show("The document has been added with ID " + vm.Document.Id);
            }
        }
    }
}

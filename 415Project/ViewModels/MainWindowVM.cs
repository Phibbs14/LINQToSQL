using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _415Project.ViewModels
{
    class MainWindowVM : BaseVM
    {
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

        public ICommand GetMatchedDocumentsCommand
        {
            get { return new GenericCommand(GetMatchedDocuments);  }
        }

        public ICommand ClearMatchedDocumentsCommand
        {
            get { return new GenericCommand(ClearMatchedDocuments, delegate { return MatchedDocuments != null; }); }
        }

        private void GetMatchedDocuments(object param)
        {
            MatchedDocuments = DAL.DatabaseAccess.GetAllDocuments();
        }

        private void ClearMatchedDocuments(object param)
        {
            MatchedDocuments = null;
        }
    }
}

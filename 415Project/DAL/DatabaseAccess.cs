using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _415Project.DAL
{
    class DatabaseAccess : DataContext
    {
        public Table<Document> Documents;
        public DatabaseAccess() : base(Properties.Settings.Default.dbConnection)
        {
            
        }

        public void TestInsert()
        {
            var t = this.GetTable(typeof(Document));
            
            Documents.InsertOnSubmit(new Document());
            this.SubmitChanges();
        }

        // Retrieve matching Docs
        // Add a document

        public static void AddDocument(Document doc)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            dbAccess.Documents.InsertOnSubmit(doc);
            dbAccess.SubmitChanges();
        }

        public static IList<Document> GetAllDocuments()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            return new List<Document>(from d in dbAccess.Documents select d);
        }
    }
}

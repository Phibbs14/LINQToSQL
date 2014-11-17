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

        public static IList<Document> GetMatchingDocuments(ViewModels.QueryVM query)
        {
            // Poor performance, but looks better then writing out the entire select in linq
            var list = GetAllDocuments();
            
            return list.OrderByDescending((x) => x.CalculateWeight(query)).ToList();
        }

        //internal static void Generate()
        //{
        //    Random r = new Random();
        //    r.Next(0, 10);
        //    for (int i = 0; i < 40; ++i)
        //        AddDocument(new Document()
        //            {
        //                Term1 = r.Next(0, 10),
        //                Term2 = r.Next(0, 10),
        //                Term3 = r.Next(0, 10),
        //                Term4 = r.Next(0, 10),
        //                Term5 = r.Next(0, 10),
        //                Term6 = r.Next(0, 10),
        //                Term7 = r.Next(0, 10),
        //                Term8 = r.Next(0, 10),
        //                Term9 = r.Next(0, 10),
        //                Term10 = r.Next(0, 10),
        //            });
        //}
    }
}

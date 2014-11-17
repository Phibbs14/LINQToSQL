using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _415Project.DAL
{
    [Table(Name="Documents")]
    public class Document : IEnumerable<Tuple<int,int>>, IDataErrorInfo, ViewModels.Weighted
    {
        // Documents have weightings for 10 terms
        // A better scenerio would be an unlimited amount of terms
        //  meaning a Documents table and a weighting table, which would 
        //  allow a single list of term weightings instead of all these properties

        [Column(IsPrimaryKey=true, IsDbGenerated=true)]
        public int Id { get; set; }

        [Column]
        public int Term1 { get; set; }
        
        [Column]
        public int Term2 { get; set; }

        [Column]
        public int Term3 { get; set; }
        
        [Column]
        public int Term4 { get; set; }

        [Column]
        public int Term5 { get; set; }

        [Column]
        public int Term6 { get; set; }

        [Column]
        public int Term7 { get; set; }

        [Column]
        public int Term8 { get; set; }

        [Column]
        public int Term9 { get; set; }

        [Column]
        public int Term10 { get; set; }

        public double Weight { get; set; }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get 
            {
                if (!columnName.StartsWith("Term"))
                    return null;
                int value = (int)typeof(Document).GetProperty(columnName).GetValue(this);
                if (value < 0 || value > 10)
                    return "Weighting must be between 1 and 10";
                return null;
            }
        }

        public IEnumerator<Tuple<int, int>> GetEnumerator()
        {
            return new DocumentEnumerator(this, 1, 10);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class DocumentEnumerator : IEnumerator<Tuple<int,int>>
        {
            private int currentPropertyNum;
            private int max;
            private int min;
            private Document document;

            public DocumentEnumerator(Document doc, int min, int max)
            {
                document = doc;
                this.min = min;
                this.max = max;
            }

            public Tuple<int, int> Current
            {
                get { return GetCurrent(); }
            }

            private Tuple<int,int> GetCurrent()
            {
                try
                {
                    PropertyInfo p = typeof(Document).GetProperty("Term" + currentPropertyNum);
                    return new Tuple<int,int>((int)p.GetValue(document), currentPropertyNum);
                }
                catch { return null; }
            }

            public void Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                currentPropertyNum++;
                if (currentPropertyNum > max)
                    return false;
                return true;
            }

            public void Reset()
            {
                currentPropertyNum = min;
            }
        }

        internal double CalculateWeight(ViewModels.QueryVM query)
        {
            double sum = (from i in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } 
                          select ViewModels.Helper.GetTermWeight(i, this) * ViewModels.Helper.GetTermWeight(i, query)
                          ).Sum();
            double docWeight = Math.Sqrt((from i in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                                select Math.Pow(ViewModels.Helper.GetTermWeight(i, this), 2)
                          ).Sum());
            double queryWeight = Math.Sqrt((from i in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                                          select Math.Pow(ViewModels.Helper.GetTermWeight(i, query), 2)
                          ).Sum()); // Could save weight
            double denominator = docWeight * queryWeight;
            return Weight = denominator == 0 ? 0 : sum / denominator;
        }
    }
}

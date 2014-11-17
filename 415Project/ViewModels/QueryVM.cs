using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _415Project.ViewModels
{
    class QueryVM : BaseVM, IDataErrorInfo, Weighted
    {
        // Might be a way to put these in a list later on

        private int term1;
        public int Term1
        {
            get { return term1; }
            set
            {
                term1 = value;
                RaiseProeprtyChanged("Term1");
            }
        }
        private int term2;
        public int Term2
        {
            get { return term2; }
            set
            {
                term2 = value;
                RaiseProeprtyChanged("Term2");
            }
        }
        private int term3;
        public int Term3
        {
            get { return term3; }
            set
            {
                term3 = value;
                RaiseProeprtyChanged("Term3");
            }
        }
        private int term4;
        public int Term4
        {
            get { return term4; }
            set
            {
                term4 = value;
                RaiseProeprtyChanged("Term4");
            }
        }
        private int term5;
        public int Term5
        {
            get { return term5; }
            set
            {
                term5 = value;
                RaiseProeprtyChanged("Term5");
            }
        }
        private int term6;
        public int Term6
        {
            get { return term6; }
            set
            {
                term6 = value;
                RaiseProeprtyChanged("Term6");
            }
        }
        private int term7;
        public int Term7
        {
            get { return term7; }
            set
            {
                term7 = value;
                RaiseProeprtyChanged("Term7");
            }
        }
        private int term8;
        public int Term8
        {
            get { return term8; }
            set
            {
                term8 = value;
                RaiseProeprtyChanged("Term8");
            }
        }
        private int term9;
        public int Term9
        {
            get { return term9; }
            set
            {
                term9 = value;
                RaiseProeprtyChanged("Term9");
            }
        }
        private int term10;
        public int Term10
        {
            get { return term10; }
            set
            {
                term10 = value;
                RaiseProeprtyChanged("Term10");
            }
        }

        public void Reset()
        {
            for (int i = 1; i <= 10; ++i)
                typeof(QueryVM).GetProperty("Term" + i).SetValue(this, 0);
        }

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
                int value = (int)typeof(QueryVM).GetProperty(columnName).GetValue(this);
                if (value < 0 || value > 10)
                    return "Weighting must be between 1 and 10";
                return null;
            }
        }
    }
}

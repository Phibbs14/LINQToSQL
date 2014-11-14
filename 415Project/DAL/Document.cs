using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _415Project.DAL
{
    [Table(Name="Documents")]
    public class Document
    {
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
    }
}

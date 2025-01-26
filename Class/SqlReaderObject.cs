using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List_List
{
    public class SqlReaderObject
    {
        public HashSet<string> Nome { get; set; }
        public HashSet<string> Concluidp { get; set; }
        public HashSet<string> Categoria { get; set; }


        public SqlReaderObject()
        {
            Nome = new HashSet<string>();
            Concluidp = new HashSet<string>();
            Categoria = new HashSet<string>();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List_List
{
    public class SqlReaderObject
    {
        public string[] Nome { get; set; }
        public string[] Concluidp { get; set; }
        public string[] Categoria { get; set; }

        public SqlReaderObject()
        {
            Nome = new string[100];
            Concluidp = new string[100];
            Categoria = new string[100];
        }
    }
}

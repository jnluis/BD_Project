using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBD
{
    public class BDConnection
    {
        private string user = "p4g5";
        private string password = "GrupoBD123.";

        public SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;User ID=" + this.user + ";Password=" + this.password);
        }
    }
}

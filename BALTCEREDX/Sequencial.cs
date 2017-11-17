using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace BLLTCEREDX
{
    public class Sequencial
    {


        public void ImportarSequencial2(string strFileName)
        {
            const int maxInvoiceLength = 10;
            string fileName = strFileName;
            string dir = Path.GetDirectoryName(fileName);

            DataTable dataTable;

            using (OleDbConnection conn =
                new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;" +
                    "Data Source=" + dir + ";" +
                    "Extended Properties=\"Text;\""))
            {
                conn.Open();

                //    string query = String.Format("SELECT RecordTypeSCFBody, LEFT(InvoiceNumber + SPACE({0}), {0}), Amount FROM {1}", maxInvoiceLength, fileName);
                string query = "select * from " + strFileName;
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                }
            }
        }


        public void ImportarSequencial(string strFileName)
        {
            string dir = Path.GetDirectoryName(strFileName);

            string fileName = string.Format("{0}", AppDomain.CurrentDomain.BaseDirectory);
            
            string connectionString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; " 
+ "Extended Properties=\"text;", fileName);

            const int maxInvoiceLength = 10;

//            string query = String.Format("SELECT RecordTypeSCFBody, LEFT(Numero + SPACE({0}), {0}), Dv FROM {1}", maxInvoiceLength, strFileName);


            string sql = "select * from " + strFileName;

            OleDbConnection cn = new OleDbConnection(connectionString);
            cn.Open();

            OleDbDataAdapter dap = new OleDbDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            dt.TableName = "Sequencial";
            dap.Fill(dt);

            cn.Close();

        }

    }

    }


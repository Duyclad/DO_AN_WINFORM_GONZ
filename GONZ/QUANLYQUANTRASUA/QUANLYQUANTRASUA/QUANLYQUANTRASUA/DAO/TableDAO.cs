using QUANLYQUANTRASUA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYQUANTRASUA.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance { get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; } private set => instance = value; }

        public static int TableWidth = 100;

        public static int TableHeight = 100;

        private TableDAO() { }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);

            }

            return tableList;

        }
        public bool InsertTable(string name)
        {
            string query = string.Format("INSERT dbo.TableFood ( name )VALUES  ( N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTable(int idTable, string name, string status)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name = N'{0}', status = N'{1}' WHERE id = {2}", name, status, idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int idTable)
        {
            //BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);
            //BillInfoDAO.Instance.DeleteBillInfoByTableID(idTable);
            BillDAO.Instance.DeleteBillByTableID(idTable);
            string query = string.Format("Delete dbo.TableFood where id = {0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        
    }
}

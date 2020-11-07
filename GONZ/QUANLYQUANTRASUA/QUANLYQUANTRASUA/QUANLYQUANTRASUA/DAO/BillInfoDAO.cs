﻿using QUANLYQUANTRASUA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYQUANTRASUA.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance { get{ if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; } private set => instance = value; }

        public object Datatable { get; private set; }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo (int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from BillInfo where idBill = "+ id);

            foreach(DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        /* internal void DeleteBillInfoByFoodID(int idFood)
         {
             throw new NotImplementedException();
         }*/


        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfo WHERE idFood = " + id);
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }

        
    }
}
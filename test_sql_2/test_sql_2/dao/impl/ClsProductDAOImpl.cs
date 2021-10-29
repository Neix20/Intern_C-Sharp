using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

using test_sql_2.models;
using test_sql_2.factory;

namespace test_sql_2.dao.impl
{
    public class ClsProductDAOImpl : ClsProductDAO
    {
        string table_name = "TShopeeProduct";

        public void addClsData(ClsProduct cp)
        {
            throw new NotImplementedException();
        }

        public void deleteAllRecords()
        {
            throw new NotImplementedException();
        }

        public void deleteClsData(int product_transaction_id)
        {
            throw new NotImplementedException();
        }

        public ClsProduct findByProductNameAndProductVariety(string product_name, string product_variety)
        {
            throw new NotImplementedException();
        }

        public ClsProduct findClsData(int product_transaction_id)
        {
            throw new NotImplementedException();
        }

        public IList<ClsProduct> getAllClsData()
        {
            SqlConnection conn = new SqlConnection(clsConst.SysDBConnString());
            conn.Open();

            SqlCommand command = new SqlCommand($"dbo.NSP_{table_name}_SelectAll", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter();
            Param.ParameterName = "@product_transaction_id";
            Param.SqlDbType = SqlDbType.NVarChar;
            Param.Direction = ParameterDirection.Input;
            Param.Value = "-1";
            command.Parameters.Add(Param);

            SqlDataReader SQLReader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(SQLReader);

            // Convert DataTable to List<ClsProduct>
            IList<ClsProduct> clsProductList = new List<ClsProduct>();
            clsProductList = (from DataRow dr in dt.Rows
                              select new ClsProduct() {
                                  product_transaction_id = Convert.ToInt32(dr["product_transaction_id"]),
                                  product_id = dr["product_id"].ToString(),
                                  product_name = dr["product_name"].ToString(),
                                  product_variety = dr["product_variety"].ToString(),
                                  product_stock_quantity = Convert.ToInt32(dr["product_stock_quantity"]),
                                  product_unit_price = Convert.ToDouble(dr["product_unit_price"])
                              }).ToList();

            SQLReader.Close();
            conn.Close();

            return clsProductList;
        }

        public void updateClsData(ClsProduct cp)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;

using test_sql_2.models;
using test_sql_2.factory;
using test_sql_2.dao.impl;

namespace test_sql_2
{
    class Program
    {
        static void Main(string[] args)
        {

            ClsProductDAOImpl productDao = (new SqlConnectionFactory()).getClsProductDAO();

            IList<ClsProduct> clsProductList = productDao.getAllClsData();

            clsProductList.Select(x => x.product_name).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine(clsProductList.Count());
            Console.ReadLine();
        }
    }
}

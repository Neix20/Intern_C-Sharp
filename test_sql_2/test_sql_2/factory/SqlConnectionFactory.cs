using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using test_sql_2.dao.impl;

namespace test_sql_2.factory
{
    public class SqlConnectionFactory
    {

        public ClsProductDAOImpl getClsProductDAO()
        {
            return new ClsProductDAOImpl();
        }
    }
}
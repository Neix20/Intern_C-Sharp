using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_sql_2.models;

namespace test_sql_2.dao
{
    interface ClsProductDAO
    {
        IList<ClsProduct> getAllClsData();
        ClsProduct findClsData(int product_transaction_id);
        ClsProduct findByProductNameAndProductVariety(string product_name, string product_variety);
        void addClsData(ClsProduct cp);
        void updateClsData(ClsProduct cp);
        void deleteClsData(int product_transaction_id);
        void deleteAllRecords();
    }
}

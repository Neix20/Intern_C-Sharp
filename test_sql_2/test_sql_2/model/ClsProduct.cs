using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_sql.model
{
    public class ClsProduct
    {
        public int product_transaction_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string product_variety { get; set; }
        public int product_stock_quantity { get; set; }
        public double product_unit_price { get; set; }

        public override bool Equals(Object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            ClsProduct other = (ClsProduct)obj;
            return string.Equals(product_name, other.product_name) && string.Equals(product_variety, other.product_variety);
        }
    }
}
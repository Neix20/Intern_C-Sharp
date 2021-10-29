﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopeeAutomationUserInterface.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbJavaSeleniumShopeeBuyer : DbContext
    {
        public dbJavaSeleniumShopeeBuyer()
            : base("name=dbJavaSeleniumShopeeBuyer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TShopeeBuyer> TShopeeBuyers { get; set; }
    
        public virtual int NSP_TShopeeBuyer_Delete(Nullable<int> buyer_id)
        {
            var buyer_idParameter = buyer_id.HasValue ?
                new ObjectParameter("buyer_id", buyer_id) :
                new ObjectParameter("buyer_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NSP_TShopeeBuyer_Delete", buyer_idParameter);
        }
    
        public virtual int NSP_TShopeeBuyer_Insert(string buyer_username, string buyer_name, string buyer_mobile_phone)
        {
            var buyer_usernameParameter = buyer_username != null ?
                new ObjectParameter("buyer_username", buyer_username) :
                new ObjectParameter("buyer_username", typeof(string));
    
            var buyer_nameParameter = buyer_name != null ?
                new ObjectParameter("buyer_name", buyer_name) :
                new ObjectParameter("buyer_name", typeof(string));
    
            var buyer_mobile_phoneParameter = buyer_mobile_phone != null ?
                new ObjectParameter("buyer_mobile_phone", buyer_mobile_phone) :
                new ObjectParameter("buyer_mobile_phone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NSP_TShopeeBuyer_Insert", buyer_usernameParameter, buyer_nameParameter, buyer_mobile_phoneParameter);
        }
    
        public virtual ObjectResult<NSP_TShopeeBuyer_SelectAll_Result> NSP_TShopeeBuyer_SelectAll(Nullable<int> buyer_id)
        {
            var buyer_idParameter = buyer_id.HasValue ?
                new ObjectParameter("buyer_id", buyer_id) :
                new ObjectParameter("buyer_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NSP_TShopeeBuyer_SelectAll_Result>("NSP_TShopeeBuyer_SelectAll", buyer_idParameter);
        }
    
        public virtual ObjectResult<NSP_TShopeeBuyer_SelectByPK_Result> NSP_TShopeeBuyer_SelectByPK(Nullable<int> buyer_id)
        {
            var buyer_idParameter = buyer_id.HasValue ?
                new ObjectParameter("buyer_id", buyer_id) :
                new ObjectParameter("buyer_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NSP_TShopeeBuyer_SelectByPK_Result>("NSP_TShopeeBuyer_SelectByPK", buyer_idParameter);
        }
    
        public virtual ObjectResult<NSP_TShopeeBuyer_SelectByUserName_Result> NSP_TShopeeBuyer_SelectByUserName(string buyer_username)
        {
            var buyer_usernameParameter = buyer_username != null ?
                new ObjectParameter("buyer_username", buyer_username) :
                new ObjectParameter("buyer_username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NSP_TShopeeBuyer_SelectByUserName_Result>("NSP_TShopeeBuyer_SelectByUserName", buyer_usernameParameter);
        }
    
        public virtual int NSP_TShopeeBuyer_Update(Nullable<int> buyer_id, string buyer_username, string buyer_name, string buyer_mobile_phone)
        {
            var buyer_idParameter = buyer_id.HasValue ?
                new ObjectParameter("buyer_id", buyer_id) :
                new ObjectParameter("buyer_id", typeof(int));
    
            var buyer_usernameParameter = buyer_username != null ?
                new ObjectParameter("buyer_username", buyer_username) :
                new ObjectParameter("buyer_username", typeof(string));
    
            var buyer_nameParameter = buyer_name != null ?
                new ObjectParameter("buyer_name", buyer_name) :
                new ObjectParameter("buyer_name", typeof(string));
    
            var buyer_mobile_phoneParameter = buyer_mobile_phone != null ?
                new ObjectParameter("buyer_mobile_phone", buyer_mobile_phone) :
                new ObjectParameter("buyer_mobile_phone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NSP_TShopeeBuyer_Update", buyer_idParameter, buyer_usernameParameter, buyer_nameParameter, buyer_mobile_phoneParameter);
        }
    }
}
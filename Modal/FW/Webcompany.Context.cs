﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_congty.Modal.FW
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Web_companyEntities : DbContext
    {
        public Web_companyEntities()
            : base("name=Web_companyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About_custommers> About_custommers { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<FechBack_Cus> FechBack_Cus { get; set; }
        public virtual DbSet<Information_company> Information_company { get; set; }
        public virtual DbSet<Introduction> Introduction { get; set; }
        public virtual DbSet<Maketting> Maketting { get; set; }
        public virtual DbSet<Partner_DT> Partner_DT { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Post_user> Post_user { get; set; }
        public virtual DbSet<Project_system> Project_system { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<SoftWare_Case> SoftWare_Case { get; set; }
        public virtual DbSet<tbl_Uers> tbl_Uers { get; set; }
        public virtual DbSet<tbl_Register_Software_Client> tbl_Register_Software_Client { get; set; }
    
        public virtual ObjectResult<f__Count_post_Result> f__Count_post()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<f__Count_post_Result>("f__Count_post");
        }
    
        public virtual ObjectResult<Binhlan_phanmem_Result> Binhlan_phanmem()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Binhlan_phanmem_Result>("Binhlan_phanmem");
        }
    
        public virtual ObjectResult<Binhluan_blog_Result> Binhluan_blog()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Binhluan_blog_Result>("Binhluan_blog");
        }
    
        public virtual ObjectResult<Client_register_now_software_Result> Client_register_now_software()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Client_register_now_software_Result>("Client_register_now_software");
        }
    
        public virtual ObjectResult<DANH_MUC_Result> DANH_MUC()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DANH_MUC_Result>("DANH_MUC");
        }
    
        public virtual ObjectResult<list_comment_Result> list_comment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<list_comment_Result>("list_comment");
        }
    
        public virtual ObjectResult<List_reply_comment_Result> List_reply_comment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<List_reply_comment_Result>("List_reply_comment");
        }
    }
}
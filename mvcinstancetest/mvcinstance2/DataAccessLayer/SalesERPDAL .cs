using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using mvcinstance2.Models;
namespace mvcinstance2.DataAccessLayer
{
    public class SalesERPDAL:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);

        }
        //public SalesERPDAL():base("NewName")
        //{
        //}
    }
}
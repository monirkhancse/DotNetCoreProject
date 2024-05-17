using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProject.Models;

namespace DotNetCoreProject.Models
{
    public class ApplicationDbContext: IdentityDbContext
    {
        private readonly DbContextOptions _options;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }    
        public DbSet<Item> items { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Designation> designations { get; set; }
        public DbSet<DotNetCoreProject.Models.EmpLedgerTitle> EmpLedgerTitle { get; set; }
        public DbSet<DotNetCoreProject.Models.EmployeeLedger> EmployeeLedger { get; set; }

        //public IQueryable<Employee> SearchCustomers(string FirstName)
        //{
        //    SqlParameter firstName = new SqlParameter("@FirstName", FirstName);
        //    return customers.FromSqlRaw("EXECUTE sp_GetCustomerID @FirstName", firstName);
        //}
        //public void InsertCustomer(Employee customer)
        //{
        //    SqlParameter customerID = new SqlParameter("@CustomerID", customer.CustomerID);
        //    SqlParameter firstName = new SqlParameter("@FirstName", customer.FirstName);
        //    SqlParameter lastName = new SqlParameter("@LastName", customer.LastName);
        //    SqlParameter email = new SqlParameter("@Email", customer.Email);
        //    SqlParameter phoneNumber = new SqlParameter("@PhoneNumber", customer.PhoneNumber);
        //    Database.ExecuteSqlRaw("EXECUTE sp_InsertCustomer @CustomerID,@FirstName,@LastName,@Email,@PhoneNumber", customerID, firstName, lastName, email, phoneNumber);
        //}
        //public void DeleteCustomer(int id)
        //{
        //    SqlParameter customerID = new SqlParameter("@CustomerID", id);
        //    Database.ExecuteSqlRaw("EXECUTE sp_DeleteCustomer @CustomerId", customerID);
        //}
    }
}

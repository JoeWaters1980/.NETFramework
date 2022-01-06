using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Solution_Banking_.Models;

namespace Solution_Banking_
{
    public class AccountDbContext : DbContext
    {

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public AccountDbContext()
           : base("BankConnection")
        {
        }
        public static AccountDbContext Create()
        {
            return new AccountDbContext();
        }
    }
}

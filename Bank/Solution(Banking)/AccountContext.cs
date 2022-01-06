using Solution_Banking_.Models;
using System.Data.Entity;

namespace Solution_Banking_
{
    public class AccountContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public AccountContext()
           : base("BankConnection")
        {
        }
        public static AccountContext Create()
        {
            return new AccountContext();
        }

    }
}

namespace Solution_Banking_.Migrations
{
    using Solution_Banking_.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Solution_Banking_.AccountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Solution_Banking_.AccountContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Customer.AddOrUpdate(Customer => Customer.Name, new Customer[]
{
                new Customer
                {
                    CustomerID = 1,
                    Name = "Customer 1",
                    Address = "Address for Customer 1"
                },
                 new Customer
                {
                    CustomerID = 2,
                    Name = "Customer 2",
                    Address = "Address for Customer 2"
                },
                  new Customer
                {
                    CustomerID = 3,
                    Name = "Customer 3",
                    Address = "Address for Customer 3"
                }

});
            context.SaveChanges();
            context.Account.AddOrUpdate(new Account[]
            {
                new Account
                {
                    AccountID=1,
                    AccountName= "Current 1",
                    InceptionDate = 12/01/2002,
                    CustomerID =1,
                    CurrentBalance = 30000.00M,
                    AccountTypeID =1,
                },

                new Account
                {
                    AccountID=2,
                    AccountName= "Current 2",
                    InceptionDate = 31/10/2004,
                    CustomerID =1,
                    CurrentBalance = 20000.00M,
                    AccountTypeID =1,
                },

                new Account
                {
                    AccountID=3,
                    AccountName= "Deposit 1",
                    InceptionDate = 10/10/2014,
                    CustomerID =2,
                    CurrentBalance = 10000.00M,
                    AccountTypeID =3,
                },

                new Account
                {
                    AccountID=4,
                    AccountName= "Deposit 1",
                    InceptionDate = 05/05/2011,
                    CustomerID =2,
                    CurrentBalance = 50000.00M,
                    AccountTypeID =3,
                },

                new Account
                {
                    AccountID=5,
                    AccountName= "Savings 1",
                    InceptionDate = 02/02/2010,
                    CustomerID =2,
                    CurrentBalance = 3000.00M,
                    AccountTypeID =2,
                },

                new Account
                {
                    AccountID=6,
                    AccountName= "Current 1",
                    InceptionDate = 29/09/2004,
                    CustomerID =2,
                    CurrentBalance = 10000.00M,
                    AccountTypeID =1,
                }

            });
            context.SaveChanges();
            context.AccountTypes.AddOrUpdate(new AccountType[]
            {
                new AccountType
                {
                    ID =1,
                    TypeName ="Current",
                    Conditions = "Current Account Terms and conditions apply."
                },

                new AccountType
                {
                    ID =2,
                    TypeName ="Savings",
                    Conditions = "Savings Account Terms and conditions apply."
                },

                new AccountType
                {
                    ID =3,
                    TypeName ="Deposit",
                    Conditions = "Deposit Account Terms and conditions apply."
                }

            });
            context.SaveChanges();
            context.Transactions.AddOrUpdate(new Transactions[]
            {
                new Transactions
                {
                    ID =1,
                    TransactionType = TransactionType.Lodgement,
                    Amount =300.00M,
                    TransactionDate = 18/01/2002,
                    AccountID = 1
                },

                new Transactions
                {
                    ID = 2,
                    TransactionType = TransactionType.Withdrawl,
                    Amount = 500.00M,
                    TransactionDate = 14/01/2002,
                    AccountID = 1
                },

                new Transactions
                {
                    ID = 3,
                    TransactionType = TransactionType.Withdrawl,
                    Amount = 300.00M,
                    TransactionDate = 05/11/2004,
                    AccountID = 2
                },

                new Transactions
                {
                    ID = 4,
                    TransactionType = TransactionType.Lodgement,
                    Amount = 200.00M,
                    TransactionDate = 25/10/2014,
                    AccountID = 3
                },

                new Transactions
                {
                    ID = 5,
                    TransactionType = TransactionType.Lodgement,
                    Amount = 1000.00M,
                    TransactionDate = 09/05/2011,
                    AccountID = 4
                },

                new Transactions
                {
                    ID = 6,
                    TransactionType = TransactionType.Withdrawl,
                    Amount = 1000.00M,
                    TransactionDate = 14/02/2010,
                    AccountID = 5
                },

                new Transactions
                {
                    ID = 7,
                    TransactionType = TransactionType.Withdrawl,
                    Amount = 1000.00M,
                    TransactionDate = 04/10/2004,
                    AccountID = 6
                },

            });
            context.SaveChanges();
        }
    }
}

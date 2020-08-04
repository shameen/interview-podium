using System;
using System.Linq;

namespace PodiumInterview.Database
{
    public class DataSeeder
    {
        private readonly IPodiumDatabaseContext _dbContext;

        public DataSeeder(IPodiumDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Ensure certain entities exist in the database.
        /// </summary>
        public void Seed()
        {
            SeedLenders();
            SeedMortgageProducts();
            _dbContext.SaveChanges();
        }

        internal void SeedLenders()
        {
            EnsureExistsLender(new Lender()
            {
                Id = 1,
                CreationDate = DateTimeOffset.Now,
                Name = "Bank A"
            });
            EnsureExistsLender(new Lender()
            {
                Id = 2,
                CreationDate = DateTimeOffset.Now,
                Name = "Bank B"
            });
            EnsureExistsLender(new Lender()
            {
                Id = 3,
                CreationDate = DateTimeOffset.Now,
                Name = "Bank C"
            });
        }
        internal void SeedMortgageProducts()
        {
            EnsureExistsMortgageProduct(new MortgageProduct()
            {
                Id = 1001,
                CreationDate = DateTimeOffset.Now,
                InterestRate = 2,
                InterestRateType = InterestRateType.Variable,
                MaximumLoanToValue = 60,
                LenderId = 1
            });
            EnsureExistsMortgageProduct(new MortgageProduct()
            {
                Id = 1002,
                CreationDate = DateTimeOffset.Now,
                InterestRate = 3,
                InterestRateType = InterestRateType.Fixed,
                MaximumLoanToValue = 60,
                LenderId = 2
            });
            EnsureExistsMortgageProduct(new MortgageProduct()
            {
                Id = 1003,
                CreationDate = DateTimeOffset.Now,
                InterestRate = 4,
                InterestRateType = InterestRateType.Variable,
                MaximumLoanToValue = 60,
                LenderId = 3
            });

        }

        private void EnsureExistsLender(Lender lender)
        {
            if (_dbContext.Lenders.Any(mp => mp.Id == lender.Id))
                _dbContext.Lenders.Remove(_dbContext.Lenders.First(mp => mp.Id == lender.Id));
            _dbContext.Lenders.Add(lender);
        }

        private void EnsureExistsMortgageProduct(MortgageProduct mortgageProduct)
        {
            if (_dbContext.MortgageProducts.Any(mp => mp.Id == mortgageProduct.Id))
                _dbContext.MortgageProducts.Remove(_dbContext.MortgageProducts.First(mp => mp.Id == mortgageProduct.Id));
            _dbContext.MortgageProducts.Add(mortgageProduct);
        }


    }
}

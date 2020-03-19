using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Retail.Data.Database;
using Retail.Data.Repositories;
using Retail.Data.UnitOfWork.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private EkoDataContext _context;

        public EFUnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("Database.json").Build();
            var connectionString = configuration.GetConnectionString("EkoDatabase");
            optionsBuilder.UseSqlServer(connectionString);
            _context = new EkoDataContext(optionsBuilder.Options);
        }
        public AgentGroupRepository AgentGroupsRepository => new AgentGroupRepository(_context);
        public AgentRepository AgentsRepository => new AgentRepository(_context);
        public AuditLogRepository AuditLogsRepository => new AuditLogRepository(_context);
        public BusinessAccounRepository BusinessAccountsRepository => new BusinessAccounRepository(_context);
        public BusinessBranchRepository BusinessBranchesRepository => new BusinessBranchRepository(_context);
        public BusinessRepository BusinessesRepository => new BusinessRepository(_context);
        public CurrencyRepository CurrenciesRepository => new CurrencyRepository(_context);
        public CustomerRepository CustomersRepository => new CustomerRepository(_context);
        public ExpenseRepository ExpenseRepository => new ExpenseRepository(_context);
        public InventoryRepository InventoriesRepository => new InventoryRepository(_context);
        public InvoiceLineItemRepository InvoiceLineItemsRepository => new InvoiceLineItemRepository(_context);
        public InvoiceRepository InvoicesRepository => new InvoiceRepository(_context);
        public PaymentRepository PaymentsRepository => new PaymentRepository(_context);
        public PlanRepository PlansRepository => new PlanRepository(_context);
        public ProductRepository ProductsRepository => new ProductRepository(_context);
        public ReceiptRepository ReceiptsRepository => new ReceiptRepository(_context);
        public ShoppingCartRepository ShoppingCartRepository => new ShoppingCartRepository(_context);
        public ShoppingCartItemRepository ShoppingCartItemRepository => new ShoppingCartItemRepository(_context);
        public SupplierRepository SupplierRepository => new SupplierRepository(_context);
        public TaxRepository TaxesRepository => new TaxRepository(_context);
        public TransactionRepository TransactionRepository => new TransactionRepository(_context);
        public UserProfileRepository UserProfilesRepository => new UserProfileRepository(_context);
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

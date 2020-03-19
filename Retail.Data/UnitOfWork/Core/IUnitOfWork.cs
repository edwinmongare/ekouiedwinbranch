using Retail.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.UnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        AgentGroupRepository AgentGroupsRepository { get; }
        AgentRepository AgentsRepository { get; }
        AuditLogRepository AuditLogsRepository { get; }
        BusinessAccounRepository BusinessAccountsRepository { get; }
        BusinessBranchRepository BusinessBranchesRepository { get; }
        BusinessRepository BusinessesRepository { get; }
        CurrencyRepository CurrenciesRepository { get; }
        CustomerRepository CustomersRepository { get; }
        ExpenseRepository ExpenseRepository { get; }
        InventoryRepository InventoriesRepository { get; }
        InvoiceLineItemRepository InvoiceLineItemsRepository { get; }
        InvoiceRepository InvoicesRepository { get; }
        PaymentRepository PaymentsRepository { get; }
        PlanRepository PlansRepository { get; }
        ProductRepository ProductsRepository { get; }
        ReceiptRepository ReceiptsRepository { get; }
        ShoppingCartRepository ShoppingCartRepository { get; }
        ShoppingCartItemRepository ShoppingCartItemRepository { get; }
        SupplierRepository SupplierRepository { get; }
        TaxRepository TaxesRepository { get; }
        TransactionRepository TransactionRepository { get; }
        UserProfileRepository UserProfilesRepository { get; }

        int Complete();
    }
}

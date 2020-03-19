using Retail.Data.Database;
using Retail.Data.Models;
using Retail.Data.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>
    {
        private EkoDataContext _ekoDataContext;

        public TransactionRepository(EkoDataContext context) : base(context)
        {
            _ekoDataContext = context as EkoDataContext;
        }

    }
}
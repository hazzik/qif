﻿using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Parsers
{
    class CategoryListParser : IParser
    {
        private CategoryListTransaction item = new CategoryListTransaction();

        public void Yield(QifDocument document)
        {
            document.CategoryListTransactions.Add(item);
            item = new CategoryListTransaction();
        }

        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case CategoryListFields.BudgetAmount:
                    item.BudgetAmount = Common.GetDecimal(value);
                    break;
                case CategoryListFields.CategoryName:
                    item.CategoryName = value;
                    break;
                case CategoryListFields.Description:
                    item.Description = value;
                    break;
                case CategoryListFields.ExpenseCategory:
                    item.ExpenseCategory = Common.GetBoolean(value);
                    break;
                case CategoryListFields.IncomeCategory:
                    item.IncomeCategory = Common.GetBoolean(value);
                    break;
                case CategoryListFields.TaxRelated:
                    item.TaxRelated = Common.GetBoolean(value);
                    break;
                case CategoryListFields.TaxSchedule:
                    item.TaxSchedule = value;
                    break;
            }
        }
    }
}
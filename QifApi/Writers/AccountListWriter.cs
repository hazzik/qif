﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    static class AccountListWriter
    {
        internal static void Write(TextWriter writer, ICollection<AccountListTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                writer.WriteLine(Headers.AccountList);

                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.Type))
                    {
                        writer.Write(AccountInformationFields.AccountType);
                        writer.WriteLine(item.Type);
                    }

                    writer.Write(AccountInformationFields.CreditLimit);
                    writer.WriteLine(item.CreditLimit.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        writer.Write(AccountInformationFields.Description);
                        writer.WriteLine(item.Description);
                    }

                    if (!string.IsNullOrEmpty(item.Name))
                    {
                        writer.Write(AccountInformationFields.Name);
                        writer.WriteLine(item.Name);
                    }

                    writer.Write(AccountInformationFields.StatementBalance);
                    writer.WriteLine(item.StatementBalance.ToString(CultureInfo.CurrentCulture));

                    writer.Write(AccountInformationFields.StatementBalanceDate);
                    writer.WriteLine(item.StatementBalanceDate.ToString("d"));

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}
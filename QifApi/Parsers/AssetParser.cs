﻿using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    class AssetParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.AssetTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}
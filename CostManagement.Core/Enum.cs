using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Core
{
    public class Enum
    {
        public Enum() { }

        public enum AccountType
        {
            [Description("None")]
            None = 0,
            [Description("Income")]
            Income = 1,
            [Description("Expense")]
            Expense = 2,
            [Description("Transfer")]
            Transfer = 3
        }

        public enum Account
        {
            [Description("None")]
            None = 0,
            [Description("Cash")]
            Cash = 1,
            [Description("Online Payment")]
            OnlinePayment = 2
        }

        public enum PaymentType
        {
            [Description("None")]
            None = 0,
            [Description("Cash")]
            Cash = 1,
            [Description("Debit Card")]
            DebitCard = 2,
            [Description("Credit Card")]
            CreditCard = 3,
            [Description("Bank Transfer")]
            BankTransfer = 4,
            [Description("Voucher")]
            Voucher = 5,
            [Description("Mobile Payment")]
            MobilePayment = 6,
            [Description("Web Payment")]
            WebPayment = 7
        }

        public enum ExpenseStatus
        {
            [Description("None")]
            None = 0,
            [Description("Pending")]
            Pending = 1,
            [Description("Cleared")]
            Cleared = 2
        }

    }
}

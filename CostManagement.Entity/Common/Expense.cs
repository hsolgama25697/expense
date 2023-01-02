using CostManagement.Entity.Shared;
using Microsoft.AspNetCore.Http;
using static CostManagement.Core.Enum;

namespace CostManagement.Entity.Common
{
    public class Expense : BaseClass
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// SubCategoryId
        /// </summary>
        public Guid SubCategoryId { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// AccountType
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// LabelId
        /// </summary>
        public string LabelId { get; set; }

        /// <summary>
        /// PayeeName
        /// </summary>
        public string PayeeName { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Payment Type
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public ExpenseStatus Status { get; set; }

        /// <summary>
        /// string
        /// </summary>
        public string Location { get; set; }
         
        /// <summary>
        /// Category
        /// </summary>
        public Category Category { get; set; }
        public List<Label> Labels { get; set; }
        public Expense()
        {
            Labels = new List<Label>();
        }
    }
}
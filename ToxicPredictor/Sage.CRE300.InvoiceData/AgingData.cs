namespace Sage.CRE300.InvoiceData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AgingData
    {
        private const string ARA_ACTIVITY = "ARA_ACTIVITY__ACTIVITY";
        private const string ARM_MASTER_CUSTOMER = "ARM_MASTER__CUSTOMER";
        private const string ARS_STANDARD_CONTACT = "ARS_STANDARD__CONTACT";
        private const string ART_CURRENT_TRANSACTION = "ART_CURRENT__TRANSACTION";

        // ARA_ACTIVITY__ACTIVITY
        public DateTime? ARA_ACTIVITY__ACTIVITY_Status_Date { get; set; }
        public DateTime? ARA_ACTIVITY__ACTIVITY_Due_Date { get; set; }
        public DateTime? ARA_ACTIVITY__ACTIVITY_Activity_Date { get; set; }

        // ARM_MASTER__CUSTOMER
        public string ARM_MASTER__CUSTOMER_Name { get; set; }
        public string ARM_MASTER__CUSTOMER_Telephone { get; set; }

        // ARS_STANDARD__CONTACT
        public string ARS_STANDARD__CONTACT_Contact_Name { get; set; }
        public string ARS_STANDARD__CONTACT_Title { get; set; }
        public string ARS_STANDARD__CONTACT_Telephone { get; set; }

        // ART_CURRENT__TRANSACTION
        public string ART_CURRENT__TRANSACTION_Customer { get; set; }
        public Int64 ART_CURRENT__TRANSACTION_Run { get; set; }
        public string ART_CURRENT__TRANSACTION_Transaction_Type { get; set; }
        public string ART_CURRENT__TRANSACTION_Amount_Type { get; set; }
        public string ART_CURRENT__TRANSACTION_Invoice { get; set; }
        public string ART_CURRENT__TRANSACTION_Draw { get; set; }
        public DateTime? ART_CURRENT__TRANSACTION_Reference_Date { get; set; }
        public DateTime? ART_CURRENT__TRANSACTION_Due_Date { get; set; }
        public string ART_CURRENT__TRANSACTION_Cash_Receipt_Type { get; set; }
        public string ART_CURRENT__TRANSACTION_Cash_Receipt { get; set; }
        public DateTime? ART_CURRENT__TRANSACTION_Deposit_Date { get; set; }
        public string ART_CURRENT__TRANSACTION_Adjustment_Type { get; set; }
        public string ART_CURRENT__TRANSACTION_Adjustment { get; set; }
        public string ART_CURRENT__TRANSACTION_Edit_Type { get; set; }
        public DateTime? ART_CURRENT__TRANSACTION_Accounting_Date { get; set; }
        public double ART_CURRENT__TRANSACTION_Amount { get; set; }
        public double ART_CURRENT__TRANSACTION_Retainage { get; set; }
        public string ART_CURRENT__TRANSACTION_Status_Type { get; set; }
        public DateTime? ART_CURRENT__TRANSACTION_Status_Date { get; set; }
        public int ART_CURRENT__TRANSACTION_Status_Seq { get; set; }
        public int ART_CURRENT__TRANSACTION_Actvty_Seq { get; set; }
        public DateTime? ART_CURRENT__TRANSACTION_Related_Status_Date { get; set; }
        public string MASTER_JCM_JOB_1_Job { get; set; }
        public string MASTER_JCM_JOB_1_Description { get; set; }


        public static IEnumerable<AgingData> GetAgingData()
        {
            var query = "SELECT ARA_ACTIVITY__ACTIVITY.Status_Date AS ARA_ACTIVITY__ACTIVITY_Status_Date, ARA_ACTIVITY__ACTIVITY.Due_Date AS ARA_ACTIVITY__ACTIVITY_Due_Date, ARA_ACTIVITY__ACTIVITY.Activity_Date AS ARA_ACTIVITY__ACTIVITY_Activity_Date, ARM_MASTER__CUSTOMER.Name AS ARM_MASTER__CUSTOMER_Name, ARM_MASTER__CUSTOMER.Telephone AS ARM_MASTER__CUSTOMER_Telephone, ARS_STANDARD__CONTACT.Contact_Name AS ARS_STANDARD__CONTACT_Contact_Name, ARS_STANDARD__CONTACT.Title AS ARS_STANDARD__CONTACT_Title, ARS_STANDARD__CONTACT.Telephone AS ARS_STANDARD__CONTACT_Telephone, ART_CURRENT__TRANSACTION.Customer AS ART_CURRENT__TRANSACTION_Customer, ART_CURRENT__TRANSACTION.Run AS ART_CURRENT__TRANSACTION_Run, ART_CURRENT__TRANSACTION.Transaction_Type AS ART_CURRENT__TRANSACTION_Transaction_Type, ART_CURRENT__TRANSACTION.Amount_Type AS ART_CURRENT__TRANSACTION_Amount_Type, ART_CURRENT__TRANSACTION.Invoice AS ART_CURRENT__TRANSACTION_Invoice, ART_CURRENT__TRANSACTION.Draw AS ART_CURRENT__TRANSACTION_Draw, ART_CURRENT__TRANSACTION.Reference_Date AS ART_CURRENT__TRANSACTION_Reference_Date, ART_CURRENT__TRANSACTION.Due_Date AS ART_CURRENT__TRANSACTION_Due_Date, ART_CURRENT__TRANSACTION.Cash_Receipt_Type AS ART_CURRENT__TRANSACTION_Cash_Receipt_Type, ART_CURRENT__TRANSACTION.Cash_Receipt AS ART_CURRENT__TRANSACTION_Cash_Receipt, ART_CURRENT__TRANSACTION.Deposit_Date AS ART_CURRENT__TRANSACTION_Deposit_Date, ART_CURRENT__TRANSACTION.Adjustment_Type AS ART_CURRENT__TRANSACTION_Adjustment_Type, ART_CURRENT__TRANSACTION.Adjustment AS ART_CURRENT__TRANSACTION_Adjustment, ART_CURRENT__TRANSACTION.Edit_Type AS ART_CURRENT__TRANSACTION_Edit_Type, ART_CURRENT__TRANSACTION.Accounting_Date AS ART_CURRENT__TRANSACTION_Accounting_Date, ART_CURRENT__TRANSACTION.Amount AS ART_CURRENT__TRANSACTION_Amount, ART_CURRENT__TRANSACTION.Retainage AS ART_CURRENT__TRANSACTION_Retainage, ART_CURRENT__TRANSACTION.Status_Type AS ART_CURRENT__TRANSACTION_Status_Type, ART_CURRENT__TRANSACTION.Status_Date AS ART_CURRENT__TRANSACTION_Status_Date, ART_CURRENT__TRANSACTION.Status_Seq AS ART_CURRENT__TRANSACTION_Status_Seq, ART_CURRENT__TRANSACTION.Actvty_Seq AS ART_CURRENT__TRANSACTION_Actvty_Seq, ART_CURRENT__TRANSACTION.Related_Status_Date AS ART_CURRENT__TRANSACTION_Related_Status_Date, JCM_MASTER__JOB.Job AS MASTER_JCM_JOB_1_Job, JCM_MASTER__JOB.Description AS MASTER_JCM_JOB_1_Description FROM(((ARM_MASTER__CUSTOMER INNER JOIN ART_CURRENT__TRANSACTION ON ARM_MASTER__CUSTOMER.Customer = ART_CURRENT__TRANSACTION.Customer) LEFT JOIN ARS_STANDARD__CONTACT ON ARM_MASTER__CUSTOMER.Billing_Contact = ARS_STANDARD__CONTACT.Contact) LEFT JOIN ARA_ACTIVITY__ACTIVITY ON(ART_CURRENT__TRANSACTION.Actvty_Seq = ARA_ACTIVITY__ACTIVITY.Actvty_Seq) AND(ART_CURRENT__TRANSACTION.Status_Seq = ARA_ACTIVITY__ACTIVITY.Status_Seq) AND(ART_CURRENT__TRANSACTION.Status_Date = ARA_ACTIVITY__ACTIVITY.Status_Date) AND(ART_CURRENT__TRANSACTION.Status_Type = ARA_ACTIVITY__ACTIVITY.Status_Type) AND(ART_CURRENT__TRANSACTION.Customer = ARA_ACTIVITY__ACTIVITY.Customer)) LEFT JOIN JCM_MASTER__JOB ON ART_CURRENT__TRANSACTION.Job = JCM_MASTER__JOB.Job;";

            return ListBase.GetList<AgingData>(query);
        }

        private static string GetQuery()
        {
            string query = "SELECT * " +
                //GetAraActivitySelect() + ", " +
                //GetArmMasterCustomerSelect() + ", " +
                //GetArsStandardContactSelect() + ", " +
                //GetArtCurrentTransactionsSelect() +
                GetFromClause();

            return query;
        }

        private static string GetAraActivitySelect()
        {
            List<string> fields = new List<string>() 
            { 
                "Status_Date", 
                "Due_Date", 
                "Activity_Date" 
            };

            return BuildTableSelectString(ARA_ACTIVITY, fields);            
        }

        public static string GetArmMasterCustomerSelect()
        {
            List<string> fields = new List<string>()
            {
                "Name",
                "Telephone"
            };

            return BuildTableSelectString(ARM_MASTER_CUSTOMER, fields);
        }

        public static string GetArsStandardContactSelect()
        {
            List<string> fields = new List<string>()
            {
                "Contact_Name",
                "Title",
                "Telephone"
            };

            return BuildTableSelectString(ARS_STANDARD_CONTACT, fields);
        }

        public static string GetArtCurrentTransactionsSelect()
        {
            List<string>fields = new List<string>()
            {
                "Customer",
                "Run",
                "Transaction_Type",
                "Amount_Type",
                "Invoice",
                "Draw",
                "Reference_Date",
                "Due_Date",
                "Cash_Receipt_Type",
                "Cash_Receipt",
                "Deposit_Date",
                "Adjustment_Type",
                "Adjustment",
                "Edit_Type",
                "Accounting_Date",
                "Amount",
                "Retainage",
                "Status_Type",
                "Status_Date",
                "Status_Seq",
                "Activity_Seq",
                "Related_Status_Date"
            };

            return BuildTableSelectString(ART_CURRENT_TRANSACTION, fields);
        }

        private static string BuildTableSelectString(string table, List<string> fields)
        {
            string result = "";

            foreach(string field in fields)
            {
                if (result.Length > 0)
                {
                    result += ", ";
                }

                result += $" [{table}].[{field}] AS [{table}_{field}]";
            }
            
            return result;
        }

        private static string GetFromClause()
        {
            string clause = " FROM  ";

            clause += $" [{ART_CURRENT_TRANSACTION}]";
            //INNER JOIN [{ARM_MASTER_CUSTOMER}] ON [{ART_CURRENT_TRANSACTION}].[Customer] = [{ARM_MASTER_CUSTOMER}.[Customer]  " +
            //    $"  LEFT JOIN [{ARS_STANDARD_CONTACT}] ON [{ARM_MASTER_CUSTOMER}].[Billing_Contact] = [{ARS_STANDARD_CONTACT}].[Contact]  " +
            //    $"  LEFT JOIN [{ARA_ACTIVITY}] ON  " +
            //    $"   [{ART_CURRENT_TRANSACTION}].[Customer] = [{ARA_ACTIVITY}].[Customer] AND  " +
            //    $"   [{ART_CURRENT_TRANSACTION}].[Status_Type] = [{ARA_ACTIVITY}].[Status_Type] AND  " +
            //    $"   [{ART_CURRENT_TRANSACTION}].[Status_Date] = [{ARA_ACTIVITY}].[Status_Date] AND  " +
            //    $"   [{ART_CURRENT_TRANSACTION}].[Status_Seq] = [{ARA_ACTIVITY}].[Status_Seq] AND  " +
            //    $"   [{ART_CURRENT_TRANSACTION}].[Activity_Seq] = [{ARA_ACTIVITY}].[Activity_Seq]";

            return clause;
        }
    }
}

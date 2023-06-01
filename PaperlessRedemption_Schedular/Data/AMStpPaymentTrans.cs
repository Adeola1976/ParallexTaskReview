using PaperlessRedemption_Schedular.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PaperlessRedemption_Schedular.Models.AutoMatchTransaction;

namespace PaperlessRedemption_Schedular.Data
{
    public class AMStpPaymentTrans
    {
        public static async Task<bool> InsertPaymentSTPTransaction(string connectionString,Parent NavWebResponse)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAutoMatchInsertStpPaymentTransaction", sql))
                {
                    foreach (var record in NavWebResponse.Lines)
                    {
                        var CheckForStpTransactionRecord = await CheckForStpPaymentTransactionRecord(connectionString, record.No);
                        if (CheckForStpTransactionRecord == false)
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@CustomerReference", "1218084-ARMMMF-01"));
                            cmd.Parameters.Add(new SqlParameter("@CustomerName", record.ClientName));
                            cmd.Parameters.Add(new SqlParameter("@TransactionReference", record.No));
                            cmd.Parameters.Add(new SqlParameter("@Narration", "Transfered RN00196357 1218044-ARMMMF-01"));
                            cmd.Parameters.Add(new SqlParameter("@Amount", record.Amount));
                            cmd.Parameters.Add(new SqlParameter("@AmountRaised", ""));
                            cmd.Parameters.Add(new SqlParameter("@Source", ""));
                            cmd.Parameters.Add(new SqlParameter("@PayableBankConfigId", 1));
                            cmd.Parameters.Add(new SqlParameter("@FiledToBankAt", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@TransactionDate", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Status", "status"));
                            cmd.Parameters.Add(new SqlParameter("@ResponseReceivedAt", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@PaymentResponseMessage", "test"));
                            cmd.Parameters.Add(new SqlParameter("@PaymentStatus", 1));
                            cmd.Parameters.Add(new SqlParameter("@IsTransactionNavFiled", 1));
                            cmd.Parameters.Add(new SqlParameter("@Currency", "Naira"));
                            cmd.Parameters.Add(new SqlParameter("@IsValidForPayOut", 1));
                            cmd.Parameters.Add(new SqlParameter("@IsBalanceSufficient", 1));
                            cmd.Parameters.Add(new SqlParameter("@BankCode", record.BankSortCode[0]));
                            cmd.Parameters.Add(new SqlParameter("@BankAccountNo", record.BankAccountNo));
                            cmd.Parameters.Add(new SqlParameter("@BankName", record.BankName[0]));
                            cmd.Parameters.Add(new SqlParameter("@DisburstmentAccountNo", "0641719218"));
                            cmd.Parameters.Add(new SqlParameter("@DisburstmentBank", "GUARANTY TRUST BANK"));
                            cmd.Parameters.Add(new SqlParameter("@IsRequiredApproval", 1));
                            cmd.Parameters.Add(new SqlParameter("@IsApprovedForPayment", 1));
                            cmd.Parameters.Add(new SqlParameter("@ApprovedBy", "System Test"));
                            cmd.Parameters.Add(new SqlParameter("@ActivityNotification", 1));
                            cmd.Parameters.Add(new SqlParameter("@IsActive", 1));

                            await sql.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                            return true;
                        }
                        
                    }

                }
            }
            return false;
        }


        public static async Task<bool> CheckForStpPaymentTransactionRecord(string connectionString, string referenceTransaction)
        {
            bool checkRecordIsFound;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAutoMatchGetStpPaymentTransaction", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TransactionReference", referenceTransaction));
                    //SPModelStatus response = null;
                    await sql.OpenAsync();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows) checkRecordIsFound = true;
                    
                    else checkRecordIsFound = false;

                    reader.Close();
                    reader.Dispose();
                 }
                 sql.Close();
                }
            return checkRecordIsFound;
            }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions;
using System.IO;

namespace SimpleFraudDetectionConsoleApp
{
    internal class Program
    {
        static List<Transaction> ReadCsv(string filePath)
        {
            List<Transaction> transactions = new List<Transaction>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines.Skip(1)) // Skip header
            {
                var fields = line.Split(',');
                var transaction = new Transaction
                {
                    TransactionId = fields[0],
                    UserId = fields[1],
                    TransactionDate = DateTime.Parse(fields[2]),
                    Amount = decimal.Parse(fields[3]),
                    Currency = fields[4],
                    Merchant = fields[5],
                    Category = fields[6],
                    PaymentMethod = fields[7],
                    Status = fields[8]
                };
                transactions.Add(transaction);
            }
            return transactions;
        }
        static void Main(string[] args)
        {

            string filePath= "..\\..\\DataLayer\\transactions_sample.csv";
            string reportPath = "..\\..\\DataLayer\\fraud_report.txt";

            List<Transaction> transactions = ReadCsv(filePath);
            int flagForAmount = 0;
            int flagForMerchant = 0;
            int flagForStructuring = 0;
            int normalTransactions = 0;

            // Collect all flagged transactions first
            StringBuilder report = new StringBuilder();

            foreach (Transaction transaction in transactions)
            {
                bool isFlagged = false;
                bool isFlagAmount = false;
                bool isFlagMerchant = false;
                bool isFlagStructuring = false;
                //Flag if amount > $5000
                if (transaction.Amount > 5000)
                {

                    Console.WriteLine($"Potential Fraud Detected: Transaction {transaction.TransactionId} by User {transaction.UserId} Amount: {transaction.Amount} on {transaction.TransactionDate}");
                    flagForAmount++;
                    isFlagged = true;
                    isFlagAmount = true;
                }

                //Flag if a merchant has > 3 transactions in 1 hour
                List<Transaction> oneHourTransactions = transactions.Where(t => t.Merchant == transaction.Merchant &&
                                                                  t.TransactionDate >= transaction.TransactionDate.AddHours(-1) &&
                                                                  t.TransactionDate <= transaction.TransactionDate.AddHours(1)).ToList();

                if (oneHourTransactions.Count > 3)
                {
                    Console.WriteLine($"Potential Fraud Detected: Merchant {transaction.Merchant} has {oneHourTransactions.Count} transactions within 1 hour on {transaction.TransactionDate}");
                    flagForMerchant++;
                    isFlagged = true;
                    isFlagMerchant = true;
                }

                //Flag if amount is $9999 (structuring pattern)
                if (transaction.Amount == 9999)
                {
                    Console.WriteLine($"Potential Fraud Detected: Transaction {transaction.TransactionId} by User {transaction.UserId} Amount: {transaction.Amount} on {transaction.TransactionDate} (Structuring Pattern)");
                    flagForStructuring++;
                    isFlagged = true;
                    isFlagStructuring = true;
                }

                if(!isFlagged)
                {
                    normalTransactions++;
                }

                // Build report content in memory
                if (isFlagAmount == true || isFlagMerchant == true || isFlagStructuring == true)
                {
                    report.AppendLine("Transaction ID: " + transaction.TransactionId);
                    report.AppendLine("User ID: " + transaction.UserId);
                    report.AppendLine("Amount: " + transaction.Currency + " " + transaction.Amount);
                    report.AppendLine("Merchant: " + transaction.Merchant);
                    report.AppendLine("Transaction Date: " + transaction.TransactionDate);
                    report.AppendLine("Fraud Reasons:");
                    if (isFlagAmount == true)
                    {
                        report.AppendLine("         - Flagged for: Amount greater than 5000");
                    }
                    if (isFlagMerchant == true)
                    {
                        report.AppendLine("         - Flagged for: More than 3 transactions at the same merchant within 1 hour");
                    }
                    if (isFlagStructuring == true)
                    {
                        report.AppendLine("         - Flagged for: Structuring pattern (Amount equals 9999)");
                    }
                    report.AppendLine("--------------------------------------------------------");
                    report.AppendLine();
                }
            }
            

            using (StreamWriter writer = new StreamWriter(reportPath, false)) 
            {
                // Write header
                writer.WriteLine("================ FRAUD DETECTION REPORT ================");
                writer.WriteLine("Generated On : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine("Total Transactions Processed : " + transactions.Count);
                writer.WriteLine("Normal Transactions         : " + normalTransactions);
                writer.WriteLine("Flagged for High Amount     : " + flagForAmount);
                writer.WriteLine("Flagged for Merchant Activity: " + flagForMerchant);
                writer.WriteLine("Flagged for Structuring     : " + flagForStructuring);
                writer.WriteLine("Total Flagged Transactions   : " + (flagForAmount + flagForMerchant + flagForStructuring));
                writer.WriteLine("--------------------------------------------------------");
                writer.WriteLine();

                // Write all flagged transactions
                writer.Write(report.ToString());
            }

            Console.WriteLine($"\n Report written to: {reportPath}");
            Console.WriteLine($"\nSummary:");
            Console.WriteLine($"  Total Transactions: {transactions.Count}");
            Console.WriteLine($"  Normal Transactions: {normalTransactions}");
            Console.WriteLine($"  Flagged for High Amount: {flagForAmount}");
            Console.WriteLine($"  Flagged for Merchant Activity: {flagForMerchant}");
            Console.WriteLine($"  Flagged for Structuring: {flagForStructuring}");
            Console.ReadLine();
        }
    }
}

# Simple Fraud Detection Console Application

A .NET Framework console application that analyzes transaction data and flags suspicious activities using rule-based fraud detection algorithms.

## 📋 Project Overview

This application demonstrates the use of:
- **LINQ** for data filtering and analysis
- **File I/O** operations for CSV reading and report generation
- **Console applications** in .NET Framework
- **Basic fraud detection** patterns

**Duration:** 3-4 hours  
**Complexity Level:** Low-Medium

---

## 🎯 Features

### Fraud Detection Rules

The application implements three fraud detection rules:

1. **High Amount Detection**
   - Flags transactions with amount > 5000
   - Indicates potentially fraudulent large purchases

2. **Merchant Activity Pattern**
   - Flags merchants with > 3 transactions within a 1-hour window
   - Detects rapid repeated transactions

3. **Structuring Pattern**
   - Flags transactions with amount = 9999
   - Detects attempts to avoid reporting thresholds

### Output Features

- ✅ Real-time console logging of flagged transactions
- ✅ Detailed fraud report generation (`fraud_report.txt`)
- ✅ Summary statistics display
- ✅ Professional formatted report with timestamps

---

## 🛠️ Technologies Used

- **.NET Framework 4.8**
- **C# 7.3**
- **LINQ** for data queries
- **StreamWriter** for file output
- **StringBuilder** for efficient string building

---


## 🚀 Getting Started

### Prerequisites

- Visual Studio 2017 or later
- .NET Framework 4.8 SDK

### Installation

1. **Clone the repository**

2. **Open in Visual Studio**
- Double-click `SimpleFraudDetectionConsoleApp.sln`
- Or use: `File > Open > Project/Solution`

3. **Build the solution**
- Press `Ctrl + Shift + B`
- Or use: `Build > Build Solution`

4. **Run the application**
   - Press `F5` (Debug mode)
   - Or press `Ctrl + F5` (Without debugging)

---

## 📊 Sample Data Format

### Input CSV (`transactions_sample.csv`)

**Fields:**
- `transaction_id`: Unique transaction identifier
- `user_id`: User identifier
- `transaction_date`: Date of transaction (yyyy-MM-dd)
- `amount`: Transaction amount
- `currency`: Currency code (e.g., INR, USD)
- `merchant`: Merchant name
- `category`: Transaction category
- `payment_method`: Payment method used
- `status`: Transaction status

---

## 📄 Output Report Format

### Console Output

### Generated Report (`fraud_report.txt`)


---

## 🔍 How It Works

### 1. CSV Reading
- Reads all lines from CSV file
- Skips header row
- Parses each line into `Transaction` objects

### 2. Fraud Detection Logic

### 3. Report Generation
- Uses `StringBuilder` for efficient string concatenation
- Writes formatted report to file in a single operation
- Displays summary statistics to console

---

## 📈 Performance Considerations

- **Time Complexity:** O(n²) due to nested merchant checks
- **Space Complexity:** O(n) for storing transactions
- **Optimization Opportunity:** Group transactions by merchant before analysis

---

## 🔮 Future Enhancements

- [ ] Add more sophisticated fraud detection algorithms
- [ ] Implement machine learning-based detection
- [ ] Add database integration (SQL Server/SQLite)
- [ ] Create visualization dashboard
- [ ] Add unit tests
- [ ] Implement async/await for better performance
- [ ] Add configuration file for fraud thresholds
- [ ] Support multiple currencies with conversion
- [ ] Add email notifications for flagged transactions

---

## 📝 License

This project is created for educational purposes as part of a GitHub Copilot demonstration.

---

## 👤 Author

**T Eswar Reddy**
- GitHub: [@TEswarreddy](https://github.com/TEswarreddy)
- Repository: [SimpleFraudDetectionConsoleApp](https://github.com/TEswarreddy/SimpleFraudDetectionConsoleApp)

---

## Acknowledgments

- Built as a demonstration of GitHub Copilot capabilities
- Sample data generated for educational purposes
- Inspired by real-world fraud detection systems

---

## 📞 Support

For questions or issues, please open an issue on GitHub:
https://github.com/TEswarreddy/SimpleFraudDetectionConsoleApp/issues

---

**⭐ If you found this project helpful, please consider giving it a star!**

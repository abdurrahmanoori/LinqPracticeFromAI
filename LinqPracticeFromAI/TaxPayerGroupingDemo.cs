//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace TaxPayerGroupingDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Setup dummy data
//            var taxPayers = new List<TaxPayer>
//            {
//                new TaxPayer { TaxPayerNo = 101, Name = "Alice" },
//                new TaxPayer { TaxPayerNo = 102, Name = "Bob" }
//            };

//            var fiscalYears = new List<FiscalYear>
//            {
//                new FiscalYear { Id = 1, TaxPayerNo = 101, Year = 2020, TaxPayer = new TaxPayer { TaxPayerNo = 101, Name = "Alice" } },
//                new FiscalYear { Id = 2, TaxPayerNo = 101, Year = 2021, TaxPayer = new TaxPayer { TaxPayerNo = 101, Name = "Alice" } },
//                new FiscalYear { Id = 3, TaxPayerNo = 102, Year = 2020, TaxPayer = taxPayers[1] }
//            };

//            Console.WriteLine("✅ Group by TAX_PAYER_NO (value):");
//            var byValue = fiscalYears
//                .GroupBy(f => f.TaxPayerNo)
//                .Select(g => new
//                {
//                    TaxPayerNo = g.Key,
//                    Count = g.Count()
//                });

//            foreach (var item in byValue)
//            {
//                Console.WriteLine($"TaxPayerNo: {item.TaxPayerNo}, Count: {item.Count}");
//            }

//            Console.WriteLine("\n❌ Group by TAX_PAYER (object):");
//            var byObject = fiscalYears
//                .GroupBy(f => f.TaxPayer)
//                .Select(g => new
//                {
//                    TaxPayerNo = g.Key.TaxPayerNo,
//                    Count = g.Count()
//                });

//            foreach (var item in byObject)
//            {
//                Console.WriteLine($"TaxPayerNo: {item.TaxPayerNo}, Count: {item.Count}");
//            }

//            Console.ReadLine();
//        }
//    }

//    class TaxPayer
//    {
//        public int TaxPayerNo { get; set; }
//        public string Name { get; set; }
//    }

//    class FiscalYear
//    {
//        public int Id { get; set; }
//        public int TaxPayerNo { get; set; }
//        public int Year { get; set; }

//        public TaxPayer TaxPayer { get; set; }
//    }
//}

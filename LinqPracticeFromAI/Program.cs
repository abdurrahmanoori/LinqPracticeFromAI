public class Program
{

    //Write a LINQ query to find the top 2 orders by TotalAmount, and return the OrderID, CustomerID, and TotalAmount.
    public static void Main()
    {
        var customers = Data.GetCustomers();
        var orders = Data.GetOrders();
        var or = orders.OrderBy(x => x.TotalAmount).Take(2);
      

        var query = from customer in customers
                    join order in orders on customer.CustomerID equals order.CustomerID
                    group order by new { order.OrderID, customer.CustomerID, order.TotalAmount } into g
                    let total = g.Sum(x => x.TotalAmount)
                    select new
                    {
                        Name = g.Key.OrderID,
                        g.Key.CustomerID,
                        g.Key.TotalAmount,
                        OrderDate = g.OrderBy(o => o.OrderDate).First().OrderDate
                    };


        var res = query.First();
        int x = 23;
        //var sdfsd = query.DistinctBy(x=>x.CustId).ToList();







        //var query = from customer in customers
        //            join order in orders on customer.CustomerID equals order.CustomerID
        //            group order by new { customer.CustomerID, customer.Name } into g
        //            select new
        //            {
        //                Name = g.Key.Name,
        //                TotalSpent = g.Sum(x => x.TotalAmount)
        //            } into result
        //            orderby result.TotalSpent ascending
        //            select result;
        //var qu = query.First();

        Console.WriteLine("hewlo");

    }




    public class Data
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { CustomerID = 1, Name = "Alice Smith", Email = "alice@example.com", Phone = "123-456-7890" },
                new Customer { CustomerID = 2, Name = "Bob Johnson", Email = "bob@example.com", Phone = "234-567-8901" },
                new Customer { CustomerID = 3, Name = "Charlie Brown", Email = "charlie@example.com", Phone = "345-678-9012" }
            };
        }

        public static List<Order> GetOrders()
        {
            return new List<Order>
             {
                 new Order { OrderID = 101, CustomerID = 1, OrderDate = new DateTime(2025, 1, 15), TotalAmount = 150.50m },
                 new Order { OrderID = 102, CustomerID = 2, OrderDate = new DateTime(2025, 2, 10), TotalAmount = 75.25m },
                 new Order { OrderID = 103, CustomerID = 1, OrderDate = new DateTime(2025, 3, 1), TotalAmount = 200.00m },
                 new Order { OrderID = 104, CustomerID = 3, OrderDate = new DateTime(2025, 3, 10), TotalAmount = 300.75m }
             };
        }
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }


}


// Customer Class
//public class Customer
//{
//    public int CustomerId { get; set; }
//    public string Name { get; set; }
//}

//// Order Class
//public class Order
//{
//    public int OrderId { get; set; }
//    public int CustomerId { get; set; }
//    public DateTime OrderDate { get; set; }
//}

//// Product Class (for three-table join example)
//public class Product
//{
//    public int ProductId { get; set; }
//    public string ProductName { get; set; }
//    public int OrderId { get; set; }
//}
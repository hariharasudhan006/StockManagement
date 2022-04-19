namespace StockManagement.db
{
    public static class Queries
    {
        public static string PasswordSelectionQuery => @"select password from Users where name=@Name;";
        public static string UserIdSelectionQuery => @"select id from Users where name=@Name;";
        
        public static string SelectHomeTable => 
            @"select Stock.id, Product.id, Product.Name, Product.pricePerUnit, Stock.price, Manufacturer.name 
            from ((Stock INNER JOIN Product on Stock.id = Product.stockId and Stock.userId = @uid) 
            INNER JOIN Manufacturer on Stock.manufactorerId = Manufacturer.id);";
    }
}
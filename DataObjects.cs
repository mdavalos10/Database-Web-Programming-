using System.Data;
using System.Data.SqlClient;

namespace DataObjects
{
    public class FactResellerSales
    {
        public int ProductKey { get; set; }
        public int OrderDateKey { get; set; }
        public int DueDateKey { get; set; }
        public int SalesTerritoryKey { get; set; }
    }

    public class DimSalesTerritory
    {
        public int SalesTerritoryKey { get; set; }
        public int SalesTerritoryAlternateKey { get; set; }
        public string? SalesTerritoryRegion { get; set; }
        public string? SalesTerritoryCountry { get; set; }
        public string? SalesTerritoryGroup { get; set; }

    }
    public class JoinTable
    {
        public int ProductKey { get; set; }
        public int OrderDateKey { get; set; }
        public int DueDateKey { get; set; }
        public int SalesTerritoryKey { get; set; }
        public int SalesTerritoryAlternateKey { get; set; }
        public string? SalesTerritoryRegion { get; set; }
        public string? SalesTerritoryCountry { get; set; }
        public string? SalesTerritoryGroup { get; set; }

    }
    

    public class DatabaseContext
    {
        public string ConnectionString { get; set; }

        public DatabaseContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<FactResellerSales> ReturnFactResellerSales()
        {
            List<FactResellerSales> fact_reseller_sales = new List<FactResellerSales>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT TOP 50 * FROM FactResellerSales", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FactResellerSales fact = new FactResellerSales();
                        fact.ProductKey = reader.GetInt32(reader.GetOrdinal("ProductKey"));
                        fact.OrderDateKey = reader.GetInt32(reader.GetOrdinal("OrderDateKey"));
                        fact.DueDateKey = reader.GetInt32(reader.GetOrdinal("DueDateKey"));
                        fact.SalesTerritoryKey = reader.GetInt32(reader.GetOrdinal("SalesTerritoryKey"));
                        fact_reseller_sales.Add(fact);
                    }
                }
            }

            return fact_reseller_sales;
        }

        public List<DimSalesTerritory> ReturnDimSalesTerritory()
        {
            List<DimSalesTerritory> dim_product_category = new List<DimSalesTerritory>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT TOP 50* FROM DimSalesTerritory", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DimSalesTerritory sales = new DimSalesTerritory();
                        
                        sales.SalesTerritoryKey = reader.GetInt32(reader.GetOrdinal("SalesTerritoryKey"));
                        sales.SalesTerritoryAlternateKey = reader.GetInt32(reader.GetOrdinal("SalesTerritoryAlternateKey"));
                        sales.SalesTerritoryRegion = reader.GetString(reader.GetOrdinal("SalesTerritoryRegion"));
                        sales.SalesTerritoryCountry = reader.GetString(reader.GetOrdinal("SalesTerritoryCountry"));
                        sales.SalesTerritoryGroup = reader.GetString(reader.GetOrdinal("SalesTerritoryGroup"));
                        dim_product_category.Add(sales);
                    }
                }
            }

            return dim_product_category;
        }

        public List<JoinTable> ReturnJoinTable()
        {
            List<JoinTable> join_table = new List<JoinTable>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT TOP 100 *  FROM  FactResellerSales frs Inner Join DimSalesTerritory dst ON dst.SalesTerritoryKey = frs.SalesTerritoryKey ", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JoinTable join = new JoinTable();
                        join.ProductKey = reader.GetInt32(reader.GetOrdinal("ProductKey"));
                        join.OrderDateKey = reader.GetInt32(reader.GetOrdinal("OrderDateKey"));
                        join.DueDateKey = reader.GetInt32(reader.GetOrdinal("DueDateKey"));
                        join.SalesTerritoryKey = reader.GetInt32(reader.GetOrdinal("SalesTerritoryKey"));
                        join.SalesTerritoryKey = reader.GetInt32(reader.GetOrdinal("SalesTerritoryKey"));
                        join.SalesTerritoryAlternateKey = reader.GetInt32(reader.GetOrdinal("SalesTerritoryAlternateKey"));
                        join.SalesTerritoryRegion = reader.GetString(reader.GetOrdinal("SalesTerritoryRegion"));
                        join.SalesTerritoryCountry = reader.GetString(reader.GetOrdinal("SalesTerritoryCountry"));
                        join.SalesTerritoryGroup = reader.GetString(reader.GetOrdinal("SalesTerritoryGroup"));
                        join_table.Add(join);
                    }
                }
            }

            return join_table;
        }
    }
}

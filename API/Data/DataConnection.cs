using System.Data.SqlTypes;

namespace API.Data
{
    public class DataConnection
    {
        private string sqlString = string.Empty;
        public DataConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            sqlString = builder.GetSection("ConnectionStrings:SqlString").Value;
        }

        public string GetConnectionString()
        {
            return sqlString;
        }
    }
}

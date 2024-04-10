using CustomerOperationsApi.Models;
using StackExchange.Redis;

namespace CustomerOperationsApi.Services
{
    public class DatabaseService
    {
        private static Lazy<ConnectionMultiplexer> _connectionMultiplexer;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return _connectionMultiplexer.Value;
            }
        }

        static DatabaseService()
        {
            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(() => 
            ConnectionMultiplexer.Connect("localhost")
            );
        }

       
        

    }
}

using System.Data;

namespace webshop_backend.Extensions
{
    public static class IDataReaderExtensions
    {
        public static bool IsNull(this IDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value;
        }

        public static int GetIntValue(this IDataReader reader, string columnName)
        {
            return Convert.ToInt32(reader[columnName]);
        }

        public static string GetStringValue(this IDataReader reader, string columnName)
        {
            return reader[columnName]?.ToString();
        }
    }
}

using Dapper;
using System.ComponentModel;
using System.Data;

namespace LondonStockExchange.Utility
{
    public static class DynamicParameterExtension
    {
        public static void AddTable<T>(this DynamicParameters parameters, string parameterName, string dataTableType, IEnumerable<T> values)
        {
            DataTable dataTable = new();

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            foreach(PropertyDescriptor property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            foreach(T item in  values)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach(PropertyDescriptor property in properties)
                    dataRow[property.Name] = property.GetValue(item) ?? DBNull.Value;

                dataTable.Rows.Add(dataRow);
            }

            parameters.Add(parameterName, dataTable.AsTableValuedParameter(dataTableType));
        }
    }
}

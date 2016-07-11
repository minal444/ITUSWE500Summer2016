namespace CampusConnectApplication.DataAccessLayer
{
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Data Access Object utility class
    /// </summary>
    public static class DAOUtility
    {
        /// <summary>
        /// Add IN Parameter
        /// </summary>
        /// <param name="command">sql command</param>
        /// <param name="paramname">parameter name</param>
        /// <param name="type">parameter type</param>
        /// <param name="value">parameter value</param>
        public static void AddInParameter(ref SqlCommand command, string paramname, DbType type, object value)
        {
            var parameter = CreateSqlParameter(paramname, type, value, ParameterDirection.Input);
            if (parameter != null)
            {
                command.Parameters.Add(parameter);
            }
        }

        /// <summary>
        /// Add OUT Parameter
        /// </summary>
        /// <param name="command">sql command</param>
        /// <param name="paramname">parameter name</param>
        /// <param name="type">parameter type</param>
        /// <param name="value">parameter value</param>
        public static void AddOutParameter(ref SqlCommand command, string paramname, DbType type, object value)
        {
            var parameter = CreateSqlParameter(paramname, type, value, ParameterDirection.Output);
            if (parameter != null)
            {
                command.Parameters.Add(parameter);
            }
        }

        /// <summary>
        /// Add Parameter
        /// </summary>
        /// <param name="command">sql command</param>
        /// <param name="paramname">parameter name</param>
        /// <param name="type">parameter type</param>
        /// <param name="value">parameter value</param>
        public static void AddParameter(ref SqlCommand command, string paramname, DbType type, object value)
        {
            var parameter = CreateSqlParameter(paramname, type, value, ParameterDirection.InputOutput);
            if (parameter != null)
            {
                command.Parameters.Add(parameter);
            }
        }

        /// <summary>
        /// Create a new parameter
        /// </summary>
        /// <param name="paramname">the sql parameter name</param>
        /// <param name="type">the parameter type</param>
        /// <param name="value">the parameter value</param>
        /// <param name="direction">the parameter direction</param>
        /// <returns>the newly created parameter</returns>
        private static SqlParameter CreateSqlParameter(string paramname, DbType type, object value, ParameterDirection direction)
        {
            var parameter = new SqlParameter
            {
                ParameterName = paramname,
                DbType = type,
                Direction = direction,
                Value = value
            };

            return parameter;
        }
    }
}
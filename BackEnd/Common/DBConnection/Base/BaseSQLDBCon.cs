using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Odbc;

namespace BackEnd.Data.DALBase
{
    public abstract class BaseSQLDBCon
    {


        #region "SQL Variables Declaration"

        //sql server connection 
        public static SqlConnection _sqlConnection = null;

        //sql server command
        public static SqlCommand _sqlCommand = null;

        //sql server parameter collection
        public static SqlParameterCollection _sqlParameterCol = null;

        //sql server transaction
        public static SqlTransaction _sqlTransaction = null;

        //sql server reader
        public static SqlDataReader _sqlReader = null;

        #endregion

        #region "Connection String"

        ///<summary>
        ///initializes sql server connection string
        ///</summary>
        ///<param name="pConnectionString">set the connection string value</param>
        protected static void InitializedConnection(string pConnectionString)
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(pConnectionString);
            }
        }

        /// <summary>
        /// opens sql server database connection
        /// </summary>
        protected static void OpenConnection()
        {

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            else if (_sqlConnection.State == ConnectionState.Broken)
            {
                _sqlConnection.Close();
                _sqlConnection.Open();
            }
        }

        /// <summary>
        /// closes sql server database connection
        /// </summary>
        public static void CloseConnection()
        {
            _sqlConnection.Close();
        }

        #endregion


        /// <summary>
        /// initializes sql server command
        /// </summary>
        /// <param name="pQuery">sets t-sql query to be executed</param>
        /// <param name="pType">sets query execution type: Text, StoredProcedure, TableDirect</param>
        protected static void InitializedCommand(string pQuery, CommandType pType)
        {
            _sqlCommand = new SqlCommand(pQuery, _sqlConnection)
            {
                CommandType = pType
            };
        }

        /// <summary>
        /// add parameters to sql server command
        /// </summary>
        /// <param name="pParameters">sets sql server parameter collection</param>
        protected static void AddParameters(SqlParameterCollection pParameters)
        {
            foreach (SqlParameter param in pParameters)
            {
                _sqlCommand.Parameters.AddWithValue(param.ParameterName, param.Value);
            }
        }

        /// <summary>
        /// SQLCommand.ExecuteNonQuery
        /// </summary>
        /// <param name="pQuery">sets t-sql query to be executed</param>
        /// <param name="pParameters">optional parameter, sets the parameter collection to be included in sql server command SQLCommand</param>
        public static void ExecuteNonQuery(string pQuery, SqlParameterCollection pParameters = null)
        {
            InitializedCommand(pQuery, CommandType.Text);

            if (pParameters != null)
            {
                AddParameters(pParameters);
            }

            OpenConnection();

            _sqlCommand.ExecuteNonQuery();

            CloseConnection();
        }

        /// <summary>
        /// SQLCommand.ExecuteScalar
        /// </summary>
        /// <param name="pQuery">sets t-sql query to be executed</param>
        /// <param name="pParameters">optional parameter, sets the parameter collection to be included in sql server command SQLCommand</param>
        /// <returns>gets execution result into an object type variable</returns>
        public static object ExecuteScalar(string pQuery, SqlParameterCollection pParameters = null)
        {
            object _resultado = null;

            InitializedCommand(pQuery, CommandType.Text);

            if (pParameters != null)
            {
                AddParameters(pParameters);
            }

            OpenConnection();

            _resultado = _sqlCommand.ExecuteScalar();

            CloseConnection();

            return _resultado;
        }

        /// <summary>
        /// SQLCommand.ExecuteReader
        /// </summary>
        /// <param name="pQuery">sets t-sql query to be executed</param>
        /// <param name="pParameters">optional parameter, sets the parameter collection to be included in sql server command SQLCommand</param>
        /// <returns>gets execution result into an object type generic list</returns>
        public static SqlDataReader ExecuteReader(string pQuery, SqlParameterCollection pParameters = null)
        {
            var _readerList = new List<object>();

            InitializedCommand(pQuery, CommandType.Text);

            if (pParameters != null)
            {
                AddParameters(pParameters);
            }

            OpenConnection();

            var reader = _sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ComplicanceFactor.DataAccessLayer
{
    public class DataProxy
    {
        /// <summary>
        /// A static variable for connectionString
        /// </summary>
       // private static readonly string connectionString =  ConfigurationSettings.AppSettings["ConnectionString"];
        private static readonly string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProxy"/> class.
        /// </summary>
        private DataProxy()
        {

        }

        /// <summary>
        /// Fetches the data set.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        /// <returns>DataTable</returns>
        public static DataSet FetchDataSet(string storedProcedure, IDictionary paramAndValue)
        {
            try
            {
                return SqlHelper.FetchDataSet(connectionString, storedProcedure, paramAndValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fetches the SP output.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        /// <returns>Integer</returns>
        public static int FetchSPOutput(string storedProcedure, IDictionary paramAndValue)
        {
            try
            {
                return SqlHelper.ExcecuteSPOutput(connectionString, storedProcedure, paramAndValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fetches the data set.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>DataSet</returns>
        public static DataSet FetchDataSet(string storedProcedure)
        {
            try
            {
                return SqlHelper.FetchDataSet(connectionString, storedProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fetches the data table.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        /// <returns>DataTable</returns>
        public static DataTable FetchDataTable(string storedProcedure, IDictionary paramAndValue)
        {
            try
            {
                return SqlHelper.FetchDataTable(connectionString, storedProcedure, paramAndValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fetches the data table.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>DataTable</returns>
        public static DataTable FetchDataTable(string storedProcedure)
        {
            try
            {
                return SqlHelper.FetchDataTable(connectionString, storedProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executes the SP.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        public static void ExecuteSP(string storedProcedure, IDictionary paramAndValue)
        {
            try
            {
                SqlHelper.ExcecuteSP(connectionString, storedProcedure, paramAndValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executes the SP.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        public static void ExecuteSP(string storedProcedure)
        {
            try
            {
                SqlHelper.ExcecuteSP(connectionString, storedProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataReader ExecuteReader(string storedProcedure, IDictionary paramAndValue)
        {
            try
            {
                return SqlHelper.ExecuteReader(connectionString, storedProcedure, paramAndValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ExecuteScalar(string storedProcedure, IDictionary paramAndValue)
        {
            try
            {
                return SqlHelper.ExecuteScalar(connectionString, storedProcedure, paramAndValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

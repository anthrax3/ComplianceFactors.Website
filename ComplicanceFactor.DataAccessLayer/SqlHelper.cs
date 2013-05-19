using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace ComplicanceFactor.DataAccessLayer
{
   public  class SqlHelper
    {
        public SqlHelper()
        {

        }
        #region Public Members
        /// <summary>
        /// Excecutes the SP.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        public static void ExcecuteSP(string connectionString, string storedProcedure, IDictionary paramAndValue)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                ////To read the Param and Value from Hashtable value
                IDictionaryEnumerator paramValueEnum = paramAndValue.GetEnumerator();
                while (paramValueEnum.MoveNext())
                {
                    ////Set the SP Param and its corresponding Value
                    SqlParameter param = new SqlParameter(paramValueEnum.Key.ToString(), paramValueEnum.Value);
                    ////Add the Parameter
                    command.Parameters.Add(param);
                }

                connection.Open();
                command.ExecuteNonQuery();
                //// Detach the SqlParameters from the command object, so they can be used again
                command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = null;
            }
        }

        /// <summary>
        /// Excecutes the SP.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        public static void ExcecuteSP(string connectionString, string storedProcedure)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = null;
            }
        }

        /// <summary>
        /// Excecutes the SP output.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        /// <returns>"DataSet"</returns>
        public static int ExcecuteSPOutput(string connectionString, string storedProcedure, IDictionary paramAndValue)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                ////To read the Param and Value from Hashtable value
                IDictionaryEnumerator paramValueEnum = paramAndValue.GetEnumerator();
                while (paramValueEnum.MoveNext())
                {
                    ////Set the SP Param and its corresponding Value
                    SqlParameter param = new SqlParameter(paramValueEnum.Key.ToString(), paramValueEnum.Value);
                    ////Add the Parameter
                    command.Parameters.Add(param);
                }

                //// Create the DataAdapter & DataSet
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();
                    //// Fill the DataSet using default values for DataTable names, etc
                    adapter.Fill(ds);
                    //adapter.SelectCommand.CommandTimeout = 0;
                    //// Detach the SqlParameters from the command object, so they can be used again
                    command.Parameters.Clear();
                    //// Return the int value from dataset
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = null;
            }
        }

        /// <summary>
        /// Fetches the data set.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        /// <returns>"DataSet"</returns>
        public static DataSet FetchDataSet(string connectionString, string storedProcedure, IDictionary paramAndValue)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                ////To read the Param and Value from Hashtable value
                IDictionaryEnumerator paramValueEnum = paramAndValue.GetEnumerator();

                while (paramValueEnum.MoveNext())
                {
                    ////Set the SP Param and its corresponding Value

                    SqlParameter param = new SqlParameter(paramValueEnum.Key.ToString(), paramValueEnum.Value);
                    ////Add the Parameter
                    command.Parameters.Add(param);
                }
                //// Create the DataAdapter & DataSet
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();
                    //// Fill the DataSet using default values for DataTable names, etc
                    adapter.Fill(ds);
                    //// Detach the SqlParameters from the command object, so they can be used again
                    command.Parameters.Clear();
                    //// Return the dataset
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = null;
            }
        }

        /// <summary>
        /// Fetches the data set.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>"DataSet"</returns>
        public static DataSet FetchDataSet(string connectionString, string storedProcedure)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                using (SqlDataAdapter adapter = new SqlDataAdapter(storedProcedure, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = null;
            }
        }

        /// <summary>
        /// Fetches the data table.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="paramAndValue">The param and value.</param>
        /// <returns>"DataTable"</returns>
        public static DataTable FetchDataTable(string connectionString, string storedProcedure, IDictionary paramAndValue)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                ////To read the Param and Value from Hashtable value
                IDictionaryEnumerator paramValueEnum = paramAndValue.GetEnumerator();

                while (paramValueEnum.MoveNext())
                {
                    ////Set the SP Param and its corresponding Value
                    SqlParameter param = new SqlParameter(paramValueEnum.Key.ToString(), paramValueEnum.Value);
                    ////Add the Parameter
                    command.Parameters.Add(param);
                }

                //// Create the DataAdapter & DataSet
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    //// Fill the DataSet using default values for DataTable names, etc
                    adapter.Fill(dt);
                    //// Detach the SqlParameters from the command object, so they can be used again
                    command.Parameters.Clear();
                    //// Return the datatable
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = null;
            }
        }

        /// <summary>
        /// Fetches the data table.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>"DataTable"</returns>
        public static DataTable FetchDataTable(string connectionString, string storedProcedure)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                using (SqlDataAdapter adapter = new SqlDataAdapter(storedProcedure, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = null;
            }
        }


        ///Code By Pixel
        /// <summary>
        /// Fetches the record using dataReader.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>"DataReader"</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string storedProcedure, IDictionary paramAndValue)
        {
            SqlConnection connection = null;
            //SqlDataReader drReturn;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                ////To read the Param and Value from Hashtable value
                IDictionaryEnumerator paramValueEnum = paramAndValue.GetEnumerator();

                while (paramValueEnum.MoveNext())
                {
                    ////Set the SP Param and its corresponding Value
                    SqlParameter param = new SqlParameter(paramValueEnum.Key.ToString(), paramValueEnum.Value);
                    ////Add the Parameter
                    command.Parameters.Add(param);
                }

                //return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
                return command.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                //if (connection.State == ConnectionState.Open)
                //{
                //    connection.Close();
                //}

                connection = null;
            }
        }

        ///Code By Pixel
        /// <summary>
        /// Fetches the record using dataReader.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>"DataReader"</returns>
        public static int ExecuteScalar(string connectionString, string storedProcedure, IDictionary paramAndValue)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                ////To read the Param and Value from Hashtable value
                IDictionaryEnumerator paramValueEnum = paramAndValue.GetEnumerator();

                while (paramValueEnum.MoveNext())
                {
                    ////Set the SP Param and its corresponding Value
                    SqlParameter param = new SqlParameter(paramValueEnum.Key.ToString(), paramValueEnum.Value);
                    ////Add the Parameter
                    command.Parameters.Add(param);
                }

                //return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
                return Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if (connection.State == ConnectionState.Open)
                //{
                //    connection.Close();
                //}

                connection = null;
            }
        }

        #endregion
    }
}

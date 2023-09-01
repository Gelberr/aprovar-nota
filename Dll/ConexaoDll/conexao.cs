using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoDll
{
    public class conexao
    {

        private string stringConexao = "Server=LAPTOP-T31M9VFP\\SQLEXPRESS;Database=AprovacaoNota;User Id=sa;Password=12345678;MultipleActiveResultSets=true;TrustServerCertificate=true;";
        private SqlConnection _connection;
        private SqlTransaction transaction = null;
        private bool transactionIsOpen = false;

        public conexao()
        {
            try
            {
                _connection = new SqlConnection(stringConexao);

            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public void Dispose()
        {
            this._connection.Dispose();
        }

        public void Open()
        {
            if (_connection != null && _connection.State == ConnectionState.Closed)
            {
                this._connection.Open();
            }
        }

        public void Close()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
        }

        public void BeginTransaction()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                if (transaction == null && !transactionIsOpen)
                {
                    transaction = _connection.BeginTransaction();
                    transactionIsOpen = true;
                }
            }
        }

        public void CommitTransaction()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                if (transaction != null && transactionIsOpen)
                {
                    transaction.Commit();
                    transactionIsOpen = false;
                }
            }

        }

        public bool IsOpen()
        {
            return this._connection.State == ConnectionState.Open;
        }

        public bool ExisteTransacao()
        {
            return transactionIsOpen;
        }

        public void RollBackTransaction()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                if (transaction != null && transactionIsOpen)
                {
                    transaction.Rollback();
                    transactionIsOpen = false;
                }
            }
        }

        public SqlConnection Get()
        {

            try
            {
                return this._connection;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public SqlDataReader ExecuteReader(string query)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {
                    return sqlCommand.ExecuteReader();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public SqlDataReader ExecuteReader(string query, SqlParameter parameters)
        {
            try
            {

                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {

                    sqlCommand.Parameters.Add(parameters);

                    return sqlCommand.ExecuteReader();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public SqlDataReader ExecuteReaderParametroLista(string query, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {

                    sqlCommand.Parameters.AddRange(parameters.ToArray());

                    return sqlCommand.ExecuteReader();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {
                    return sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {
                    sqlCommand.Parameters.AddRange(parameters.ToArray());

                    return sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public int ExecuteNonQueryTransaction(string query, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection, transaction))
                {
                    sqlCommand.Parameters.AddRange(parameters.ToArray());

                    return sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTable ExecuteDataTable(string query)
        {
            try
            {
                using (SqlDataAdapter DataTable = new SqlDataAdapter(query, _connection))
                {
                    using (DataTable table = new DataTable())
                    {
                        DataTable.Fill(table);
                        return table;
                    }
                }



            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagement.DB_query
{
    internal class PharmacyMgtDatabase : DataTable
    {
        #region
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand command;
        #endregion

        #region Connect Database
        public string ConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Server"] = ".\\SQLEXPRESS";
            builder["Database"] = "PharmacyMgtSys";
            builder["Integrated Security"] = "True";
            return builder.ConnectionString;
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection == null)
                    connection = new SqlConnection(ConnectionString());
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }
        #endregion 

        #region Query Select, Insert, Update, Delete
        public void Fill(SqlCommand selectCommand)
        {
            command = selectCommand;
            try
            {
                command.Connection = connection;

                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                this.Clear();
                adapter.Fill(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid query error!\nError: " + 
                    ex.Message, "Query error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        // Thực thi câu lệnh Insert, Update, Delete
        public int Update(SqlCommand insertUpdateDeleteCommand)
        {
            int result = 0;
            SqlTransaction transaction = null;
            try
            {
                transaction = connection.BeginTransaction();

                insertUpdateDeleteCommand.Connection = connection;
                insertUpdateDeleteCommand.Transaction = transaction;
                result = insertUpdateDeleteCommand.ExecuteNonQuery();

                this.AcceptChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                if (transaction != null)
                    transaction.Rollback();
                MessageBox.Show("Invalid query error!\nError: " + 
                    e.Message, "Query error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion
    }
}

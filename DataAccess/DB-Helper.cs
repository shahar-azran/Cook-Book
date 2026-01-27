using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace Cook_Book.DataAccess
{
    public class DB_Helper
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter DataAdapter;
        OleDbTransaction Transaction;

        public DB_Helper()
        {
            this.connection = new OleDbConnection();
            this.command = new OleDbCommand();
            this.command.Connection = this.connection;
            //this.connection.ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{Directory.GetCurrentDirectory()}\CookBook.accdb'";
            this.connection.ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\computer\CookBook\Cook-Book\App_Data\CookBook.accdb'";

        }

        public void OpenConnection()
        {
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
        }
        public void CloseConnection()
        {
            if(this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
        }
        public int ChangeDb(string sgl)
        {
            this.command.CommandText = sgl;
            return this.command.ExecuteNonQuery();
        }
        public DataTable GetDataTable(string sql, string tableName)
        {
            if(this.DataAdapter == null)
            {
                this.DataAdapter = new OleDbDataAdapter();
            }
            this.command.CommandText = sql;
            this.DataAdapter.SelectCommand = this.command;
            DataTable dt = new DataTable(tableName);
            this.DataAdapter.Fill(dt);
            return dt;
        }
        public void OpenTransaction()
        {
            this.Transaction = this.connection.BeginTransaction();
            this.command.Transaction = this.Transaction;
        }
        public void CommitTransaction()
        {
            this.Transaction.Commit();  
        }
        public void RollBackTransaction()
        {
            this.Transaction.Rollback();
        }
    }
}

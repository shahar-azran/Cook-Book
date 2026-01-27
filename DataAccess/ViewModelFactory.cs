using System.Data;
using Cook_Book.Models;

namespace Cook_Book.DataAccess
{
    public class ViewModelFactory
    {
        ModelFactory modelFactory;
        DB_Helper dbHelper;

        public ViewModelFactory(DB_Helper dbHelper)
        {
            this.dbHelper = dbHelper;
            this.modelFactory = new ModelFactory();
        }

        public string LoginUser(string username, string password)
        {
            string sql = $@"Select UserId from Users
                            where UserName = '{username}'
                            and UserPassword = '{password}'";
            DataTable dataTable = this.dbHelper.GetDataTable(sql, "Users");
            if(dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0]["UserId"].ToString();
        }
        
        public string AddNewUser(User user)
        {
            string sql = $@"Insert into User(UserId, UserName, UserTel,
                            UserEmail, UserPassword)
                            values('{user.GetUserId()}',
                                    '{user.GetUserName()}'
                                    '{user.GetUserTel()}'
                                    '{user.GetUserEmail}'
                                    '{user.GetUserPassword()}')";
            if (this.dbHelper.ChangeDb(sql) > 0)
            {
                return user.GetUserId();
            }
            return null;
        }
    }
}

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

        public UserData LoginUser(string username, string password)
        {
            string sql = "Select * from Users";
            DataTable dataTable = this.dbHelper.GetDataTable(sql, "Users");

            foreach (DataRow row in dataTable.Rows)
            {
                string dbUserName = row["UserName"]?.ToString().Trim();
                string dbPassword = row["UserPassword"]?.ToString().Trim();

                if (dbUserName == username.Trim() && dbPassword == password.Trim())
                {
                    UserData userData = this.modelFactory.GetUserData(row);
                    return userData;
                }
            }

            return null;
        }

        public string AddNewUser(User user)
        {
            string sql = $@"Insert into [Users](UserId, [UserName], UserTel,
                            UserEmail, UserPassword)
                            values('{user.GetUserId()}',
                                    '{user.GetUserName()}',
                                    '{user.GetUserTel()}',
                                    '{user.GetUserEmail()}',
                                    '{user.GetUserPassword()}')";
            this.dbHelper.OpenConnection();
            if (this.dbHelper.ChangeDb(sql) > 0)
            {
                this.dbHelper.CloseConnection();
                return user.GetUserId();
            }
            return null;
        }

        public bool AddNewRecipes(Recipes recipes)
        {
            string sql = $@"Insert into Recipes(RecipesName, DishPhoto, CatId,
                            PreperationMethod, UserId)
                            values('{recipes.GetRecipesName()}',
                                    '{recipes.GetDishPhoto()}',
                                    '{recipes.GetCatId()}',
                                    '{recipes.GetPreperationMethod()}',
                                    '{recipes.GetUserId()}')";
            this.dbHelper.OpenConnection();
            if (this.dbHelper.ChangeDb(sql) > 0)
            {
                this.dbHelper.CloseConnection();
                return true;
            }
            return false;

        }

        public CookBookViewModel GetAllRecieps()
        {
            string sql = @"Select * from Recipes";
            DataTable dataTable = this.dbHelper.GetDataTable(sql, "Recipes");
            string sql2 = @"Select * from RecipeCatagories";
            DataTable dataTable2 = this.dbHelper.GetDataTable(sql2, "RecipeCatagories");
            CookBookViewModel cookBookViewModel = new CookBookViewModel(dataTable.Rows.Count, dataTable2.Rows.Count);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cookBookViewModel.AddRecipes(this.modelFactory.GetRecipes(dataTable.Rows[i]));
            }
            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                cookBookViewModel.AddRecipeCatagory(this.modelFactory.GetRecipeCatagories(dataTable2.Rows[i]));
            }
            return cookBookViewModel;
        }
        public Recipes GetRecipeById(string recipeId)
        {
            string sql = $@"Select * from Recipes where RecipesId = '{recipeId}'";
            DataTable dataTable = this.dbHelper.GetDataTable(sql, "Recipes");
            if (dataTable.Rows.Count > 0)
            {
                return this.modelFactory.GetRecipes(dataTable.Rows[0]);
            }
            return null;
        }
        public CookBookViewModel GetRecipesByUserId(string userId)
        {
            string sql = $@"Select * from Recipes where UserId = '{userId}'";
            DataTable dataTable = this.dbHelper.GetDataTable(sql, "Recipes");
            string sql2 = @"Select * from RecipeCatagories";
            DataTable dataTable2 = this.dbHelper.GetDataTable(sql2, "RecipeCatagories");

            CookBookViewModel cookBookViewModel = new CookBookViewModel(dataTable2.Rows.Count, dataTable.Rows.Count);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cookBookViewModel.AddRecipes(this.modelFactory.GetRecipes(dataTable.Rows[i]));
            }

            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                cookBookViewModel.AddRecipeCatagory(this.modelFactory.GetRecipeCatagories(dataTable2.Rows[i]));
            }

            return cookBookViewModel;
        }
        public bool DeleteUser(string userId)
        {
            string sql = $@"DELETE FROM Users WHERE UserId = '{userId}'";

            this.dbHelper.OpenConnection();
            int rowsAffected = this.dbHelper.ChangeDb(sql);
            this.dbHelper.CloseConnection();

            return rowsAffected > 0;
        }
    }
}

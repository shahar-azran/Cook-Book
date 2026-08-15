using System.Data;
using Cook_Book.Models;

namespace Cook_Book.DataAccess
{
    public class ModelFactory
    {
        public UserData GetUserData(DataRow dataRow)
        {
            string UserId = dataRow["UserId"].ToString();
            string UserName = dataRow["UserName"].ToString();
          
            return new UserData(UserId, UserName);
        }
        public User GetUser(DataRow dataRow)
        {   
            string UserId = dataRow["UserId"].ToString();
            string UserName = dataRow["UserName"].ToString();
            string UserTel = dataRow["UserTel"].ToString();
            string UserEmail = dataRow["UserEmail"].ToString();
            string UserPassword = dataRow["UserPassword"].ToString();
            return new User(UserId, UserName, UserTel, UserEmail, UserPassword);
        }
        public Recipes GetRecipes(DataRow dataRow)
        {
            string DishPhoto = dataRow["DishPhoto"].ToString();
            string PreperationMethod = dataRow["PreperationMethod"].ToString();
            string UserId = dataRow["UserId"].ToString();
            string RecipesName = dataRow["RecipesName"].ToString();
            int CatId = int.Parse(dataRow["CatId"].ToString());
            return new Recipes(DishPhoto, PreperationMethod, UserId, RecipesName, CatId);
        }

        public RecipeCatagories GetRecipeCatagories(DataRow dataRow)
            {
                int recipeCatagoryId = int.Parse(dataRow["CatId"].ToString());
                string recipeCatagoryName = dataRow["CatagoryName"].ToString();
                return new RecipeCatagories(recipeCatagoryId, recipeCatagoryName);
            }
    }
}

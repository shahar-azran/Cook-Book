using System.Data;
using Cook_Book.Models;

namespace Cook_Book.DataAccess
{
    public class ModelFactory
    {
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
            string RecipesId = dataRow["RecipesId"].ToString();
            string DishPhoto = dataRow["DishPhoto"].ToString();
            int IngredientsId = int.Parse(dataRow["IngredientsId"].ToString());
            string PreperationMethod = dataRow["PreperationMethod"].ToString();
            string UserId = dataRow["UserId"].ToString();
            return new Recipes(RecipesId, DishPhoto, IngredientsId, PreperationMethod, UserId);
        }
        public Ingredients GetIngredients(DataRow dataRow)
        {
            int ingredientsId = int.Parse(dataRow["IngredientsId"].ToString());
            string ingredientsName = dataRow["ingredientsName"].ToString();
            string ingredientsPhoto = dataRow["ingredientsPhoto"].ToString();
            return new Ingredients(ingredientsId, ingredientsName, ingredientsPhoto);
        }
    }
}

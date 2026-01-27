namespace Cook_Book.Models
{
    public class Recipes
    {
        string RecipesId;
        string DishPhoto;
        int IngredientsId;
        string PreperationMethod;
        string UserId;

        public Recipes(string RecipesId, string DishPhoto, int IngredientsId, string PreperationMethod, string UserId)
        {
            this.RecipesId = RecipesId;
            this.DishPhoto = DishPhoto;
            this.IngredientsId = IngredientsId;
            this.PreperationMethod = PreperationMethod;
            this.UserId = UserId;
        }
        public string GetRecipesId()
        {
            return this.RecipesId;
        }
        public void SetRecipesId(string RecipesId)
        {
            this.RecipesId = RecipesId;
        }
        public string GetDishPhoto()
        {
            return this.DishPhoto;
        }
        public void SetDishPhoto(string DishPhoto)
        {
            this.DishPhoto = DishPhoto;
        }
        public int GetIngredientsId()
        {
            return this.IngredientsId;
        }
        public void SetIngredientsId(int IngredientsId)
        {
            this.IngredientsId = IngredientsId;
        }
        public string GetPreperationMethod()
        {
            return this.PreperationMethod;
        }
        public void SetPreperationMethod(string PreperationMethod)
        {
            this.PreperationMethod = PreperationMethod;
        }
        public string GetUserId()
        {
            return this.UserId;
        }
        public void SetUserId(string UserId)
        {
            this.UserId = UserId;
        }


    }
}

namespace Cook_Book.Models
{
    public class Recipes
    {
        string RecipesName;
        string DishPhoto;
        string PreperationMethod;
        string UserId;
        int CatId;

        public Recipes(string DishPhoto, string PreperationMethod, string UserId, string RecipesName, int CatId)
        {
            this.RecipesName = RecipesName;
            this.DishPhoto = DishPhoto;
            this.PreperationMethod = PreperationMethod;
            this.UserId = UserId;
            this.CatId = CatId;
        }
        public string GetDishPhoto()
        {
            return this.DishPhoto;
        }
        public void SetDishPhoto(string DishPhoto)
        {
            this.DishPhoto = DishPhoto;
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
        public string GetRecipesName()
        {
            return this.RecipesName;
        }
        public void SetRecipesName(string RecipesName)
        {
            this.RecipesName = RecipesName;
        }
        public int GetCatId()
        {
            return this.CatId;
        }
        public void SetCatId(int CatId)
        {
            this.CatId = CatId;
        }

        public override string ToString()
        {
            return $@",DishPhoto: {this.DishPhoto}, 
                    PreperationMethod: {this.PreperationMethod},
                    UserId: {this.UserId},
                    RecipesName: {this.RecipesName},
                    CatId: {this.CatId}";
        }

    }
}

namespace Cook_Book.Models
{
    public class Ingredients
    {
        int ingredientsId;
        string ingredientsName;
        string ingredientsPhoto;

        public Ingredients(int ingredientsId, string ingredientsName, string ingredientsPhoto)
        {
            this.ingredientsId = ingredientsId;
            this.ingredientsName = ingredientsName;
            this.ingredientsPhoto = ingredientsPhoto;
        }
        public int GetIngredientsId()
        {
            return this.ingredientsId;
        }
        public void SetIngredientsId(int ingredientsId)
        {
            this.ingredientsId = ingredientsId;
        }
        public string GetIngredientsName()
        {
            return this.ingredientsName;
        }
        public void SetIngredientsName(string ingredientsName)
        {
            this.ingredientsName = ingredientsName;
        }
        public string GetIngredientsPhoto()
        {
            return this.ingredientsPhoto;
        }
        public void SetIngredientsPhoto(string ingredientsPhoto)
        {
            this.ingredientsPhoto = ingredientsPhoto;
        }


    }
}

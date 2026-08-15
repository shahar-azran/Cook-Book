namespace Cook_Book.Models
{
    public class CookBookViewModel
    {
        RecipeCatagories[] recipeCatagories;
        Recipes[] recipes;
        int recipeCatagoriesCount;
        int recipesCount;

        public CookBookViewModel(int CatagoriesCount, int recipesCount)
        {
            this.recipeCatagories = new RecipeCatagories[CatagoriesCount];
            this.recipes = new Recipes[recipesCount];
            
            this.recipeCatagoriesCount = 0;
            this.recipesCount = 0;
        }
        public void AddRecipeCatagory(RecipeCatagories recipeCatagory)
        {
            this.recipeCatagories[this.recipeCatagoriesCount] = recipeCatagory;
            this.recipeCatagoriesCount++;
        }
        public void AddRecipes(Recipes recipes)
        {
            if (this.recipes == null)
            {
                this.recipes = new Recipes[0];
            }

            Array.Resize(ref this.recipes, this.recipes.Length + 1);

            this.recipes[this.recipesCount] = recipes;
            this.recipesCount++;
        }
        public RecipeCatagories GetRecipeCatagory(int index)
        {
            return this.recipeCatagories[index];
        }
        public Recipes GetRecipes(int index)
        {
            return this.recipes[index];
        }
        public int GetRecipeCatagoriesCount()
        {
            return this.recipeCatagoriesCount;
        }
        public int GetRecipeCount()
        {
            return this.recipesCount;
        }
    }
}

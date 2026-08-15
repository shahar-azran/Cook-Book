namespace Cook_Book.Models
{
    public class RecipeCatagories
    {
        string CatagoryName;
        int CatId;

        public RecipeCatagories(int CatId, string CatagoryName)
        {
            this.CatId = CatId;
            this.CatagoryName = CatagoryName;
        }

        public int GetCatId()
        {
            return this.CatId;
        }

        public string GetCatagoryName()
        {
            return this.CatagoryName;
        }
    }
}

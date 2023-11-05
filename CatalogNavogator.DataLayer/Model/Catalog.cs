namespace CatalogNavigator.DataLayer.Model
{
    public class Catalog
    {
        public Catalog()
        {
            SubCatalogs = new List<Catalog>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<Catalog> SubCatalogs { get; set; }
    }
}
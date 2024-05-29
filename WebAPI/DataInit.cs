using WebAPI.Model;

namespace WebAPI
{
    public static class DataInit
    {

        public static List<Owner> _owners { get; }
        public static List<Product> _products { get; }
        static DataInit()
        {
            _owners = new List<Owner>();
            _owners.Add(new Owner()
            {
                Id = 1,
                Name = "Beta Aquilae Happy Cutter Scrapyard"
            });

            _products = new List<Product>();
            _products.Add(new Product
            {
                Id = 1,
                Name = "U.S.S. Enterprise B",
                Description = "Out of commission United Federation ship. To be sold for scrap.",
                Owner = _owners[0]
            });

        }
      

    }
}

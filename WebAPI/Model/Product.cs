namespace WebAPI.Model
{
    public class Product : AbstractEntity, IEntity
    {
        public int Id { get ; set; }

        public string Description { get; set; }

        public Owner Owner { get; set; }
    }
}

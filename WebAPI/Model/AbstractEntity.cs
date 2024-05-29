using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class AbstractEntity
    {
        [StringLength(200, ErrorMessage ="Maximum allowed number of characters: 200")]
        public string Name { get; set; }
    }
}

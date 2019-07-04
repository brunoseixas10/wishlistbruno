using Wishlist.Model.Interfaces;

namespace Wishlist.Model.Entities
{
    public abstract class BaseModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

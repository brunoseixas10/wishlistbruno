using Newtonsoft.Json;
using System.Collections.Generic;
using Wishlist.Model.Interfaces;

namespace Wishlist.Model.Entities
{
    public sealed class Wishlist : IBaseModel
    {
        public IList<Product> Products { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}

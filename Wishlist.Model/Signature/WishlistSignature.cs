using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Wishlist.Bo.Interfaces;
using Wishlist.Model.Entities;
using Wishlist.Model.Interfaces;

namespace Wishlist.Model.Signature
{
    public sealed class WishlistSignature : IBaseModel, IValidator<WishlistSignature>, IConverter<WishlistSignature, Model.Entities.Wishlist>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public IList<WishlistProductSignature> Products { get; set; }

        public Entities.Wishlist Convert()
        {
            var obj = new Entities.Wishlist()
            {
                User = new User() { Id = UserId },
                Products = new List<Product>()
            };
            foreach (var i in Products)
                obj.Products.Add(new Product() { Id = i.idProduct });

            return obj;
        }

        public bool IsValid()
        {
            if (this == null)
                return false;
            if (this.Products == null)
                return false;
            if (this.Products.Count == 0)
                return false;
            if (this.Products.Any(x => x.idProduct <= 0))
                return false;

            return true;
        }
    }
}

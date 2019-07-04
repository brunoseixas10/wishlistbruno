using Wishlist.Bo.Interfaces;
using Wishlist.Model.Entities;
using Wishlist.Model.Interfaces;

namespace Wishlist.Model.Signature
{
    public sealed class ProductSignature : IBaseModel, IValidator<ProductSignature>, IConverter<ProductSignature, Product>
    {
        public string Name { get; set; }

        public Product Convert()
        {
            return new Product()
            {
                Name = this.Name
            };
        }

        public bool IsValid()
        {
            if (this == null)
                return false;

            if (string.IsNullOrWhiteSpace(this.Name))
                return false;

            return true;
        }
    }
}

using Wishlist.Bo.Interfaces;
using Wishlist.Model.Entities;
using Wishlist.Model.Interfaces;

namespace Wishlist.Model.Signature
{
    public sealed class UserSignature : IBaseModel, IValidator<UserSignature>, IConverter<UserSignature, User>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User Convert()
        {
            return new User()
            {
                Name = this.Name,
                Email = this.Email
            };
        }

        public bool IsValid()
        {
            if (this == null)
                return false;

            if (string.IsNullOrWhiteSpace(this.Name))
                return false;

            if (string.IsNullOrWhiteSpace(this.Email))
                return false;

            return true;
        }
    }
}

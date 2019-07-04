using Wishlist.Model.Interfaces;

namespace Wishlist.Bo.Interfaces
{
    public interface IValidator<T> where T : IBaseModel
    {
        bool IsValid();
    }
}

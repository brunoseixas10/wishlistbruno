namespace Wishlist.Model.Interfaces
{
    public interface IConverter<T, Y>
        where T : IBaseModel
        where Y : IBaseModel
    {
        Y Convert();
    }
}

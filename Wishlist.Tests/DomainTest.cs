using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Bo;
using Wishlist.Repository;
using Xunit;

namespace Wishlist.Tests
{
    public class DomainTest
    {
        private readonly UserBo userBo;
        private readonly ProductBo productBo;
        private readonly WishlistBo wishlistBo;

        public DomainTest()
        {
            userBo = new UserBo(new UserRepository());
            productBo = new ProductBo(new ProductRepository());
            wishlistBo = new WishlistBo(new WishlistRepository());
        }

        #region Tests

        [Fact]
        public async Task TestAllMethods()
        {
            await Test1Users();
            await Test2Products();
            await Test3Wishlist();
            await Test4Wishlist();
        }

        #endregion

        #region private Methods

        private async Task CreateUser()
        {
            await userBo.Create(new Model.Signature.UserSignature()
            {
                Email = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            });
        }

        private async Task CreateProduct()
        {
            await productBo.Create(new Model.Signature.ProductSignature()
            {
                Name = Guid.NewGuid().ToString()
            });
        }

        private async Task CreateWishlist()
        {
            var product = new List<Model.Signature.WishlistProductSignature>(1);
            product.Add(new Model.Signature.WishlistProductSignature() { idProduct = 1 });

            await wishlistBo.Create(new Model.Signature.WishlistSignature()
            {
                Products = product,
                UserId = 1
            });
        }

        private async Task Test1Users()
        {
            await CreateUser();
            var res = await userBo.List(10, 1);
            Assert.NotNull(res);
            Assert.True(res.Count == 1);
            Assert.True(res[0].Id == 1);
        }
        private async Task Test2Products()
        {
            await CreateProduct();
            var res = await productBo.List(10, 1);
            Assert.NotNull(res);
            Assert.True(res.Count == 1);
            Assert.True(res[0].Id == 1);
        }
        private async Task Test3Wishlist()
        {
            await CreateWishlist();
            var res = await wishlistBo.List(1, 10, 1);
            Assert.NotNull(res);
            Assert.True(res.Count == 1);
        }
        private async Task Test4Wishlist()
        {
            await wishlistBo.Remove(1, 1);
            var res = await wishlistBo.List(1, 10, 1);
            Assert.NotNull(res);
            Assert.True(res.FirstOrDefault().Products.Count == 0);
        }

        #endregion
    }
}

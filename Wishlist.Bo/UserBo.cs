using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wishlist.Bo.Interfaces;
using Wishlist.Model.Entities;
using Wishlist.Repository.Interfaces;

namespace Wishlist.Bo
{
    public sealed class UserBo : IUserBo
    {
        private readonly IUserRepository _userRepository;

        public UserBo(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(Model.Signature.UserSignature obj)
        {
            if (!obj.IsValid()) throw new ArgumentException(nameof(obj));
            await _userRepository.Create(obj.Convert());
        }

        public Task<IList<User>> List(int pageSize, int page)
        {
            if (pageSize <= 0) throw new ArgumentException("Invalid pageSize", nameof(pageSize));
            if (page <= 0) throw new ArgumentException("Invalid page", nameof(page));
            return _userRepository.List(pageSize, page);
        }
    }
}

using Model;
using System;

namespace InterfaceBusiness
{
    public interface IUserRepository
    {
        User GetUser(int userId);
    }
}

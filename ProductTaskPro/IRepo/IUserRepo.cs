using ProductTaskPro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductTaskPro.IRepo
{
    public interface IUserRepo
    {
        Task<int> InsertUser(User user);
        Task<User> UserByEmailAndPassword(string Email, string Password);
        Task<List<User>> AllUsers();

    }
}

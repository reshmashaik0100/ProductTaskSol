using Microsoft.EntityFrameworkCore;
using ProductTaskPro.Context;
using ProductTaskPro.IRepo;
using ProductTaskPro.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTaskPro.Repo
{
    public class UserRepo : IUserRepo
    {
        public ProductTaskDBContext IUserObj;
        public UserRepo(ProductTaskDBContext _IUserObj)
        {
            IUserObj = _IUserObj;
        }

        public async Task<List<User>> AllUsers()
        {
            return await IUserObj.Users.ToListAsync();
        }

        public async Task<int> InsertUser(User user)
        {
            await IUserObj.Users.AddAsync(user);
            return await IUserObj.SaveChangesAsync();
        }

        public async Task<User> UserByEmailAndPassword(string Email, string Password)
        {
            return await IUserObj.Users.Where(x => x.Email == Email && x.Password == Password).SingleOrDefaultAsync();


        }
    }
}

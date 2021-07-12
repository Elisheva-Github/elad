using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BL
{
    public interface IUserBL
    {
        Task<User> GetUser(string email, string password);
        Task<User> PostUser(User u);
        Task<User> PutUser(int email, User u);
       
    }
}
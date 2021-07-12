using Entities;
using System.Threading.Tasks;


namespace DL
{
    public interface IUserDL
    {
        Task<User> getUser(string id, string password);
        Task<User> PostUser(User user);
        Task<User> putUser(int email, User userToUpdate);
    }
}
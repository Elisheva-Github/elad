using DL; 
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL _userDl;

        public UserBL(IUserDL userDL)
        {
            _userDl = userDL;
        }


        public async Task<User>  GetUser(string email, string password)
        {
        
            return await _userDl.getUser(email, password);
        }


        public async Task<User> PutUser(int email, User u)
        {
           // UserDL userDL = new UserDL();
           return await _userDl.putUser(email, u);
        }


        public async Task<User> PostUser(User u)
        {
            //UserDL userDL = new UserDL();
            return await _userDl.PostUser(u);
        }
        
    }


}

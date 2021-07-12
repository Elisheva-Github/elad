//using System;
//using System.Collections.Generic;
//using System.Text;




using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{

    public class UserDL : IUserDL
    {
        string filepath = "../ss.txt";
        My_StoreContext _My_StoreContext;

        public UserDL(My_StoreContext My_StoreContext)
        {
            _My_StoreContext = My_StoreContext;
        }



        //  שליפה מהקובץ לפי שם משתמש וסיסמא: 

        public async Task<User> getUser(string id, string password)
        {
            return await _My_StoreContext.User.Where(user => (user.Email == id) && (user.Password == password)).FirstOrDefaultAsync();
            //using (StreamReader reader = System.IO.File.OpenText(filepath))
            //{
            //    string currentUser;
            //    while ((currentUser = await reader.ReadLineAsync()) != null)
            //    {

            //        User user = JsonConvert.DeserializeObject<User>(currentUser);
            //        if (user.Email == login && user.Password == password)
            //            return user;
            //    }
            //}
            //return null;
        }



        public async Task<User> putUser(int id, User userToUpdate)
        {
            var ToUpdate = await _My_StoreContext.User.FindAsync(id);
            if (ToUpdate == null)
            {
                return null;
            }
            _My_StoreContext.Entry(ToUpdate).CurrentValues.SetValues(userToUpdate);
            await _My_StoreContext.SaveChangesAsync();
            return userToUpdate;
            //string textToReplace = "";
            //using (StreamReader reader = System.IO.File.OpenText(filepath))
            //{
            //    string currentUser;
            //    while ((currentUser =await reader.ReadLineAsync()) != null)
            //    {

            //        User user = JsonConvert.DeserializeObject<User>(currentUser);
            //        if (user.Email == email)
            //            textToReplace = currentUser;
            //    }
            //}

            //if (textToReplace != string.Empty)
            //{
            //    string text = System.IO.File.ReadAllText(filepath);
            //    text = text.Replace(textToReplace, JsonConvert.SerializeObject(userToUpdate));
            //    System.IO.File.WriteAllText(filepath, text);
            //}
        }


        public async Task<User> PostUser(User user)
        {
            _My_StoreContext.Add(user);
            await _My_StoreContext.User.AddAsync(user);
            await _My_StoreContext.SaveChangesAsync();
            return user;


        }

    }
}
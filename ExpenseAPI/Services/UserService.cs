using ExpenseAPI.DatabaseConnections;
using ExpenseAPI.DTOModels;
using ExpenseAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ExpenseAPI.Services
{

    public class UserService(DataContext context) : IUserService
    {
        private string previousmail; 
        public string CreateUser(UserDTO userdto)
        {
            var user = new User();

            user.Email = userdto.Email;
            user.Password = userdto.Password;

            if (user != null)
            {
                context.User.Add(user);
                context.SaveChanges();
                return "User Was successfully added";
            }
            
            return "User was not added";
        }

        public string deleteUser(int Id)
        {
            var userData = context.User.Find(Id);
            if (userData != null)
            {
                context.User.Remove(userData);
                context.SaveChanges();
                return "User was successfully deleted";
            }

            return "User was not found";
        }

        public List<UserDTO> GetAllUsers()
        {
        

            var userDTO = context.User.Select(u => new UserDTO
            {
                Email = u.Email,
                Password = u.Password, 
                LastUpdatedAt = u.LastUpdatedAt
            }).ToList();

            return userDTO;

        }

        public UserDTO GetUser(int id)
        {
            var user = context.User.Find(id);
            UserDTO userDTO = new UserDTO{
                Email = user.Email,
                Password = user.Password,
                LastUpdatedAt = user.LastUpdatedAt
            };




            return userDTO;
        }

        public string UpdateUser(int id, UserDTO userDTO)
        {
            if (userDTO != null)
            {
                var Userdata = context.User.Find(id);
                previousmail = Userdata.Email;
                Userdata.Email = userDTO.Email;
                Userdata.Password = userDTO.Password;
                Userdata.LastUpdatedAt = userDTO.LastUpdatedAt;
                context.User.Update(Userdata);
                context.SaveChanges();

                return "User mail updated from " + previousmail + " To " + Userdata.Email;
            }

            return "user details were not updated";
        }

    }
}

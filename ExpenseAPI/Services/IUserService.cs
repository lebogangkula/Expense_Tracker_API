using ExpenseAPI.DTOModels;


namespace ExpenseAPI.Services
{
    public interface IUserService
    {
        public string CreateUser(UserDTO userdto);

        public string UpdateUser(int id, UserDTO userDTO);

        public string deleteUser(int id);

        public List<UserDTO> GetAllUsers();

        public UserDTO GetUser(int id);

        
    }
}

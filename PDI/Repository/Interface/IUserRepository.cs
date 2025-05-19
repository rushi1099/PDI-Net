using PDI.DTO;
using System.Collections;

namespace PDI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> RegisterUser (userSignup signup);
        Task<User> LoginUser(userSignIn signin);
        Task<IEnumerable<User>> GetAllUsers();
        
    }
}

using Microsoft.EntityFrameworkCore;
using PDI.Data;
using PDI.DTO;
using PDI.Repository.Interface;

namespace PDI.Repository.Implentation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> RegisterUser(userSignup signup)
        {

            try
            {

                var exist=await _context.Users.FirstOrDefaultAsync(x=>x.Email == signup.userName);
                if (exist != null)
                {
                    throw new Exception("User already exists");
                }

                //used hashcode to encrpty the password\
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(signup.Password);

                var user = new User
                {
                    userName = signup.userName,
                    Password = hashedPassword,
                    Email = signup.Email
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }

        public async Task<User> LoginUser(userSignIn signin)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.userName == signin.userName);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                //  Verify if the provided password matches the hashed password stored in the database
                bool isValid = BCrypt.Net.BCrypt.Verify(signin.Password, user.Password);
                if (!isValid)
                {
                    throw new Exception("Invalid password");
                }
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in the user.", ex);
            }

        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all users.", ex);
            }
        }

    }
   
}

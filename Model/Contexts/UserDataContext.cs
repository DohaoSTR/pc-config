using Microsoft.EntityFrameworkCore;
using PCConfig.Model.Access;
using PCConfig.Model.Converters;
using PCConfig.Model.UsersData;

namespace PCConfig.Model.Contexts
{
    public class UserDataContext : ApplicationContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<RoleAccessRight> RoleAccessRights { get; set; } = null!;
        public DbSet<UserAccessRight> UserAccessRights { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            InitConnectionSettings("UserDataConnectionSettings");

            optionsBuilder.UseMySql($"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};" +
                $"Database={ConnectionSettings.DatabaseName};Username={ConnectionSettings.Username};" +
                $"Password={ConnectionSettings.Password}",
                new MySqlServerVersion(new Version(8, 0, 34)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder
            .Entity<User>()
            .Property(e => e.Type)
            .HasConversion(new UserTypeDatabaseConverter());
        }

        public bool Authorize(string email, string password)
        {
            try
            {
                foreach (User user in Users)
                {
                    if (PasswordHasher.VerifyPassword(password, user.Password) == true && user.Email == email)
                    {
                        return true;
                    }
                }

                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public bool IsEmailExist(string email)
        {
            try
            {
                User user = Users.Where(u => u.Email == email).First();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public UserType? GetUserType(string email)
        {
            try
            {
                User user = Users.Where(u => u.Email == email).First();
                return user.Type;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public UserType? GetUserType(int id)
        {
            try
            {
                User user = Users.Where(u => u.Id == id).First();
                return user.Type;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public string? GetEmail(int id)
        {
            try
            {
                User user = Users.Where(u => u.Id == id).First();
                return user.Email;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public bool Registration(string email, string password)
        {
            if (IsEmailExist(email) == true)
            {
                return false;
            }
            else
            {
                string hashedPassword = PasswordHasher.HashPassword(password);

                User addUser = new()
                {
                    Email = email,
                    Password = hashedPassword,
                    RoleId = 1,
                    Type = UserType.Standard
                };
                Users.Add(addUser);
                SaveChanges();
                return true;
            }
        }

        public bool AuthorizeGoogleAccount(string email)
        {
            bool isEmailExist = IsEmailExist(email);
            UserType? type = GetUserType(email);

            if (isEmailExist == true && type == UserType.Google)
            {
                return true;
            }
            else if (isEmailExist == false && type == null)
            {
                RegistrationGoogleAccount(email);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegistrationGoogleAccount(string email)
        {
            User addUser = new()
            {
                Email = email,
                RoleId = 1,
                Type = UserType.Google
            };
            Users.Add(addUser);
            SaveChanges();
        }

        public int? GetUserId(string email, string password)
        {
            try
            {
                foreach (User user in Users)
                {
                    if (PasswordHasher.VerifyPassword(password, user.Password) == true)
                    {
                        return user.Id;
                    }
                }

                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public int? GetUserId(string email)
        {
            try
            {
                User user = Users.Where(u => u.Email == email).First();
                return user.Id;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public bool ChangePassword(string email, string password)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);

            try
            {
                User user = Users.Where(u => u.Email == email).First();
                user.Password = hashedPassword;

                SaveChanges();

                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public User GetUserData(int userId)
        {
            return Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public Role GetUserRole(int userId)
        {
            User user = Users.Where(u => u.Id == userId).FirstOrDefault();
            Role role = Roles.Where(r => r.Id == user.RoleId).FirstOrDefault();

            return role;
        }

        public List<Log> GetUserLogs(int userId)
        {
            List<Log> logs = Logs.Where(l => l.UserId == userId).ToList();

            return logs;
        }

        public List<UserAccessRight> GetUserRights(int userId)
        {
            User user = Users.Where(u => u.Id == userId).FirstOrDefault();
            List<UserAccessRight> rights = UserAccessRights.Where(l => l.UserId == userId).ToList();

            return rights;
        }

        public List<RoleAccessRight> GetUserRoleRights(int userId)
        {
            User user = Users.Where(u => u.Id == userId).FirstOrDefault();
            Role role = Roles.Where(r => r.Id == user.RoleId).FirstOrDefault();

            List<RoleAccessRight> rights = RoleAccessRights.Where(l => l.RoleId == role.Id).ToList();

            return rights;
        }

        public Log GetLog(int userId, string name)
        {
            IpInfo ipInfo = IpDataManager.GetAllUserData();

            return new Log()
            {
                DateTime = DateTime.Now,
                Name = name,
                UserId = userId,
                IpAddress = ipInfo.ip,
                City = ipInfo.city,
                CountryCode = ipInfo.country,
                TimeZone = ipInfo.timezone
            };
        }

        public bool AddLog(string email, string name)
        {
            int? id = GetUserId(email);

            if (id != null)
            {
                Log log = GetLog((int)id, name);
                Logs.Add(log);
                SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

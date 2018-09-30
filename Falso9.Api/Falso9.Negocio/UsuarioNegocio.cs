using Falso9.Datos.Interface;
using Falso9.Entidades.DB;
using Falso9.Negocio.Helpers;
using Falso9.Negocio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falso9.Negocio
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private IUsuarioRepository _context;

        public UsuarioNegocio(IUsuarioRepository usuarioRepository)
        {
            _context = usuarioRepository;
        }

        public async Task<Usuario> Autenticar(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            List<Usuario> usuarios = await _context.GetAllAsync();
            Usuario user = usuarios.Find(u => u.Login == username);
            
            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        
        public async Task<Usuario> Create(Usuario user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            List<Usuario> users = await _context.GetAllAsync();

            if (users.Any(x => x.Login == user.Login))
                throw new AppException("Username \"" + user.Login + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Create(user);
         

            return user;
        }

        public async void Delete(int id)
        {
            Usuario user = await _context.GetById(id);
            if(user != null)
            {
                await _context.Delete(user);
            }
            
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _context.GetById(id);
        }

        public async void Update(Usuario userParam, string password = null)
        {
            Usuario user = await _context.GetById(userParam.UsuarioId);

            if (user == null)
                throw new AppException("User not found");

            List<Usuario> Users = await _context.GetAllAsync();

            if (userParam.Login != user.Login)
            {
                // username has changed so check if the new username is already taken
                if (Users.Any(x => x.Login == userParam.Login))
                    throw new AppException("Username " + userParam.Login + " is already taken");
            }

            // update user properties
            user.Nombre = userParam.Nombre;
            user.Apellido = userParam.Apellido;
            user.Login = userParam.Login;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            await _context.Update(user);
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}

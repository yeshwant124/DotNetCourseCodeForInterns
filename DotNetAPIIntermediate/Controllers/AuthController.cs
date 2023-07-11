using DotNetAPIIntermediate.Data;
using DotNetAPIIntermediate.DTO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace DotNetAPIIntermediate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContextDapper   _dapper;

        private readonly IConfiguration _config;

        public AuthController(IConfiguration config) 
        { 
            _dapper = new DataContextDapper(config);
            _config = config;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForRegistrationDTO userForRegistration)
        {
            if (userForRegistration.Password.Equals(userForRegistration.PasswordConfirm){
                string sqlCheckIfUserExists = "Select Email From [TutorialAppSchema].[Auth] Where Email='" + userForRegistration.Email + "'";
                IEnumerable<string> existingUsers = _dapper.LoadData<string>(sqlCheckIfUserExists);
                if (existingUsers.Count() == 0)
                {
                    byte[] passwordSalt = new byte[128 / 8];
                    
                    byte[] passwordHash = GetPasswordHash(userForRegistration.Password, passwordSalt);

                    string sqlAddAuth = @"Insert Into [TutorialAppSchema].[Auth]([Email],[PasswordHash],[PasswordSalt]  " +
                        "Values('" + userForRegistration.Email + "',@PasswordHash,@PasswordSalt);";

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();

                    SqlParameter passwordSaltParameter = new SqlParameter("@PasswordSalt", SqlDbType.VarBinary);
                    passwordSaltParameter.Value = passwordSalt;
                    sqlParameters.Add(passwordSaltParameter);

                    SqlParameter passwordHashParameter = new SqlParameter("@PasswordHash", SqlDbType.VarBinary);
                    passwordHashParameter.Value = passwordHash;
                    sqlParameters.Add(passwordHashParameter);

                    if(_dapper.ExecuteSqlWithParameters(sqlAddAuth, sqlParameters))
                    {
                        return Ok();
                    }
                    throw new Exception("Failed to register user.");
                }
                throw new Exception("User with this email already exists!!!");
            }                
            throw new Exception("Passwords do not match!!!");
        }


        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDTO userForLogin)
        {
            string sqlForHashAndSalt = @"SELECT [PasswordHash],[PasswordSalt] FROM[TutorialAppSchema].[Auth] WHERE Email='" + userForLogin.Email + "'";
            UserForLoginConfirmationDTO userForLoginConfirmation = _dapper.LoadDataSingle<UserForLoginConfirmationDTO>(sqlForHashAndSalt);

            
            byte[] passwordSalt = new byte[128 / 8];
            byte[] passwordHash = GetPasswordHash(userForLogin.Password, userForLoginConfirmation.PasswordSalt);

            string sqlCheckIfUserexists = @"SELECT [PasswordHash],[PasswordSalt] FROM[TutorialAppSchema].[Auth] WHERE Email='" + userForLogin.Email + "'" +
                " AND [PasswordHash]='" + passwordHash + "' AND [PasswordSalt]='" + passwordSalt + "';";
            _dapper.LoadDataSingle<>

            return Ok();
        }

        private byte[] GetPasswordHash(string password, byte[] passwordSalt) 
        {            
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(passwordSalt);
            }
            string passwordSaltPlusString = _config.GetSection("AppSettings:PasswordKey").Value + Convert.ToBase64String(passwordSalt);

            byte[] passwordHash = KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(passwordSaltPlusString),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            );

            return passwordHash;
        }
    }
}

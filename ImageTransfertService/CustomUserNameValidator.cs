using System;
using System.IdentityModel.Selectors;
using DataLib;

namespace ImageTransfertService
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(String userName, String password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                Connexion connex = new Connexion();
                User user = connex.getUser(userName);
                bool success = user.auth(password);
                if (!success)
                {
                    throw new Exception("unknown user");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

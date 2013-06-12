using System;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;

namespace WCFSecurite
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ISecur
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        public String getInfoPublique()
        {
            return "Info publique";
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "VIP")]
        public String getInfoLouche()
        {
            return "Info louche";
        } 
    }


}

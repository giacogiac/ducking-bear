using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace ApplicationImageService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ITransfertImage
    {
        [OperationContract]
        String UploadImage(Stream image, String album, String user);

        [OperationContract]
        Stream DownloadImage(String name, String album, String user);
    }
}

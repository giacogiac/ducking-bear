using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using DataLib;
using System;
using System.Security.Principal;
using System.Security.Permissions;

namespace ImageTransfertService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IImageTransfert
    {

        [OperationContract]
        void authentify(UserInfo info);

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ErrorMessage UploadImage(ImageUploadRequest data);

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ImageDownloadResponse Download(ImageDownloadRequest data);

        [PrincipalPermission(SecurityAction.Demand, Role = "admin")]
        [OperationContract]
        ErrorMessage addUser(UserInfo info);

        [PrincipalPermission(SecurityAction.Demand, Role = "admin")]
        [OperationContract]
        ErrorMessage deleteUser(UserInfo info);

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ErrorMessage createAlbum(ImageParam param);

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ErrorMessage deleteAlbum(ImageParam param);

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ErrorMessage deleteImage(ImageParam param);

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ListResult getAllUserNames();

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ListResult getAllAlbumNames(ImageParam param);

        [PrincipalPermission(SecurityAction.Demand, Role = "user")]
        [OperationContract]
        ListResult getAllImageName(ImageParam param);
    }

    [MessageContract]
    public class UserInfo
    {
        [MessageBodyMember(Order = 1)]
        public UserData data;
    }

    [DataContract]
    public class UserData
    {

        [DataMember(Order = 1, IsRequired = true)]
        public String name { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public String pass { get; set; }

        [DataMember(Order = 3)]
        public String role { get; set; }

    }


    [MessageContract]
    public class ImageParam
    {
        [MessageBodyMember(Order = 1)]
        public ImageInfo info;
    }

    [MessageContract]
    public class ListResult
    {

        [MessageBodyMember(Order = 1)]
        public List<String> names;

    }

    [MessageContract]
    public class ErrorMessage
    {

        [MessageBodyMember(Order = 1)]
        public String message;

    }

    [MessageContract]
    public class ImageUploadRequest
    {
        [MessageHeader(MustUnderstand = true)]
        public ImageInfo ImageInfo;

        [MessageBodyMember(Order = 1)]
        public Stream ImageData;

    }

    [MessageContract]
    public class ImageDownloadResponse
    {

        [MessageBodyMember(Order = 1)]
        public Stream ImageData;
    }

    [MessageContract]
    public class ImageDownloadRequest
    {

        [MessageBodyMember(Order = 1)]
        public ImageInfo ImageInfo;
    }

    [DataContract]
    public class ImageInfo
    {
        [DataMember(Order = 1, IsRequired = true)]
        public String imageid { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public String albumid { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public String userid { get; set; }
    } 

}

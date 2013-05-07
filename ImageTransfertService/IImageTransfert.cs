﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace ImageTransfertService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IImageTransfert
    {


        [OperationContract]
        void  UploadImage(ImageUploadRequest data);

        [OperationContract]
        ImageDownloadResponse Download(ImageDownloadRequest data); 

        // TODO: ajoutez vos opérations de service ici
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

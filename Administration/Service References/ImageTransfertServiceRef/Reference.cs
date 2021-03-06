﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.269
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Administration.ImageTransfertServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageInfo", Namespace="http://schemas.datacontract.org/2004/07/ImageTransfertService")]
    [System.SerializableAttribute()]
    public partial class ImageInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string imageidField;
        
        private string albumidField;
        
        private string useridField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string imageid {
            get {
                return this.imageidField;
            }
            set {
                if ((object.ReferenceEquals(this.imageidField, value) != true)) {
                    this.imageidField = value;
                    this.RaisePropertyChanged("imageid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string albumid {
            get {
                return this.albumidField;
            }
            set {
                if ((object.ReferenceEquals(this.albumidField, value) != true)) {
                    this.albumidField = value;
                    this.RaisePropertyChanged("albumid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string userid {
            get {
                return this.useridField;
            }
            set {
                if ((object.ReferenceEquals(this.useridField, value) != true)) {
                    this.useridField = value;
                    this.RaisePropertyChanged("userid");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserData", Namespace="http://schemas.datacontract.org/2004/07/ImageTransfertService")]
    [System.SerializableAttribute()]
    public partial class UserData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string nameField;
        
        private string passField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string roleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string pass {
            get {
                return this.passField;
            }
            set {
                if ((object.ReferenceEquals(this.passField, value) != true)) {
                    this.passField = value;
                    this.RaisePropertyChanged("pass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string role {
            get {
                return this.roleField;
            }
            set {
                if ((object.ReferenceEquals(this.roleField, value) != true)) {
                    this.roleField = value;
                    this.RaisePropertyChanged("role");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ImageTransfertServiceRef.IImageTransfert")]
    public interface IImageTransfert {
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageUploadRequest) du message ImageUploadRequest ne correspond pas à la valeur par défaut (UploadImage)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/UploadImage", ReplyAction="http://tempuri.org/IImageTransfert/UploadImageResponse")]
        Administration.ImageTransfertServiceRef.ErrorMessage UploadImage(Administration.ImageTransfertServiceRef.ImageUploadRequest request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageDownloadRequest) du message ImageDownloadRequest ne correspond pas à la valeur par défaut (Download)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/Download", ReplyAction="http://tempuri.org/IImageTransfert/DownloadResponse")]
        Administration.ImageTransfertServiceRef.ImageDownloadResponse Download(Administration.ImageTransfertServiceRef.ImageDownloadRequest request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (UserInfo) du message UserInfo ne correspond pas à la valeur par défaut (addUser)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/addUser", ReplyAction="http://tempuri.org/IImageTransfert/addUserResponse")]
        Administration.ImageTransfertServiceRef.ErrorMessage addUser(Administration.ImageTransfertServiceRef.UserInfo request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (UserInfo) du message UserInfo ne correspond pas à la valeur par défaut (deleteUser)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deleteUser", ReplyAction="http://tempuri.org/IImageTransfert/deleteUserResponse")]
        Administration.ImageTransfertServiceRef.ErrorMessage deleteUser(Administration.ImageTransfertServiceRef.UserInfo request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageParam) du message ImageParam ne correspond pas à la valeur par défaut (createAlbum)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/createAlbum", ReplyAction="http://tempuri.org/IImageTransfert/createAlbumResponse")]
        Administration.ImageTransfertServiceRef.ErrorMessage createAlbum(Administration.ImageTransfertServiceRef.ImageParam request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageParam) du message ImageParam ne correspond pas à la valeur par défaut (deleteAlbum)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deleteAlbum", ReplyAction="http://tempuri.org/IImageTransfert/deleteAlbumResponse")]
        Administration.ImageTransfertServiceRef.ErrorMessage deleteAlbum(Administration.ImageTransfertServiceRef.ImageParam request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageParam) du message ImageParam ne correspond pas à la valeur par défaut (deleteImage)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deleteImage", ReplyAction="http://tempuri.org/IImageTransfert/deleteImageResponse")]
        Administration.ImageTransfertServiceRef.ErrorMessage deleteImage(Administration.ImageTransfertServiceRef.ImageParam request);
        
        // CODEGEN : La génération du contrat de message depuis l'opération getAllUserNames n'est ni RPC, ni encapsulée dans un document.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/getAllUserNames", ReplyAction="http://tempuri.org/IImageTransfert/getAllUserNamesResponse")]
        Administration.ImageTransfertServiceRef.ListResult getAllUserNames(Administration.ImageTransfertServiceRef.getAllUserNamesRequest request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageParam) du message ImageParam ne correspond pas à la valeur par défaut (getAllAlbumNames)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/getAllAlbumNames", ReplyAction="http://tempuri.org/IImageTransfert/getAllAlbumNamesResponse")]
        Administration.ImageTransfertServiceRef.ListResult getAllAlbumNames(Administration.ImageTransfertServiceRef.ImageParam request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageParam) du message ImageParam ne correspond pas à la valeur par défaut (getAllImageName)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/getAllImageName", ReplyAction="http://tempuri.org/IImageTransfert/getAllImageNameResponse")]
        Administration.ImageTransfertServiceRef.ListResult getAllImageName(Administration.ImageTransfertServiceRef.ImageParam request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageUploadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageUploadRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public Administration.ImageTransfertServiceRef.ImageInfo ImageInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageData;
        
        public ImageUploadRequest() {
        }
        
        public ImageUploadRequest(Administration.ImageTransfertServiceRef.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            this.ImageInfo = ImageInfo;
            this.ImageData = ImageData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ErrorMessage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ErrorMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string message;
        
        public ErrorMessage() {
        }
        
        public ErrorMessage(string message) {
            this.message = message;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Administration.ImageTransfertServiceRef.ImageInfo ImageInfo;
        
        public ImageDownloadRequest() {
        }
        
        public ImageDownloadRequest(Administration.ImageTransfertServiceRef.ImageInfo ImageInfo) {
            this.ImageInfo = ImageInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageData;
        
        public ImageDownloadResponse() {
        }
        
        public ImageDownloadResponse(System.IO.Stream ImageData) {
            this.ImageData = ImageData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UserInfo", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UserInfo {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Administration.ImageTransfertServiceRef.UserData data;
        
        public UserInfo() {
        }
        
        public UserInfo(Administration.ImageTransfertServiceRef.UserData data) {
            this.data = data;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageParam", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageParam {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Administration.ImageTransfertServiceRef.ImageInfo info;
        
        public ImageParam() {
        }
        
        public ImageParam(Administration.ImageTransfertServiceRef.ImageInfo info) {
            this.info = info;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getAllUserNamesRequest {
        
        public getAllUserNamesRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ListResult", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ListResult {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] names;
        
        public ListResult() {
        }
        
        public ListResult(string[] names) {
            this.names = names;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IImageTransfertChannel : Administration.ImageTransfertServiceRef.IImageTransfert, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImageTransfertClient : System.ServiceModel.ClientBase<Administration.ImageTransfertServiceRef.IImageTransfert>, Administration.ImageTransfertServiceRef.IImageTransfert {
        
        public ImageTransfertClient() {
        }
        
        public ImageTransfertClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ImageTransfertClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageTransfertClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageTransfertClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ErrorMessage Administration.ImageTransfertServiceRef.IImageTransfert.UploadImage(Administration.ImageTransfertServiceRef.ImageUploadRequest request) {
            return base.Channel.UploadImage(request);
        }
        
        public string UploadImage(Administration.ImageTransfertServiceRef.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            Administration.ImageTransfertServiceRef.ImageUploadRequest inValue = new Administration.ImageTransfertServiceRef.ImageUploadRequest();
            inValue.ImageInfo = ImageInfo;
            inValue.ImageData = ImageData;
            Administration.ImageTransfertServiceRef.ErrorMessage retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).UploadImage(inValue);
            return retVal.message;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ImageDownloadResponse Administration.ImageTransfertServiceRef.IImageTransfert.Download(Administration.ImageTransfertServiceRef.ImageDownloadRequest request) {
            return base.Channel.Download(request);
        }
        
        public System.IO.Stream Download(Administration.ImageTransfertServiceRef.ImageInfo ImageInfo) {
            Administration.ImageTransfertServiceRef.ImageDownloadRequest inValue = new Administration.ImageTransfertServiceRef.ImageDownloadRequest();
            inValue.ImageInfo = ImageInfo;
            Administration.ImageTransfertServiceRef.ImageDownloadResponse retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).Download(inValue);
            return retVal.ImageData;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ErrorMessage Administration.ImageTransfertServiceRef.IImageTransfert.addUser(Administration.ImageTransfertServiceRef.UserInfo request) {
            return base.Channel.addUser(request);
        }
        
        public string addUser(Administration.ImageTransfertServiceRef.UserData data) {
            Administration.ImageTransfertServiceRef.UserInfo inValue = new Administration.ImageTransfertServiceRef.UserInfo();
            inValue.data = data;
            Administration.ImageTransfertServiceRef.ErrorMessage retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).addUser(inValue);
            return retVal.message;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ErrorMessage Administration.ImageTransfertServiceRef.IImageTransfert.deleteUser(Administration.ImageTransfertServiceRef.UserInfo request) {
            return base.Channel.deleteUser(request);
        }
        
        public string deleteUser(Administration.ImageTransfertServiceRef.UserData data) {
            Administration.ImageTransfertServiceRef.UserInfo inValue = new Administration.ImageTransfertServiceRef.UserInfo();
            inValue.data = data;
            Administration.ImageTransfertServiceRef.ErrorMessage retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).deleteUser(inValue);
            return retVal.message;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ErrorMessage Administration.ImageTransfertServiceRef.IImageTransfert.createAlbum(Administration.ImageTransfertServiceRef.ImageParam request) {
            return base.Channel.createAlbum(request);
        }
        
        public string createAlbum(Administration.ImageTransfertServiceRef.ImageInfo info) {
            Administration.ImageTransfertServiceRef.ImageParam inValue = new Administration.ImageTransfertServiceRef.ImageParam();
            inValue.info = info;
            Administration.ImageTransfertServiceRef.ErrorMessage retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).createAlbum(inValue);
            return retVal.message;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ErrorMessage Administration.ImageTransfertServiceRef.IImageTransfert.deleteAlbum(Administration.ImageTransfertServiceRef.ImageParam request) {
            return base.Channel.deleteAlbum(request);
        }
        
        public string deleteAlbum(Administration.ImageTransfertServiceRef.ImageInfo info) {
            Administration.ImageTransfertServiceRef.ImageParam inValue = new Administration.ImageTransfertServiceRef.ImageParam();
            inValue.info = info;
            Administration.ImageTransfertServiceRef.ErrorMessage retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).deleteAlbum(inValue);
            return retVal.message;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ErrorMessage Administration.ImageTransfertServiceRef.IImageTransfert.deleteImage(Administration.ImageTransfertServiceRef.ImageParam request) {
            return base.Channel.deleteImage(request);
        }
        
        public string deleteImage(Administration.ImageTransfertServiceRef.ImageInfo info) {
            Administration.ImageTransfertServiceRef.ImageParam inValue = new Administration.ImageTransfertServiceRef.ImageParam();
            inValue.info = info;
            Administration.ImageTransfertServiceRef.ErrorMessage retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).deleteImage(inValue);
            return retVal.message;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ListResult Administration.ImageTransfertServiceRef.IImageTransfert.getAllUserNames(Administration.ImageTransfertServiceRef.getAllUserNamesRequest request) {
            return base.Channel.getAllUserNames(request);
        }
        
        public string[] getAllUserNames() {
            Administration.ImageTransfertServiceRef.getAllUserNamesRequest inValue = new Administration.ImageTransfertServiceRef.getAllUserNamesRequest();
            Administration.ImageTransfertServiceRef.ListResult retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).getAllUserNames(inValue);
            return retVal.names;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ListResult Administration.ImageTransfertServiceRef.IImageTransfert.getAllAlbumNames(Administration.ImageTransfertServiceRef.ImageParam request) {
            return base.Channel.getAllAlbumNames(request);
        }
        
        public string[] getAllAlbumNames(Administration.ImageTransfertServiceRef.ImageInfo info) {
            Administration.ImageTransfertServiceRef.ImageParam inValue = new Administration.ImageTransfertServiceRef.ImageParam();
            inValue.info = info;
            Administration.ImageTransfertServiceRef.ListResult retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).getAllAlbumNames(inValue);
            return retVal.names;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Administration.ImageTransfertServiceRef.ListResult Administration.ImageTransfertServiceRef.IImageTransfert.getAllImageName(Administration.ImageTransfertServiceRef.ImageParam request) {
            return base.Channel.getAllImageName(request);
        }
        
        public string[] getAllImageName(Administration.ImageTransfertServiceRef.ImageInfo info) {
            Administration.ImageTransfertServiceRef.ImageParam inValue = new Administration.ImageTransfertServiceRef.ImageParam();
            inValue.info = info;
            Administration.ImageTransfertServiceRef.ListResult retVal = ((Administration.ImageTransfertServiceRef.IImageTransfert)(this)).getAllImageName(inValue);
            return retVal.names;
        }
    }
}

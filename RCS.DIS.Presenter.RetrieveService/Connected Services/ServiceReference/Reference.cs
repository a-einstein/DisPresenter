﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCS.DIS.Presenter.RetrieveService.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Diagnose", Namespace="http://schemas.datacontract.org/2004/07/RCS.DIS.Services.DTOs")]
    [System.SerializableAttribute()]
    public partial class Diagnose : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BestandsdatumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiagnoseCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OmschrijvingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PeildatumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SpecialismeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersieField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Bestandsdatum {
            get {
                return this.BestandsdatumField;
            }
            set {
                if ((this.BestandsdatumField.Equals(value) != true)) {
                    this.BestandsdatumField = value;
                    this.RaisePropertyChanged("Bestandsdatum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DiagnoseCode {
            get {
                return this.DiagnoseCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.DiagnoseCodeField, value) != true)) {
                    this.DiagnoseCodeField = value;
                    this.RaisePropertyChanged("DiagnoseCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Omschrijving {
            get {
                return this.OmschrijvingField;
            }
            set {
                if ((object.ReferenceEquals(this.OmschrijvingField, value) != true)) {
                    this.OmschrijvingField = value;
                    this.RaisePropertyChanged("Omschrijving");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Peildatum {
            get {
                return this.PeildatumField;
            }
            set {
                if ((this.PeildatumField.Equals(value) != true)) {
                    this.PeildatumField = value;
                    this.RaisePropertyChanged("Peildatum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SpecialismeCode {
            get {
                return this.SpecialismeCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.SpecialismeCodeField, value) != true)) {
                    this.SpecialismeCodeField = value;
                    this.RaisePropertyChanged("SpecialismeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Versie {
            get {
                return this.VersieField;
            }
            set {
                if ((object.ReferenceEquals(this.VersieField, value) != true)) {
                    this.VersieField = value;
                    this.RaisePropertyChanged("Versie");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Specialisme", Namespace="http://schemas.datacontract.org/2004/07/RCS.DIS.Services.DTOs")]
    [System.SerializableAttribute()]
    public partial class Specialisme : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BestandsdatumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OmschrijvingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PeildatumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SpecialismeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersieField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Bestandsdatum {
            get {
                return this.BestandsdatumField;
            }
            set {
                if ((this.BestandsdatumField.Equals(value) != true)) {
                    this.BestandsdatumField = value;
                    this.RaisePropertyChanged("Bestandsdatum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Omschrijving {
            get {
                return this.OmschrijvingField;
            }
            set {
                if ((object.ReferenceEquals(this.OmschrijvingField, value) != true)) {
                    this.OmschrijvingField = value;
                    this.RaisePropertyChanged("Omschrijving");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Peildatum {
            get {
                return this.PeildatumField;
            }
            set {
                if ((this.PeildatumField.Equals(value) != true)) {
                    this.PeildatumField = value;
                    this.RaisePropertyChanged("Peildatum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SpecialismeCode {
            get {
                return this.SpecialismeCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.SpecialismeCodeField, value) != true)) {
                    this.SpecialismeCodeField = value;
                    this.RaisePropertyChanged("SpecialismeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Versie {
            get {
                return this.VersieField;
            }
            set {
                if ((object.ReferenceEquals(this.VersieField, value) != true)) {
                    this.VersieField = value;
                    this.RaisePropertyChanged("Versie");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IRetrieveService")]
    public interface IRetrieveService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/Versies", ReplyAction="http://tempuri.org/IRetrieveService/VersiesResponse")]
        string[] Versies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/Versies", ReplyAction="http://tempuri.org/IRetrieveService/VersiesResponse")]
        System.Threading.Tasks.Task<string[]> VersiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsNumber", ReplyAction="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsNumberResponse")]
        int DiagnoseOmschrijvingContainsNumber(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsNumber", ReplyAction="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsNumberResponse")]
        System.Threading.Tasks.Task<int> DiagnoseOmschrijvingContainsNumberAsync(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsEntities", ReplyAction="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsEntitiesResponse")]
        RCS.DIS.Presenter.RetrieveService.ServiceReference.Diagnose[] DiagnoseOmschrijvingContainsEntities(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsEntities", ReplyAction="http://tempuri.org/IRetrieveService/DiagnoseOmschrijvingContainsEntitiesResponse")]
        System.Threading.Tasks.Task<RCS.DIS.Presenter.RetrieveService.ServiceReference.Diagnose[]> DiagnoseOmschrijvingContainsEntitiesAsync(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsNumber", ReplyAction="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsNumberResponse" +
            "")]
        int SpecialismeOmschrijvingContainsNumber(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsNumber", ReplyAction="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsNumberResponse" +
            "")]
        System.Threading.Tasks.Task<int> SpecialismeOmschrijvingContainsNumberAsync(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsEntities", ReplyAction="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsEntitiesRespon" +
            "se")]
        RCS.DIS.Presenter.RetrieveService.ServiceReference.Specialisme[] SpecialismeOmschrijvingContainsEntities(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsEntities", ReplyAction="http://tempuri.org/IRetrieveService/SpecialismeOmschrijvingContainsEntitiesRespon" +
            "se")]
        System.Threading.Tasks.Task<RCS.DIS.Presenter.RetrieveService.ServiceReference.Specialisme[]> SpecialismeOmschrijvingContainsEntitiesAsync(string searchString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRetrieveServiceChannel : RCS.DIS.Presenter.RetrieveService.ServiceReference.IRetrieveService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RetrieveServiceClient : System.ServiceModel.ClientBase<RCS.DIS.Presenter.RetrieveService.ServiceReference.IRetrieveService>, RCS.DIS.Presenter.RetrieveService.ServiceReference.IRetrieveService {
        
        public RetrieveServiceClient() {
        }
        
        public RetrieveServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RetrieveServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetrieveServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetrieveServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] Versies() {
            return base.Channel.Versies();
        }
        
        public System.Threading.Tasks.Task<string[]> VersiesAsync() {
            return base.Channel.VersiesAsync();
        }
        
        public int DiagnoseOmschrijvingContainsNumber(string searchString) {
            return base.Channel.DiagnoseOmschrijvingContainsNumber(searchString);
        }
        
        public System.Threading.Tasks.Task<int> DiagnoseOmschrijvingContainsNumberAsync(string searchString) {
            return base.Channel.DiagnoseOmschrijvingContainsNumberAsync(searchString);
        }
        
        public RCS.DIS.Presenter.RetrieveService.ServiceReference.Diagnose[] DiagnoseOmschrijvingContainsEntities(string searchString) {
            return base.Channel.DiagnoseOmschrijvingContainsEntities(searchString);
        }
        
        public System.Threading.Tasks.Task<RCS.DIS.Presenter.RetrieveService.ServiceReference.Diagnose[]> DiagnoseOmschrijvingContainsEntitiesAsync(string searchString) {
            return base.Channel.DiagnoseOmschrijvingContainsEntitiesAsync(searchString);
        }
        
        public int SpecialismeOmschrijvingContainsNumber(string searchString) {
            return base.Channel.SpecialismeOmschrijvingContainsNumber(searchString);
        }
        
        public System.Threading.Tasks.Task<int> SpecialismeOmschrijvingContainsNumberAsync(string searchString) {
            return base.Channel.SpecialismeOmschrijvingContainsNumberAsync(searchString);
        }
        
        public RCS.DIS.Presenter.RetrieveService.ServiceReference.Specialisme[] SpecialismeOmschrijvingContainsEntities(string searchString) {
            return base.Channel.SpecialismeOmschrijvingContainsEntities(searchString);
        }
        
        public System.Threading.Tasks.Task<RCS.DIS.Presenter.RetrieveService.ServiceReference.Specialisme[]> SpecialismeOmschrijvingContainsEntitiesAsync(string searchString) {
            return base.Channel.SpecialismeOmschrijvingContainsEntitiesAsync(searchString);
        }
    }
}

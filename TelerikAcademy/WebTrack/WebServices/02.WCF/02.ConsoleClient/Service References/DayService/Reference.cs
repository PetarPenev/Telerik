﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _02.ConsoleClient.DayService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DayService.IDayService")]
    public interface IDayService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayService/GetDate", ReplyAction="http://tempuri.org/IDayService/GetDateResponse")]
        string GetDate(System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayService/GetDate", ReplyAction="http://tempuri.org/IDayService/GetDateResponse")]
        System.Threading.Tasks.Task<string> GetDateAsync(System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDayServiceChannel : _02.ConsoleClient.DayService.IDayService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DayServiceClient : System.ServiceModel.ClientBase<_02.ConsoleClient.DayService.IDayService>, _02.ConsoleClient.DayService.IDayService {
        
        public DayServiceClient() {
        }
        
        public DayServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DayServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDate(System.DateTime date) {
            return base.Channel.GetDate(date);
        }
        
        public System.Threading.Tasks.Task<string> GetDateAsync(System.DateTime date) {
            return base.Channel.GetDateAsync(date);
        }
    }
}

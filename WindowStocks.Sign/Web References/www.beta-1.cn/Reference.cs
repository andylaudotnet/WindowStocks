﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3603
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.3603 版自动生成。
// 
#pragma warning disable 1591

namespace WindowStocks.Sign.www.beta_1.cn {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="windowstocks_servicesSoap", Namespace="http://www.beta-1.cn/")]
    public partial class windowstocks_services : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SignInOperationCompleted;
        
        private System.Threading.SendOrPostCallback SignOutOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public windowstocks_services() {
            this.Url = global::WindowStocks.Sign.Properties.Settings.Default.WindowStocks_Sign_www_beta_1_cn_windowstocks_services;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SignInCompletedEventHandler SignInCompleted;
        
        /// <remarks/>
        public event SignOutCompletedEventHandler SignOutCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.beta-1.cn/SignIn", RequestNamespace="http://www.beta-1.cn/", ResponseNamespace="http://www.beta-1.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SignIn(string encryptStr) {
            this.Invoke("SignIn", new object[] {
                        encryptStr});
        }
        
        /// <remarks/>
        public void SignInAsync(string encryptStr) {
            this.SignInAsync(encryptStr, null);
        }
        
        /// <remarks/>
        public void SignInAsync(string encryptStr, object userState) {
            if ((this.SignInOperationCompleted == null)) {
                this.SignInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSignInOperationCompleted);
            }
            this.InvokeAsync("SignIn", new object[] {
                        encryptStr}, this.SignInOperationCompleted, userState);
        }
        
        private void OnSignInOperationCompleted(object arg) {
            if ((this.SignInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SignInCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.beta-1.cn/SignOut", RequestNamespace="http://www.beta-1.cn/", ResponseNamespace="http://www.beta-1.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SignOut(string encryptStr) {
            this.Invoke("SignOut", new object[] {
                        encryptStr});
        }
        
        /// <remarks/>
        public void SignOutAsync(string encryptStr) {
            this.SignOutAsync(encryptStr, null);
        }
        
        /// <remarks/>
        public void SignOutAsync(string encryptStr, object userState) {
            if ((this.SignOutOperationCompleted == null)) {
                this.SignOutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSignOutOperationCompleted);
            }
            this.InvokeAsync("SignOut", new object[] {
                        encryptStr}, this.SignOutOperationCompleted, userState);
        }
        
        private void OnSignOutOperationCompleted(object arg) {
            if ((this.SignOutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SignOutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void SignInCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void SignOutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591
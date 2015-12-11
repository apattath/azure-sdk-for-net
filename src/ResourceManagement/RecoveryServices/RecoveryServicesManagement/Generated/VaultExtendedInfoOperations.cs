// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Hyak.Common.Internals;
using Microsoft.Azure;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.RecoveryServices
{
    /// <summary>
    /// Definition of vault extended info operations for the Recovery Services
    /// extension.
    /// </summary>
    internal partial class VaultExtendedInfoOperations : IServiceOperations<RecoveryServicesManagementClient>, IVaultExtendedInfoOperations
    {
        /// <summary>
        /// Initializes a new instance of the VaultExtendedInfoOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal VaultExtendedInfoOperations(RecoveryServicesManagementClient client)
        {
            this._client = client;
        }
        
        private RecoveryServicesManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.RecoveryServices.RecoveryServicesManagementClient.
        /// </summary>
        public RecoveryServicesManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get the vault extended info.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group containing the job
        /// collection.
        /// </param>
        /// <param name='resourceName'>
        /// Required. The name of the resource.
        /// </param>
        /// <param name='extendedInfoArgs'>
        /// Required. Create resource exnteded info input parameters.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<AzureOperationResponse> CreateExtendedInfoAsync(string resourceGroupName, string resourceName, ResourceExtendedInformationArgs extendedInfoArgs, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            if (extendedInfoArgs == null)
            {
                throw new ArgumentNullException("extendedInfoArgs");
            }
            if (extendedInfoArgs.Properties == null)
            {
                throw new ArgumentNullException("extendedInfoArgs.Properties");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("extendedInfoArgs", extendedInfoArgs);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                TracingAdapter.Enter(invocationId, this, "CreateExtendedInfoAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + Uri.EscapeDataString(this.Client.ResourceNamespace);
            url = url + "/";
            url = url + "vaults";
            url = url + "/";
            url = url + Uri.EscapeDataString(resourceName);
            url = url + "/extendedInformation/vaultExtendedInfo";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-11-10");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", customRequestHeaders.Culture);
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                httpRequest.Headers.Add("x-ms-version", "2015-01-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                JToken requestDoc = null;
                
                JObject resourceExtendedInformationArgsValue = new JObject();
                requestDoc = resourceExtendedInformationArgsValue;
                
                JObject propertiesValue = new JObject();
                resourceExtendedInformationArgsValue["properties"] = propertiesValue;
                
                if (extendedInfoArgs.Properties.IntegrityKey != null)
                {
                    propertiesValue["integrityKey"] = extendedInfoArgs.Properties.IntegrityKey;
                }
                
                if (extendedInfoArgs.Properties.Algorithm != null)
                {
                    propertiesValue["algorithm"] = extendedInfoArgs.Properties.Algorithm;
                }
                
                if (extendedInfoArgs.Properties.EncryptionKey != null)
                {
                    propertiesValue["encryptionKey"] = extendedInfoArgs.Properties.EncryptionKey;
                }
                
                if (extendedInfoArgs.Properties.EncryptionKeyThumbprint != null)
                {
                    propertiesValue["encryptionKeyThumbprint"] = extendedInfoArgs.Properties.EncryptionKeyThumbprint;
                }
                
                requestContent = requestDoc.ToString(Newtonsoft.Json.Formatting.Indented);
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode >= HttpStatusCode.BadRequest)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    AzureOperationResponse result = null;
                    // Deserialize Response
                    result = new AzureOperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get the vault extended info.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group containing the job
        /// collection.
        /// </param>
        /// <param name='resourceName'>
        /// Required. The name of the resource.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response model for the resource extended information object
        /// </returns>
        public async Task<ResourceExtendedInformationResponse> GetExtendedInfoAsync(string resourceGroupName, string resourceName, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                TracingAdapter.Enter(invocationId, this, "GetExtendedInfoAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + Uri.EscapeDataString(this.Client.ResourceNamespace);
            url = url + "/";
            url = url + "vaults";
            url = url + "/";
            url = url + Uri.EscapeDataString(resourceName);
            url = url + "/extendedInformation/vaultExtendedInfo";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-11-10");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", customRequestHeaders.Culture);
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                httpRequest.Headers.Add("x-ms-version", "2015-01-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ResourceExtendedInformationResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new ResourceExtendedInformationResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            ResourceExtendedInformation extendedInformationInstance = new ResourceExtendedInformation();
                            result.ResourceExtendedInformation = extendedInformationInstance;
                            
                            JToken propertiesValue = responseDoc["properties"];
                            if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                            {
                                ResourceExtendedInfoProperties propertiesInstance = new ResourceExtendedInfoProperties();
                                extendedInformationInstance.Properties = propertiesInstance;
                                
                                JToken integrityKeyValue = propertiesValue["integrityKey"];
                                if (integrityKeyValue != null && integrityKeyValue.Type != JTokenType.Null)
                                {
                                    string integrityKeyInstance = ((string)integrityKeyValue);
                                    propertiesInstance.IntegrityKey = integrityKeyInstance;
                                }
                                
                                JToken algorithmValue = propertiesValue["algorithm"];
                                if (algorithmValue != null && algorithmValue.Type != JTokenType.Null)
                                {
                                    string algorithmInstance = ((string)algorithmValue);
                                    propertiesInstance.Algorithm = algorithmInstance;
                                }
                                
                                JToken encryptionKeyValue = propertiesValue["encryptionKey"];
                                if (encryptionKeyValue != null && encryptionKeyValue.Type != JTokenType.Null)
                                {
                                    string encryptionKeyInstance = ((string)encryptionKeyValue);
                                    propertiesInstance.EncryptionKey = encryptionKeyInstance;
                                }
                                
                                JToken encryptionKeyThumbprintValue = propertiesValue["encryptionKeyThumbprint"];
                                if (encryptionKeyThumbprintValue != null && encryptionKeyThumbprintValue.Type != JTokenType.Null)
                                {
                                    string encryptionKeyThumbprintInstance = ((string)encryptionKeyThumbprintValue);
                                    propertiesInstance.EncryptionKeyThumbprint = encryptionKeyThumbprintInstance;
                                }
                            }
                            
                            JToken idValue = responseDoc["id"];
                            if (idValue != null && idValue.Type != JTokenType.Null)
                            {
                                string idInstance = ((string)idValue);
                                extendedInformationInstance.Id = idInstance;
                            }
                            
                            JToken nameValue = responseDoc["name"];
                            if (nameValue != null && nameValue.Type != JTokenType.Null)
                            {
                                string nameInstance = ((string)nameValue);
                                extendedInformationInstance.Name = nameInstance;
                            }
                            
                            JToken typeValue = responseDoc["type"];
                            if (typeValue != null && typeValue.Type != JTokenType.Null)
                            {
                                string typeInstance = ((string)typeValue);
                                extendedInformationInstance.Type = typeInstance;
                            }
                            
                            JToken locationValue = responseDoc["location"];
                            if (locationValue != null && locationValue.Type != JTokenType.Null)
                            {
                                string locationInstance = ((string)locationValue);
                                extendedInformationInstance.Location = locationInstance;
                            }
                            
                            JToken tagsSequenceElement = ((JToken)responseDoc["tags"]);
                            if (tagsSequenceElement != null && tagsSequenceElement.Type != JTokenType.Null)
                            {
                                foreach (JProperty property in tagsSequenceElement)
                                {
                                    string tagsKey = ((string)property.Name);
                                    string tagsValue = ((string)property.Value);
                                    extendedInformationInstance.Tags.Add(tagsKey, tagsValue);
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get the vault extended info.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group containing the job
        /// collection.
        /// </param>
        /// <param name='resourceName'>
        /// Required. The name of the resource.
        /// </param>
        /// <param name='parameters'>
        /// Required. Upload Vault Certificate input parameters.
        /// </param>
        /// <param name='certFriendlyName'>
        /// Required. Certificate friendly name
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response model for the upload certificate response
        /// </returns>
        public async Task<UploadCertificateResponse> UploadCertificateAsync(string resourceGroupName, string resourceName, CertificateArgs parameters, string certFriendlyName, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.Properties == null)
            {
                throw new ArgumentNullException("parameters.Properties");
            }
            if (certFriendlyName == null)
            {
                throw new ArgumentNullException("certFriendlyName");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("certFriendlyName", certFriendlyName);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                TracingAdapter.Enter(invocationId, this, "UploadCertificateAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + Uri.EscapeDataString(this.Client.ResourceNamespace);
            url = url + "/";
            url = url + "vaults";
            url = url + "/";
            url = url + Uri.EscapeDataString(resourceName);
            url = url + "/certificates/";
            url = url + Uri.EscapeDataString(certFriendlyName);
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-11-10");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", customRequestHeaders.Culture);
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                JToken requestDoc = null;
                
                JObject parametersValue = new JObject();
                requestDoc = parametersValue;
                
                if (parameters.Properties != null)
                {
                    if (parameters.Properties is ILazyCollection == false || ((ILazyCollection)parameters.Properties).IsInitialized)
                    {
                        JObject propertiesDictionary = new JObject();
                        foreach (KeyValuePair<string, string> pair in parameters.Properties)
                        {
                            string propertiesKey = pair.Key;
                            string propertiesValue = pair.Value;
                            propertiesDictionary[propertiesKey] = propertiesValue;
                        }
                        parametersValue["properties"] = propertiesDictionary;
                    }
                }
                
                requestContent = requestDoc.ToString(Newtonsoft.Json.Formatting.Indented);
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    UploadCertificateResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new UploadCertificateResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken propertiesValue2 = responseDoc["properties"];
                            if (propertiesValue2 != null && propertiesValue2.Type != JTokenType.Null)
                            {
                                CertificateProperties propertiesInstance = new CertificateProperties();
                                result.Properties = propertiesInstance;
                                
                                JToken friendlyNameValue = propertiesValue2["friendlyName"];
                                if (friendlyNameValue != null && friendlyNameValue.Type != JTokenType.Null)
                                {
                                    string friendlyNameInstance = ((string)friendlyNameValue);
                                    propertiesInstance.FriendlyName = friendlyNameInstance;
                                }
                                
                                JToken globalAcsHostNameValue = propertiesValue2["globalAcsHostName"];
                                if (globalAcsHostNameValue != null && globalAcsHostNameValue.Type != JTokenType.Null)
                                {
                                    string globalAcsHostNameInstance = ((string)globalAcsHostNameValue);
                                    propertiesInstance.GlobalAcsHostName = globalAcsHostNameInstance;
                                }
                                
                                JToken globalAcsNamespaceValue = propertiesValue2["globalAcsNamespace"];
                                if (globalAcsNamespaceValue != null && globalAcsNamespaceValue.Type != JTokenType.Null)
                                {
                                    string globalAcsNamespaceInstance = ((string)globalAcsNamespaceValue);
                                    propertiesInstance.GlobalAcsNamespace = globalAcsNamespaceInstance;
                                }
                                
                                JToken globalAcsRPRealmValue = propertiesValue2["globalAcsRPRealm"];
                                if (globalAcsRPRealmValue != null && globalAcsRPRealmValue.Type != JTokenType.Null)
                                {
                                    string globalAcsRPRealmInstance = ((string)globalAcsRPRealmValue);
                                    propertiesInstance.GlobalAcsRPRealm = globalAcsRPRealmInstance;
                                }
                                
                                JToken resourceIdValue = propertiesValue2["resourceId"];
                                if (resourceIdValue != null && resourceIdValue.Type != JTokenType.Null)
                                {
                                    long resourceIdInstance = ((long)resourceIdValue);
                                    propertiesInstance.ResourceId = resourceIdInstance;
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}

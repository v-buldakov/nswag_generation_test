//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using ApiClient.Generator.Sample.Contracts;
using ApiClient.Generator.Sample.Client.Clients;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 612 // Disable "CS0612 '...' is obsolete"
#pragma warning disable 649 // Disable "CS0649 Field is never assigned to, and will always have its default value null"
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8600 // Disable "CS8600 Converting null literal or possible null value to non-nullable type"
#pragma warning disable 8602 // Disable "CS8602 Dereference of a possibly null reference"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"
#pragma warning disable 8604 // Disable "CS8604 Possible null reference argument for parameter"
#pragma warning disable 8625 // Disable "CS8625 Cannot convert null literal to non-nullable reference type"
#pragma warning disable 8765 // Disable "CS8765 Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes)."

namespace ApiClient.Generator.Sample.Client.Clients
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ValuesClient : ApiHttpBaseClient, IValuesClient
    {
        private System.Net.Http.HttpClient _httpClient;
        private static System.Lazy<System.Text.Json.JsonSerializerOptions> _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings, true);
        private System.Text.Json.JsonSerializerOptions _instanceSettings;

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ValuesClient(ApiHttpConfiguration configuration, System.Net.Http.HttpClient httpClient) : base(configuration)
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _httpClient = httpClient;
            Initialize();
        }

        private static System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
        {
            var settings = new System.Text.Json.JsonSerializerOptions();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _instanceSettings ?? _settings.Value; } }

        partial void Initialize();

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <summary>
        /// get random value
        /// </summary>
        /// <returns>int</returns>
        /// <exception cref="ValuesApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<int> GetValueAsync(string api_version)
        {
            return GetValueAsync(api_version, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// get random value
        /// </summary>
        /// <returns>int</returns>
        /// <exception cref="ValuesApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<int> GetValueAsync(string api_version, System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    var urlBuilder_ = new System.Text.StringBuilder();
                
                    // Operation Path: "Values"
                    urlBuilder_.Append("Values");
                    urlBuilder_.Append('?');
                    if (api_version != null)
                    {
                        urlBuilder_.Append(System.Uri.EscapeDataString("api-version")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(api_version, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                    }
                    urlBuilder_.Length--;

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                        foreach (var item_ in response_.Headers)
                            headers_[item_.Key] = item_.Value;
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<int>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ValuesApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ValuesApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ValuesApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ValuesApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool) 
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value is string[])
            {
                return string.Join(",", (string[])value);
            }
            else if (value.GetType().IsArray)
            {
                var valueArray = (System.Array)value;
                var valueTextArray = new string[valueArray.Length];
                for (var i = 0; i < valueArray.Length; i++)
                {
                    valueTextArray[i] = ConvertToString(valueArray.GetValue(i), cultureInfo);
                }
                return string.Join(",", valueTextArray);
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class WeatherForecastClient : ApiHttpBaseClient, IWeatherForecastClient
    {
        private System.Net.Http.HttpClient _httpClient;
        private static System.Lazy<System.Text.Json.JsonSerializerOptions> _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings, true);
        private System.Text.Json.JsonSerializerOptions _instanceSettings;

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public WeatherForecastClient(ApiHttpConfiguration configuration, System.Net.Http.HttpClient httpClient) : base(configuration)
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _httpClient = httpClient;
            Initialize();
        }

        private static System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
        {
            var settings = new System.Text.Json.JsonSerializerOptions();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _instanceSettings ?? _settings.Value; } }

        partial void Initialize();

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <exception cref="WeatherForecastApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecast>> GetForecastsAsync()
        {
            return GetForecastsAsync(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="WeatherForecastApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecast>> GetForecastsAsync(System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    var urlBuilder_ = new System.Text.StringBuilder();
                
                    // Operation Path: "v1/weather-forecast"
                    urlBuilder_.Append("v1/weather-forecast");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                        foreach (var item_ in response_.Headers)
                            headers_[item_.Key] = item_.Value;
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<WeatherForecast>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new WeatherForecastApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new WeatherForecastApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <exception cref="WeatherForecastApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecast>> GetForecasts2Async()
        {
            return GetForecasts2Async(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="WeatherForecastApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecast>> GetForecasts2Async(System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    var urlBuilder_ = new System.Text.StringBuilder();
                
                    // Operation Path: "v2/weather-forecast"
                    urlBuilder_.Append("v2/weather-forecast");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                        foreach (var item_ in response_.Headers)
                            headers_[item_.Key] = item_.Value;
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<WeatherForecast>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new WeatherForecastApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new WeatherForecastApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <exception cref="WeatherForecastApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecastV2>> GenericResponseAsync()
        {
            return GenericResponseAsync(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="WeatherForecastApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecastV2>> GenericResponseAsync(System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    var urlBuilder_ = new System.Text.StringBuilder();
                
                    // Operation Path: "v2/weather-forecast/generic-response"
                    urlBuilder_.Append("v2/weather-forecast/generic-response");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                        foreach (var item_ in response_.Headers)
                            headers_[item_.Key] = item_.Value;
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<WeatherForecastV2>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new WeatherForecastApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new WeatherForecastApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new WeatherForecastApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new WeatherForecastApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool) 
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value is string[])
            {
                return string.Join(",", (string[])value);
            }
            else if (value.GetType().IsArray)
            {
                var valueArray = (System.Array)value;
                var valueTextArray = new string[valueArray.Length];
                for (var i = 0; i < valueArray.Length; i++)
                {
                    valueTextArray[i] = ConvertToString(valueArray.GetValue(i), cultureInfo);
                }
                return string.Join(",", valueTextArray);
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }
    }

}

#pragma warning restore  108
#pragma warning restore  114
#pragma warning restore  472
#pragma warning restore  612
#pragma warning restore 1573
#pragma warning restore 1591
#pragma warning restore 8073
#pragma warning restore 3016
#pragma warning restore 8600
#pragma warning restore 8602
#pragma warning restore 8603
#pragma warning restore 8604
#pragma warning restore 8625
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PostmanCollectionReader
{
    public partial class PostmanCollection
    {
        [JsonProperty("auth")]
        public Auth Auth { get; set; }

        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public List<Event> Event { get; set; }

        [JsonProperty("info")]
        public Information Info { get; set; }

        /// <summary>
        /// Items are the basic unit for a Postman collection. You can think of them as corresponding
        /// to a single API endpoint. Each Item has one request and may have multiple API responses
        /// associated with it.
        /// </summary>
        [JsonProperty("item")]
        public List<Items> Item { get; set; }

        [JsonProperty("protocolProfileBehavior", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> ProtocolProfileBehavior { get; set; }

        [JsonProperty("variable", NullValueHandling = NullValueHandling.Ignore)]
        public List<Variable> Variable { get; set; }
    }

    /// <summary>
    /// Represents authentication helpers provided by Postman
    /// </summary>
    public partial class Auth
    {
        /// <summary>
        /// The attributes for API Key Authentication.
        /// </summary>
        [JsonProperty("apikey", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Apikey { get; set; }

        /// <summary>
        /// The attributes for [AWS
        /// Auth](http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html).
        /// </summary>
        [JsonProperty("awsv4", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Awsv4 { get; set; }

        /// <summary>
        /// The attributes for [Basic
        /// Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication).
        /// </summary>
        [JsonProperty("basic", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Basic { get; set; }

        /// <summary>
        /// The helper attributes for [Bearer Token
        /// Authentication](https://tools.ietf.org/html/rfc6750)
        /// </summary>
        [JsonProperty("bearer", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Bearer { get; set; }

        /// <summary>
        /// The attributes for [Digest
        /// Authentication](https://en.wikipedia.org/wiki/Digest_access_authentication).
        /// </summary>
        [JsonProperty("digest", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Digest { get; set; }

        /// <summary>
        /// The attributes for [Akamai EdgeGrid
        /// Authentication](https://developer.akamai.com/legacy/introduction/Client_Auth.html).
        /// </summary>
        [JsonProperty("edgegrid", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Edgegrid { get; set; }

        /// <summary>
        /// The attributes for [Hawk Authentication](https://github.com/hueniverse/hawk)
        /// </summary>
        [JsonProperty("hawk", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Hawk { get; set; }

        [JsonProperty("noauth")]
        public object Noauth { get; set; }

        /// <summary>
        /// The attributes for [NTLM
        /// Authentication](https://msdn.microsoft.com/en-us/library/cc237488.aspx)
        /// </summary>
        [JsonProperty("ntlm", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Ntlm { get; set; }

        /// <summary>
        /// The attributes for [OAuth2](https://oauth.net/1/)
        /// </summary>
        [JsonProperty("oauth1", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Oauth1 { get; set; }

        /// <summary>
        /// Helper attributes for [OAuth2](https://oauth.net/2/)
        /// </summary>
        [JsonProperty("oauth2", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApikeyElement> Oauth2 { get; set; }

        [JsonProperty("type")]
        public AuthType Type { get; set; }
    }

    /// <summary>
    /// Represents an attribute for any authorization method provided by Postman. For example
    /// `username` and `password` are set as auth attributes for Basic Authentication method.
    /// </summary>
    public partial class ApikeyElement
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }

    /// <summary>
    /// Postman allows you to configure scripts to run when specific events occur. These scripts
    /// are stored here, and can be referenced in the collection by their ID.
    ///
    /// Defines a script associated with an associated event name
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Indicates whether the event is disabled. If absent, the event is assumed to be enabled.
        /// </summary>
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// A unique identifier for the enclosing event.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Can be set to `test` or `prerequest` for test scripts or pre-request scripts respectively.
        /// </summary>
        [JsonProperty("listen")]
        public string Listen { get; set; }

        [JsonProperty("script", NullValueHandling = NullValueHandling.Ignore)]
        public Script Script { get; set; }
    }

    /// <summary>
    /// A script is a snippet of Javascript code that can be used to to perform setup or teardown
    /// operations on a particular response.
    /// </summary>
    public partial class Script
    {
        [JsonProperty("exec", NullValueHandling = NullValueHandling.Ignore)]
        public Host? Exec { get; set; }

        /// <summary>
        /// A unique, user defined identifier that can  be used to refer to this script from requests.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Script name
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("src", NullValueHandling = NullValueHandling.Ignore)]
        public Url? Src { get; set; }

        /// <summary>
        /// Type of the script. E.g: 'text/javascript'
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public partial class UrlClass
    {
        /// <summary>
        /// Contains the URL fragment (if any). Usually this is not transmitted over the network, but
        /// it could be useful to store this in some cases.
        /// </summary>
        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        /// <summary>
        /// The host for the URL, E.g: api.yourdomain.com. Can be stored as a string or as an array
        /// of strings.
        /// </summary>
        [JsonProperty("host", NullValueHandling = NullValueHandling.Ignore)]
        public Host? Host { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public UrlPath? Path { get; set; }

        /// <summary>
        /// The port number present in this URL. An empty value implies 80/443 depending on whether
        /// the protocol field contains http/https.
        /// </summary>
        [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
        public string Port { get; set; }

        /// <summary>
        /// The protocol associated with the request, E.g: 'http'
        /// </summary>
        [JsonProperty("protocol", NullValueHandling = NullValueHandling.Ignore)]
        public string Protocol { get; set; }

        /// <summary>
        /// An array of QueryParams, which is basically the query string part of the URL, parsed into
        /// separate variables
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryParam> Query { get; set; }

        /// <summary>
        /// The string representation of the request URL, including the protocol, host, path, hash,
        /// query parameter(s) and path variable(s).
        /// </summary>
        [JsonProperty("raw", NullValueHandling = NullValueHandling.Ignore)]
        public string Raw { get; set; }

        /// <summary>
        /// Postman supports path variables with the syntax `/path/:variableName/to/somewhere`. These
        /// variables are stored in this field.
        /// </summary>
        [JsonProperty("variable", NullValueHandling = NullValueHandling.Ignore)]
        public List<Variable> Variable { get; set; }
    }

    public partial class PathClass
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public partial class QueryParam
    {
        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        /// <summary>
        /// If set to true, the current query parameter will not be sent with the request.
        /// </summary>
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class Description
    {
        /// <summary>
        /// The content of the description goes here, as a raw string.
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        /// <summary>
        /// Holds the mime type of the raw description content. E.g: 'text/markdown' or 'text/html'.
        /// The type is used to correctly render the description when generating documentation, or in
        /// the Postman app.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Description can have versions associated with it, which should be put in this property.
        /// </summary>
        [JsonProperty("version")]
        public object Version { get; set; }
    }

    /// <summary>
    /// Collection variables allow you to define a set of variables, that are a *part of the
    /// collection*, as opposed to environments, which are separate entities.
    /// *Note: Collection variables must not contain any sensitive information.*
    ///
    /// Using variables in your Postman requests eliminates the need to duplicate requests, which
    /// can save a lot of time. Variables can be defined, and referenced to from any part of a
    /// request.
    /// </summary>
    public partial class Variable
    {
        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// A variable ID is a unique user-defined value that identifies the variable within a
        /// collection. In traditional terms, this would be a variable name.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// A variable key is a human friendly value that identifies the variable within a
        /// collection. In traditional terms, this would be a variable name.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        /// <summary>
        /// Variable name
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// When set to true, indicates that this variable has been set by Postman
        /// </summary>
        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public bool? System { get; set; }

        /// <summary>
        /// A variable may have multiple types. This field specifies the type of the variable.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public VariableType? Type { get; set; }

        /// <summary>
        /// The value that a variable holds in this collection. Ultimately, the variables will be
        /// replaced by this value, when say running a set of requests from a collection
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }
    }

    /// <summary>
    /// Detailed description of the info block
    /// </summary>
    public partial class Information
    {
        /// <summary>
        /// Every collection is identified by the unique value of this field. The value of this field
        /// is usually easiest to generate using a UID generator function. If you already have a
        /// collection, it is recommended that you maintain the same id since changing the id usually
        /// implies that is a different collection than it was originally.
        /// *Note: This field exists for compatibility reasons with Collection Format V1.*
        /// </summary>
        [JsonProperty("_postman_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PostmanId { get; set; }

        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        /// <summary>
        /// A collection's friendly name is defined by this field. You would want to set this field
        /// to a value that would allow you to easily identify this collection among a bunch of other
        /// collections, as such outlining its usage or content.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// This should ideally hold a link to the Postman schema that is used to validate this
        /// collection. E.g: https://schema.getpostman.com/collection/v1
        /// </summary>
        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public CollectionVersion? Version { get; set; }
    }

    public partial class CollectionVersionClass
    {
        /// <summary>
        /// A human friendly identifier to make sense of the version numbers. E.g: 'beta-3'
        /// </summary>
        [JsonProperty("identifier", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(MinMaxLengthCheckConverter))]
        public string Identifier { get; set; }

        /// <summary>
        /// Increment this number if you make changes to the collection that changes its behaviour.
        /// E.g: Removing or adding new test scripts. (partly or completely).
        /// </summary>
        [JsonProperty("major")]
        public long Major { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        /// <summary>
        /// You should increment this number if you make changes that will not break anything that
        /// uses the collection. E.g: removing a folder.
        /// </summary>
        [JsonProperty("minor")]
        public long Minor { get; set; }

        /// <summary>
        /// Ideally, minor changes to a collection should result in the increment of this number.
        /// </summary>
        [JsonProperty("patch")]
        public long Patch { get; set; }
    }

    /// <summary>
    /// Items are entities which contain an actual HTTP request, and sample responses attached to
    /// it.
    ///
    /// One of the primary goals of Postman is to organize the development of APIs. To this end,
    /// it is necessary to be able to group requests together. This can be achived using
    /// 'Folders'. A folder just is an ordered set of requests.
    /// </summary>
    public partial class Items
    {
        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public List<Event> Event { get; set; }

        /// <summary>
        /// A unique ID that is used to identify collections internally
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// A human readable identifier for the current item.
        ///
        /// A folder's friendly name is defined by this field. You would want to set this field to a
        /// value that would allow you to easily identify this folder.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("protocolProfileBehavior", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> ProtocolProfileBehavior { get; set; }

        [JsonProperty("request", NullValueHandling = NullValueHandling.Ignore)]
        public RequestUnion? Request { get; set; }

        [JsonProperty("response", NullValueHandling = NullValueHandling.Ignore)]
        public List<Response> Response { get; set; }

        [JsonProperty("variable", NullValueHandling = NullValueHandling.Ignore)]
        public List<Variable> Variable { get; set; }

        [JsonProperty("auth")]
        public Auth Auth { get; set; }

        /// <summary>
        /// Items are entities which contain an actual HTTP request, and sample responses attached to
        /// it. Folders may contain many items.
        /// </summary>
        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public List<Items> Item { get; set; }
    }

    public partial class RequestClass
    {
        [JsonProperty("auth")]
        public Auth Auth { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("certificate", NullValueHandling = NullValueHandling.Ignore)]
        public Certificate Certificate { get; set; }

        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        public HeaderUnion? Header { get; set; }

        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty("proxy", NullValueHandling = NullValueHandling.Ignore)]
        public ProxyConfig Proxy { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Url? Url { get; set; }
    }

    /// <summary>
    /// This field contains the data usually contained in the request body.
    /// </summary>
    public partial class Body
    {
        /// <summary>
        /// When set to true, prevents request body from being sent.
        /// </summary>
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
        public File File { get; set; }

        [JsonProperty("formdata", NullValueHandling = NullValueHandling.Ignore)]
        public List<FormParameter> Formdata { get; set; }

        [JsonProperty("graphql", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Graphql { get; set; }

        /// <summary>
        /// Postman stores the type of data associated with this request in this field.
        /// </summary>
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public Mode? Mode { get; set; }

        /// <summary>
        /// Additional configurations and options set for various body modes.
        /// </summary>
        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Options { get; set; }

        [JsonProperty("raw", NullValueHandling = NullValueHandling.Ignore)]
        public string Raw { get; set; }

        [JsonProperty("urlencoded", NullValueHandling = NullValueHandling.Ignore)]
        public List<UrlEncodedParameter> Urlencoded { get; set; }
    }

    public partial class File
    {
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }
    }

    public partial class FormParameter
    {
        /// <summary>
        /// Override Content-Type header of this form data entity.
        /// </summary>
        [JsonProperty("contentType", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType { get; set; }

        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        /// <summary>
        /// When set to true, prevents this form data entity from being sent.
        /// </summary>
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public FormParameterType? Type { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("src")]
        public Src? Src { get; set; }
    }

    public partial class UrlEncodedParameter
    {
        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    /// <summary>
    /// A representation of an ssl certificate
    /// </summary>
    public partial class Certificate
    {
        /// <summary>
        /// An object containing path to file certificate, on the file system
        /// </summary>
        [JsonProperty("cert", NullValueHandling = NullValueHandling.Ignore)]
        public Cert Cert { get; set; }

        /// <summary>
        /// An object containing path to file containing private key, on the file system
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public Key Key { get; set; }

        /// <summary>
        /// A list of Url match pattern strings, to identify Urls this certificate can be used for.
        /// </summary>
        [JsonProperty("matches", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Matches { get; set; }

        /// <summary>
        /// A name for the certificate for user reference
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The passphrase for the certificate
        /// </summary>
        [JsonProperty("passphrase", NullValueHandling = NullValueHandling.Ignore)]
        public string Passphrase { get; set; }
    }

    /// <summary>
    /// An object containing path to file certificate, on the file system
    /// </summary>
    public partial class Cert
    {
        /// <summary>
        /// The path to file containing key for certificate, on the file system
        /// </summary>
        [JsonProperty("src")]
        public object Src { get; set; }
    }

    /// <summary>
    /// An object containing path to file containing private key, on the file system
    /// </summary>
    public partial class Key
    {
        /// <summary>
        /// The path to file containing key for certificate, on the file system
        /// </summary>
        [JsonProperty("src")]
        public object Src { get; set; }
    }

    /// <summary>
    /// A representation for a list of headers
    ///
    /// Represents a single HTTP Header
    /// </summary>
    public partial class Header
    {
        [JsonProperty("description")]
        public DescriptionUnion? Description { get; set; }

        /// <summary>
        /// If set to true, the current header will not be sent with requests.
        /// </summary>
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// This holds the LHS of the HTTP Header, e.g ``Content-Type`` or ``X-Custom-Header``
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// The value (or the RHS) of the Header is stored in this field.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    /// <summary>
    /// Using the Proxy, you can configure your custom proxy into the postman for particular url
    /// match
    /// </summary>
    public partial class ProxyConfig
    {
        /// <summary>
        /// When set to true, ignores this proxy configuration entity
        /// </summary>
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The proxy server host
        /// </summary>
        [JsonProperty("host", NullValueHandling = NullValueHandling.Ignore)]
        public string Host { get; set; }

        /// <summary>
        /// The Url match for which the proxy config is defined
        /// </summary>
        [JsonProperty("match", NullValueHandling = NullValueHandling.Ignore)]
        public string Match { get; set; }

        /// <summary>
        /// The proxy server port
        /// </summary>
        [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port { get; set; }

        /// <summary>
        /// The tunneling details for the proxy config
        /// </summary>
        [JsonProperty("tunnel", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Tunnel { get; set; }
    }

    public partial class ResponseClass
    {
        /// <summary>
        /// The raw text of the response.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// The numerical response code, example: 200, 201, 404, etc.
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public long? Code { get; set; }

        [JsonProperty("cookie", NullValueHandling = NullValueHandling.Ignore)]
        public List<Cookie> Cookie { get; set; }

        [JsonProperty("header")]
        public Headers? Header { get; set; }

        /// <summary>
        /// A unique, user defined identifier that can  be used to refer to this response from
        /// requests.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("originalRequest", NullValueHandling = NullValueHandling.Ignore)]
        public RequestUnion? OriginalRequest { get; set; }

        /// <summary>
        /// The time taken by the request to complete. If a number, the unit is milliseconds. If the
        /// response is manually created, this can be set to `null`.
        /// </summary>
        [JsonProperty("responseTime")]
        public ResponseTime? ResponseTime { get; set; }

        /// <summary>
        /// The response status, e.g: '200 OK'
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Set of timing information related to request and response in milliseconds
        /// </summary>
        [JsonProperty("timings")]
        public Dictionary<string, object> Timings { get; set; }
    }

    /// <summary>
    /// A Cookie, that follows the [Google Chrome
    /// format](https://developer.chrome.com/extensions/cookies)
    /// </summary>
    public partial class Cookie
    {
        /// <summary>
        /// The domain for which this cookie is valid.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// When the cookie expires.
        /// </summary>
        [JsonProperty("expires", NullValueHandling = NullValueHandling.Ignore)]
        public Expires? Expires { get; set; }

        /// <summary>
        /// Custom attributes for a cookie go here, such as the [Priority
        /// Field](https://code.google.com/p/chromium/issues/detail?id=232693)
        /// </summary>
        [JsonProperty("extensions", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Extensions { get; set; }

        /// <summary>
        /// True if the cookie is a host-only cookie. (i.e. a request's URL domain must exactly match
        /// the domain of the cookie).
        /// </summary>
        [JsonProperty("hostOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HostOnly { get; set; }

        /// <summary>
        /// Indicates if this cookie is HTTP Only. (if True, the cookie is inaccessible to
        /// client-side scripts)
        /// </summary>
        [JsonProperty("httpOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HttpOnly { get; set; }

        [JsonProperty("maxAge", NullValueHandling = NullValueHandling.Ignore)]
        public string MaxAge { get; set; }

        /// <summary>
        /// This is the name of the Cookie.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The path associated with the Cookie.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Indicates if the 'secure' flag is set on the Cookie, meaning that it is transmitted over
        /// secure connections only. (typically HTTPS)
        /// </summary>
        [JsonProperty("secure", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Secure { get; set; }

        /// <summary>
        /// True if the cookie is a session cookie.
        /// </summary>
        [JsonProperty("session", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Session { get; set; }

        /// <summary>
        /// The value of the Cookie.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public enum AuthType { Apikey, Awsv4, Basic, Bearer, Digest, Edgegrid, Hawk, Noauth, Ntlm, Oauth1, Oauth2 };

    /// <summary>
    /// A variable may have multiple types. This field specifies the type of the variable.
    /// </summary>
    public enum VariableType { Any, Boolean, Number, String };

    public enum FormParameterType { File, Text };

    /// <summary>
    /// Postman stores the type of data associated with this request in this field.
    /// </summary>
    public enum Mode { File, Formdata, Graphql, Raw, Urlencoded };

    /// <summary>
    /// The host for the URL, E.g: api.yourdomain.com. Can be stored as a string or as an array
    /// of strings.
    /// </summary>
    public partial struct Host
    {
        public string String;
        public List<string> StringArray;

        public static implicit operator Host(string String) => new Host { String = String };
        public static implicit operator Host(List<string> StringArray) => new Host { StringArray = StringArray };
    }

    /// <summary>
    /// The complete path of the current url, broken down into segments. A segment could be a
    /// string, or a path variable.
    /// </summary>
    public partial struct PathElement
    {
        public PathClass PathClass;
        public string String;

        public static implicit operator PathElement(PathClass PathClass) => new PathElement { PathClass = PathClass };
        public static implicit operator PathElement(string String) => new PathElement { String = String };
    }

    public partial struct UrlPath
    {
        public List<PathElement> AnythingArray;
        public string String;

        public static implicit operator UrlPath(List<PathElement> AnythingArray) => new UrlPath { AnythingArray = AnythingArray };
        public static implicit operator UrlPath(string String) => new UrlPath { String = String };
    }

    /// <summary>
    /// A Description can be a raw text, or be an object, which holds the description along with
    /// its format.
    /// </summary>
    public partial struct DescriptionUnion
    {
        public Description Description;
        public string String;

        public static implicit operator DescriptionUnion(Description Description) => new DescriptionUnion { Description = Description };
        public static implicit operator DescriptionUnion(string String) => new DescriptionUnion { String = String };
        public bool IsNull => Description == null && String == null;
    }

    /// <summary>
    /// If object, contains the complete broken-down URL for this request. If string, contains
    /// the literal request URL.
    /// </summary>
    public partial struct Url
    {
        public string String;
        public UrlClass UrlClass;

        public static implicit operator Url(string String) => new Url { String = String };
        public static implicit operator Url(UrlClass UrlClass) => new Url { UrlClass = UrlClass };
    }

    /// <summary>
    /// Postman allows you to version your collections as they grow, and this field holds the
    /// version number. While optional, it is recommended that you use this field to its fullest
    /// extent!
    /// </summary>
    public partial struct CollectionVersion
    {
        public CollectionVersionClass CollectionVersionClass;
        public string String;

        public static implicit operator CollectionVersion(CollectionVersionClass CollectionVersionClass) => new CollectionVersion { CollectionVersionClass = CollectionVersionClass };
        public static implicit operator CollectionVersion(string String) => new CollectionVersion { String = String };
    }

    public partial struct Src
    {
        public List<object> AnythingArray;
        public string String;

        public static implicit operator Src(List<object> AnythingArray) => new Src { AnythingArray = AnythingArray };
        public static implicit operator Src(string String) => new Src { String = String };
        public bool IsNull => AnythingArray == null && String == null;
    }

    public partial struct HeaderUnion
    {
        public List<Header> HeaderArray;
        public string String;

        public static implicit operator HeaderUnion(List<Header> HeaderArray) => new HeaderUnion { HeaderArray = HeaderArray };
        public static implicit operator HeaderUnion(string String) => new HeaderUnion { String = String };
    }

    /// <summary>
    /// A request represents an HTTP request. If a string, the string is assumed to be the
    /// request URL and the method is assumed to be 'GET'.
    /// </summary>
    public partial struct RequestUnion
    {
        public RequestClass RequestClass;
        public string String;

        public static implicit operator RequestUnion(RequestClass RequestClass) => new RequestUnion { RequestClass = RequestClass };
        public static implicit operator RequestUnion(string String) => new RequestUnion { String = String };
    }

    /// <summary>
    /// When the cookie expires.
    /// </summary>
    public partial struct Expires
    {
        public double? Double;
        public string String;

        public static implicit operator Expires(double Double) => new Expires { Double = Double };
        public static implicit operator Expires(string String) => new Expires { String = String };
    }

    /// <summary>
    /// No HTTP request is complete without its headers, and the same is true for a Postman
    /// request. This field is an array containing all the headers.
    /// </summary>
    public partial struct HeaderElement
    {
        public Header Header;
        public string String;

        public static implicit operator HeaderElement(Header Header) => new HeaderElement { Header = Header };
        public static implicit operator HeaderElement(string String) => new HeaderElement { String = String };
    }

    public partial struct Headers
    {
        public List<HeaderElement> AnythingArray;
        public string String;

        public static implicit operator Headers(List<HeaderElement> AnythingArray) => new Headers { AnythingArray = AnythingArray };
        public static implicit operator Headers(string String) => new Headers { String = String };
        public bool IsNull => AnythingArray == null && String == null;
    }

    /// <summary>
    /// The time taken by the request to complete. If a number, the unit is milliseconds. If the
    /// response is manually created, this can be set to `null`.
    /// </summary>
    public partial struct ResponseTime
    {
        public double? Double;
        public string String;

        public static implicit operator ResponseTime(double Double) => new ResponseTime { Double = Double };
        public static implicit operator ResponseTime(string String) => new ResponseTime { String = String };
        public bool IsNull => Double == null && String == null;
    }

    /// <summary>
    /// A response represents an HTTP response.
    /// </summary>
    public partial struct Response
    {
        public List<object> AnythingArray;
        public bool? Bool;
        public double? Double;
        public long? Integer;
        public ResponseClass ResponseClass;
        public string String;

        public static implicit operator Response(List<object> AnythingArray) => new Response { AnythingArray = AnythingArray };
        public static implicit operator Response(bool Bool) => new Response { Bool = Bool };
        public static implicit operator Response(double Double) => new Response { Double = Double };
        public static implicit operator Response(long Integer) => new Response { Integer = Integer };
        public static implicit operator Response(ResponseClass ResponseClass) => new Response { ResponseClass = ResponseClass };
        public static implicit operator Response(string String) => new Response { String = String };
        public bool IsNull => AnythingArray == null && Bool == null && ResponseClass == null && Double == null && Integer == null && String == null;
    }

    public partial class PostmanCollection
    {
        public static PostmanCollection FromJson(string json) => JsonConvert.DeserializeObject<PostmanCollection>(json, PostmanCollectionReader.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PostmanCollection self) => JsonConvert.SerializeObject(self, PostmanCollectionReader.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AuthTypeConverter.Singleton,
                HostConverter.Singleton,
                UrlConverter.Singleton,
                UrlPathConverter.Singleton,
                PathElementConverter.Singleton,
                DescriptionUnionConverter.Singleton,
                VariableTypeConverter.Singleton,
                CollectionVersionConverter.Singleton,
                RequestUnionConverter.Singleton,
                SrcConverter.Singleton,
                FormParameterTypeConverter.Singleton,
                ModeConverter.Singleton,
                HeaderUnionConverter.Singleton,
                ResponseConverter.Singleton,
                ExpiresConverter.Singleton,
                HeadersConverter.Singleton,
                HeaderElementConverter.Singleton,
                ResponseTimeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AuthTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AuthType) || t == typeof(AuthType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "apikey":
                    return AuthType.Apikey;
                case "awsv4":
                    return AuthType.Awsv4;
                case "basic":
                    return AuthType.Basic;
                case "bearer":
                    return AuthType.Bearer;
                case "digest":
                    return AuthType.Digest;
                case "edgegrid":
                    return AuthType.Edgegrid;
                case "hawk":
                    return AuthType.Hawk;
                case "noauth":
                    return AuthType.Noauth;
                case "ntlm":
                    return AuthType.Ntlm;
                case "oauth1":
                    return AuthType.Oauth1;
                case "oauth2":
                    return AuthType.Oauth2;
            }
            throw new Exception("Cannot unmarshal type AuthType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AuthType)untypedValue;
            switch (value)
            {
                case AuthType.Apikey:
                    serializer.Serialize(writer, "apikey");
                    return;
                case AuthType.Awsv4:
                    serializer.Serialize(writer, "awsv4");
                    return;
                case AuthType.Basic:
                    serializer.Serialize(writer, "basic");
                    return;
                case AuthType.Bearer:
                    serializer.Serialize(writer, "bearer");
                    return;
                case AuthType.Digest:
                    serializer.Serialize(writer, "digest");
                    return;
                case AuthType.Edgegrid:
                    serializer.Serialize(writer, "edgegrid");
                    return;
                case AuthType.Hawk:
                    serializer.Serialize(writer, "hawk");
                    return;
                case AuthType.Noauth:
                    serializer.Serialize(writer, "noauth");
                    return;
                case AuthType.Ntlm:
                    serializer.Serialize(writer, "ntlm");
                    return;
                case AuthType.Oauth1:
                    serializer.Serialize(writer, "oauth1");
                    return;
                case AuthType.Oauth2:
                    serializer.Serialize(writer, "oauth2");
                    return;
            }
            throw new Exception("Cannot marshal type AuthType");
        }

        public static readonly AuthTypeConverter Singleton = new AuthTypeConverter();
    }

    internal class HostConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Host) || t == typeof(Host?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Host { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<string>>(reader);
                    return new Host { StringArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Host");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Host)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.StringArray != null)
            {
                serializer.Serialize(writer, value.StringArray);
                return;
            }
            throw new Exception("Cannot marshal type Host");
        }

        public static readonly HostConverter Singleton = new HostConverter();
    }

    internal class UrlConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Url) || t == typeof(Url?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Url { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<UrlClass>(reader);
                    return new Url { UrlClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type Url");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Url)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.UrlClass != null)
            {
                serializer.Serialize(writer, value.UrlClass);
                return;
            }
            throw new Exception("Cannot marshal type Url");
        }

        public static readonly UrlConverter Singleton = new UrlConverter();
    }

    internal class UrlPathConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(UrlPath) || t == typeof(UrlPath?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new UrlPath { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<PathElement>>(reader);
                    return new UrlPath { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type UrlPath");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (UrlPath)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.AnythingArray != null)
            {
                serializer.Serialize(writer, value.AnythingArray);
                return;
            }
            throw new Exception("Cannot marshal type UrlPath");
        }

        public static readonly UrlPathConverter Singleton = new UrlPathConverter();
    }

    internal class PathElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PathElement) || t == typeof(PathElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PathElement { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PathClass>(reader);
                    return new PathElement { PathClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type PathElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PathElement)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.PathClass != null)
            {
                serializer.Serialize(writer, value.PathClass);
                return;
            }
            throw new Exception("Cannot marshal type PathElement");
        }

        public static readonly PathElementConverter Singleton = new PathElementConverter();
    }

    internal class DescriptionUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DescriptionUnion) || t == typeof(DescriptionUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new DescriptionUnion { };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new DescriptionUnion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<Description>(reader);
                    return new DescriptionUnion { Description = objectValue };
            }
            throw new Exception("Cannot unmarshal type DescriptionUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DescriptionUnion)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.Description != null)
            {
                serializer.Serialize(writer, value.Description);
                return;
            }
            throw new Exception("Cannot marshal type DescriptionUnion");
        }

        public static readonly DescriptionUnionConverter Singleton = new DescriptionUnionConverter();
    }

    internal class VariableTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VariableType) || t == typeof(VariableType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "any":
                    return VariableType.Any;
                case "boolean":
                    return VariableType.Boolean;
                case "number":
                    return VariableType.Number;
                case "string":
                    return VariableType.String;
            }
            throw new Exception("Cannot unmarshal type VariableType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (VariableType)untypedValue;
            switch (value)
            {
                case VariableType.Any:
                    serializer.Serialize(writer, "any");
                    return;
                case VariableType.Boolean:
                    serializer.Serialize(writer, "boolean");
                    return;
                case VariableType.Number:
                    serializer.Serialize(writer, "number");
                    return;
                case VariableType.String:
                    serializer.Serialize(writer, "string");
                    return;
            }
            throw new Exception("Cannot marshal type VariableType");
        }

        public static readonly VariableTypeConverter Singleton = new VariableTypeConverter();
    }

    internal class CollectionVersionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CollectionVersion) || t == typeof(CollectionVersion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new CollectionVersion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<CollectionVersionClass>(reader);
                    return new CollectionVersion { CollectionVersionClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type CollectionVersion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (CollectionVersion)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.CollectionVersionClass != null)
            {
                serializer.Serialize(writer, value.CollectionVersionClass);
                return;
            }
            throw new Exception("Cannot marshal type CollectionVersion");
        }

        public static readonly CollectionVersionConverter Singleton = new CollectionVersionConverter();
    }

    internal class MinMaxLengthCheckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(string);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<string>(reader);
            if (value.Length <= 10)
            {
                return value;
            }
            throw new Exception("Cannot unmarshal type string");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (string)untypedValue;
            if (value.Length <= 10)
            {
                serializer.Serialize(writer, value);
                return;
            }
            throw new Exception("Cannot marshal type string");
        }

        public static readonly MinMaxLengthCheckConverter Singleton = new MinMaxLengthCheckConverter();
    }

    internal class RequestUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RequestUnion) || t == typeof(RequestUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new RequestUnion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<RequestClass>(reader);
                    return new RequestUnion { RequestClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type RequestUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (RequestUnion)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.RequestClass != null)
            {
                serializer.Serialize(writer, value.RequestClass);
                return;
            }
            throw new Exception("Cannot marshal type RequestUnion");
        }

        public static readonly RequestUnionConverter Singleton = new RequestUnionConverter();
    }

    internal class SrcConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Src) || t == typeof(Src?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new Src { };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Src { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<object>>(reader);
                    return new Src { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Src");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Src)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.AnythingArray != null)
            {
                serializer.Serialize(writer, value.AnythingArray);
                return;
            }
            throw new Exception("Cannot marshal type Src");
        }

        public static readonly SrcConverter Singleton = new SrcConverter();
    }

    internal class FormParameterTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FormParameterType) || t == typeof(FormParameterType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "file":
                    return FormParameterType.File;
                case "text":
                    return FormParameterType.Text;
            }
            throw new Exception("Cannot unmarshal type FormParameterType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FormParameterType)untypedValue;
            switch (value)
            {
                case FormParameterType.File:
                    serializer.Serialize(writer, "file");
                    return;
                case FormParameterType.Text:
                    serializer.Serialize(writer, "text");
                    return;
            }
            throw new Exception("Cannot marshal type FormParameterType");
        }

        public static readonly FormParameterTypeConverter Singleton = new FormParameterTypeConverter();
    }

    internal class ModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Mode) || t == typeof(Mode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "file":
                    return Mode.File;
                case "formdata":
                    return Mode.Formdata;
                case "graphql":
                    return Mode.Graphql;
                case "raw":
                    return Mode.Raw;
                case "urlencoded":
                    return Mode.Urlencoded;
            }
            throw new Exception("Cannot unmarshal type Mode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Mode)untypedValue;
            switch (value)
            {
                case Mode.File:
                    serializer.Serialize(writer, "file");
                    return;
                case Mode.Formdata:
                    serializer.Serialize(writer, "formdata");
                    return;
                case Mode.Graphql:
                    serializer.Serialize(writer, "graphql");
                    return;
                case Mode.Raw:
                    serializer.Serialize(writer, "raw");
                    return;
                case Mode.Urlencoded:
                    serializer.Serialize(writer, "urlencoded");
                    return;
            }
            throw new Exception("Cannot marshal type Mode");
        }

        public static readonly ModeConverter Singleton = new ModeConverter();
    }

    internal class HeaderUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(HeaderUnion) || t == typeof(HeaderUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new HeaderUnion { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<Header>>(reader);
                    return new HeaderUnion { HeaderArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type HeaderUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (HeaderUnion)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.HeaderArray != null)
            {
                serializer.Serialize(writer, value.HeaderArray);
                return;
            }
            throw new Exception("Cannot marshal type HeaderUnion");
        }

        public static readonly HeaderUnionConverter Singleton = new HeaderUnionConverter();
    }

    internal class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Response) || t == typeof(Response?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new Response { };
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Response { Integer = integerValue };
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new Response { Double = doubleValue };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new Response { Bool = boolValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Response { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<ResponseClass>(reader);
                    return new Response { ResponseClass = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<object>>(reader);
                    return new Response { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Response");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Response)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.Bool != null)
            {
                serializer.Serialize(writer, value.Bool.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.AnythingArray != null)
            {
                serializer.Serialize(writer, value.AnythingArray);
                return;
            }
            if (value.ResponseClass != null)
            {
                serializer.Serialize(writer, value.ResponseClass);
                return;
            }
            throw new Exception("Cannot marshal type Response");
        }

        public static readonly ResponseConverter Singleton = new ResponseConverter();
    }

    internal class ExpiresConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Expires) || t == typeof(Expires?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new Expires { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Expires { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type Expires");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Expires)untypedValue;
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type Expires");
        }

        public static readonly ExpiresConverter Singleton = new ExpiresConverter();
    }

    internal class HeadersConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Headers) || t == typeof(Headers?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new Headers { };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Headers { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<HeaderElement>>(reader);
                    return new Headers { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Headers");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Headers)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.AnythingArray != null)
            {
                serializer.Serialize(writer, value.AnythingArray);
                return;
            }
            throw new Exception("Cannot marshal type Headers");
        }

        public static readonly HeadersConverter Singleton = new HeadersConverter();
    }

    internal class HeaderElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(HeaderElement) || t == typeof(HeaderElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new HeaderElement { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<Header>(reader);
                    return new HeaderElement { Header = objectValue };
            }
            throw new Exception("Cannot unmarshal type HeaderElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (HeaderElement)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.Header != null)
            {
                serializer.Serialize(writer, value.Header);
                return;
            }
            throw new Exception("Cannot marshal type HeaderElement");
        }

        public static readonly HeaderElementConverter Singleton = new HeaderElementConverter();
    }

    internal class ResponseTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ResponseTime) || t == typeof(ResponseTime?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new ResponseTime { };
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new ResponseTime { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new ResponseTime { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type ResponseTime");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ResponseTime)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type ResponseTime");
        }

        public static readonly ResponseTimeConverter Singleton = new ResponseTimeConverter();
    }
}

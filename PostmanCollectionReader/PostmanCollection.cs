// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo
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
        public PostmanAuth Auth { get; set; }

        [JsonProperty("event", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanEvent> Event { get; set; }

        [JsonProperty("info", Required = Required.Always)]
        public PostmanInformation Info { get; set; }

        /// <summary>
        /// Items are the basic unit for a Postman collection. You can think of them as corresponding
        /// to a single API endpoint. Each Item has one request and may have multiple API responses
        /// associated with it.
        /// </summary>
        [JsonProperty("item", Required = Required.Always)]
        public List<PostmanItems> Item { get; set; }

        [JsonProperty("protocolProfileBehavior", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> ProtocolProfileBehavior { get; set; }

        [JsonProperty("variable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanVariable> Variable { get; set; }
    }

    /// <summary>
    /// Represents authentication helpers provided by Postman
    /// </summary>
    public class PostmanAuth
    {
        /// <summary>
        /// The attributes for API Key Authentication.
        /// </summary>
        [JsonProperty("apikey", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Apikey { get; set; }

        /// <summary>
        /// The attributes for [AWS
        /// Auth](http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html).
        /// </summary>
        [JsonProperty("awsv4", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Awsv4 { get; set; }

        /// <summary>
        /// The attributes for [Basic
        /// Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication).
        /// </summary>
        [JsonProperty("basic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Basic { get; set; }

        /// <summary>
        /// The helper attributes for [Bearer Token
        /// Authentication](https://tools.ietf.org/html/rfc6750)
        /// </summary>
        [JsonProperty("bearer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Bearer { get; set; }

        /// <summary>
        /// The attributes for [Digest
        /// Authentication](https://en.wikipedia.org/wiki/Digest_access_authentication).
        /// </summary>
        [JsonProperty("digest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Digest { get; set; }

        /// <summary>
        /// The attributes for [Akamai EdgeGrid
        /// Authentication](https://developer.akamai.com/legacy/introduction/Client_Auth.html).
        /// </summary>
        [JsonProperty("edgegrid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Edgegrid { get; set; }

        /// <summary>
        /// The attributes for [Hawk Authentication](https://github.com/hueniverse/hawk)
        /// </summary>
        [JsonProperty("hawk", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Hawk { get; set; }

        [JsonProperty("noauth")]
        public object Noauth { get; set; }

        /// <summary>
        /// The attributes for [NTLM
        /// Authentication](https://msdn.microsoft.com/en-us/library/cc237488.aspx)
        /// </summary>
        [JsonProperty("ntlm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Ntlm { get; set; }

        /// <summary>
        /// The attributes for [OAuth2](https://oauth.net/1/)
        /// </summary>
        [JsonProperty("oauth1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Oauth1 { get; set; }

        /// <summary>
        /// Helper attributes for [OAuth2](https://oauth.net/2/)
        /// </summary>
        [JsonProperty("oauth2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanApikeyElement> Oauth2 { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public PostmanAuthType Type { get; set; }
    }

    /// <summary>
    /// Represents an attribute for any authorization method provided by Postman. For example
    /// `username` and `password` are set as auth attributes for Basic Authentication method.
    /// </summary>
    public class PostmanApikeyElement
    {
        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
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
    public class PostmanEvent
    {
        /// <summary>
        /// Indicates whether the event is disabled. If absent, the event is assumed to be enabled.
        /// </summary>
        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// A unique identifier for the enclosing event.
        /// </summary>
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Can be set to `test` or `prerequest` for test scripts or pre-request scripts respectively.
        /// </summary>
        [JsonProperty("listen", Required = Required.Always)]
        public string Listen { get; set; }

        [JsonProperty("script", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanScript Script { get; set; }
    }

    /// <summary>
    /// A script is a snippet of Javascript code that can be used to to perform setup or teardown
    /// operations on a particular response.
    /// </summary>
    public class PostmanScript
    {
        [JsonProperty("exec", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanHost? Exec { get; set; }

        /// <summary>
        /// A unique, user defined identifier that can  be used to refer to this script from requests.
        /// </summary>
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Script name
        /// </summary>
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("src", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanUrl? Src { get; set; }

        /// <summary>
        /// Type of the script. E.g: 'text/javascript'
        /// </summary>
        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public class PostmanUrlClass
    {
        /// <summary>
        /// Contains the URL fragment (if any). Usually this is not transmitted over the network, but
        /// it could be useful to store this in some cases.
        /// </summary>
        [JsonProperty("hash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        /// <summary>
        /// The host for the URL, E.g: api.yourdomain.com. Can be stored as a string or as an array
        /// of strings.
        /// </summary>
        [JsonProperty("host", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanHost? Host { get; set; }

        [JsonProperty("path", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanUrlPath? Path { get; set; }

        /// <summary>
        /// The port number present in this URL. An empty value implies 80/443 depending on whether
        /// the protocol field contains http/https.
        /// </summary>
        [JsonProperty("port", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Port { get; set; }

        /// <summary>
        /// The protocol associated with the request, E.g: 'http'
        /// </summary>
        [JsonProperty("protocol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Protocol { get; set; }

        /// <summary>
        /// An array of QueryParams, which is basically the query string part of the URL, parsed into
        /// separate variables
        /// </summary>
        [JsonProperty("query", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanQueryParam> Query { get; set; }

        /// <summary>
        /// The string representation of the request URL, including the protocol, host, path, hash,
        /// query parameter(s) and path variable(s).
        /// </summary>
        [JsonProperty("raw", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Raw { get; set; }

        /// <summary>
        /// Postman supports path variables with the syntax `/path/:variableName/to/somewhere`. These
        /// variables are stored in this field.
        /// </summary>
        [JsonProperty("variable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanVariable> Variable { get; set; }
    }

    public class PostmanPathClass
    {
        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public class PostmanQueryParam
    {
        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        /// <summary>
        /// If set to true, the current query parameter will not be sent with the request.
        /// </summary>
        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class PostmanDescription
    {
        /// <summary>
        /// The content of the description goes here, as a raw string.
        /// </summary>
        [JsonProperty("content", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        /// <summary>
        /// Holds the mime type of the raw description content. E.g: 'text/markdown' or 'text/html'.
        /// The type is used to correctly render the description when generating documentation, or in
        /// the Postman app.
        /// </summary>
        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
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
    public class PostmanVariable
    {
        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// A variable ID is a unique user-defined value that identifies the variable within a
        /// collection. In traditional terms, this would be a variable name.
        /// </summary>
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// A variable key is a human friendly value that identifies the variable within a
        /// collection. In traditional terms, this would be a variable name.
        /// </summary>
        [JsonProperty("key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        /// <summary>
        /// Variable name
        /// </summary>
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// When set to true, indicates that this variable has been set by Postman
        /// </summary>
        [JsonProperty("system", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? System { get; set; }

        /// <summary>
        /// A variable may have multiple types. This field specifies the type of the variable.
        /// </summary>
        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanVariableType? Type { get; set; }

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
    public class PostmanInformation
    {
        /// <summary>
        /// Every collection is identified by the unique value of this field. The value of this field
        /// is usually easiest to generate using a UID generator function. If you already have a
        /// collection, it is recommended that you maintain the same id since changing the id usually
        /// implies that is a different collection than it was originally.
        /// *Note: This field exists for compatibility reasons with Collection Format V1.*
        /// </summary>
        [JsonProperty("_postman_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PostmanId { get; set; }

        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        /// <summary>
        /// A collection's friendly name is defined by this field. You would want to set this field
        /// to a value that would allow you to easily identify this collection among a bunch of other
        /// collections, as such outlining its usage or content.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// This should ideally hold a link to the Postman schema that is used to validate this
        /// collection. E.g: https://schema.getpostman.com/collection/v1
        /// </summary>
        [JsonProperty("schema", Required = Required.Always)]
        public string Schema { get; set; }

        [JsonProperty("version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanCollectionVersion? Version { get; set; }
    }

    public class PostmanCollectionVersionClass
    {
        /// <summary>
        /// A human friendly identifier to make sense of the version numbers. E.g: 'beta-3'
        /// </summary>
        [JsonProperty("identifier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PostmanMinMaxLengthCheckConverter))]
        public string Identifier { get; set; }

        /// <summary>
        /// Increment this number if you make changes to the collection that changes its behaviour.
        /// E.g: Removing or adding new test scripts. (partly or completely).
        /// </summary>
        [JsonProperty("major", Required = Required.Always)]
        public long Major { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        /// <summary>
        /// You should increment this number if you make changes that will not break anything that
        /// uses the collection. E.g: removing a folder.
        /// </summary>
        [JsonProperty("minor", Required = Required.Always)]
        public long Minor { get; set; }

        /// <summary>
        /// Ideally, minor changes to a collection should result in the increment of this number.
        /// </summary>
        [JsonProperty("patch", Required = Required.Always)]
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
    public class PostmanItems
    {
        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        [JsonProperty("event", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanEvent> Event { get; set; }

        /// <summary>
        /// A unique ID that is used to identify collections internally
        /// </summary>
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// A human readable identifier for the current item.
        ///
        /// A folder's friendly name is defined by this field. You would want to set this field to a
        /// value that would allow you to easily identify this folder.
        /// </summary>
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("protocolProfileBehavior", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> ProtocolProfileBehavior { get; set; }

        [JsonProperty("request", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanRequestUnion? Request { get; set; }

        [JsonProperty("response", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanResponse> Response { get; set; }

        [JsonProperty("variable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanVariable> Variable { get; set; }

        [JsonProperty("auth")]
        public PostmanAuth Auth { get; set; }

        /// <summary>
        /// Items are entities which contain an actual HTTP request, and sample responses attached to
        /// it. Folders may contain many items.
        /// </summary>
        [JsonProperty("item", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanItems> Item { get; set; }
    }

    public class PostmanRequestClass
    {
        [JsonProperty("auth")]
        public PostmanAuth Auth { get; set; }

        [JsonProperty("body")]
        public PostmanBody Body { get; set; }

        [JsonProperty("certificate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanCertificate Certificate { get; set; }

        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        [JsonProperty("header", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanHeaderUnion? Header { get; set; }

        [JsonProperty("method", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty("proxy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanProxyConfig Proxy { get; set; }

        [JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanUrl? Url { get; set; }
    }

    /// <summary>
    /// This field contains the data usually contained in the request body.
    /// </summary>
    public class PostmanBody
    {
        /// <summary>
        /// When set to true, prevents request body from being sent.
        /// </summary>
        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("file", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanFile File { get; set; }

        [JsonProperty("formdata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanFormParameter> Formdata { get; set; }

        [JsonProperty("graphql", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Graphql { get; set; }

        /// <summary>
        /// Postman stores the type of data associated with this request in this field.
        /// </summary>
        [JsonProperty("mode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanMode? Mode { get; set; }

        /// <summary>
        /// Additional configurations and options set for various body modes.
        /// </summary>
        [JsonProperty("options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Options { get; set; }

        [JsonProperty("raw", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Raw { get; set; }

        [JsonProperty("urlencoded", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanUrlEncodedParameter> Urlencoded { get; set; }
    }
    public class PostmanFile
    {
        [JsonProperty("content", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }
    }

    public class PostmanFormParameter
    {
        /// <summary>
        /// Override Content-Type header of this form data entity.
        /// </summary>
        [JsonProperty("contentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType { get; set; }

        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        /// <summary>
        /// When set to true, prevents this form data entity from being sent.
        /// </summary>
        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("src")]
        public PostmanSrc? Src { get; set; }
    }

    public class PostmanUrlEncodedParameter
    {
        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }

        [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    /// <summary>
    /// A representation of an ssl certificate
    /// </summary>
    public class PostmanCertificate
    {
        /// <summary>
        /// An object containing path to file certificate, on the file system
        /// </summary>
        [JsonProperty("cert", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanCert Cert { get; set; }

        /// <summary>
        /// An object containing path to file containing private key, on the file system
        /// </summary>
        [JsonProperty("key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanKey Key { get; set; }

        /// <summary>
        /// A list of Url match pattern strings, to identify Urls this certificate can be used for.
        /// </summary>
        [JsonProperty("matches", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Matches { get; set; }

        /// <summary>
        /// A name for the certificate for user reference
        /// </summary>
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The passphrase for the certificate
        /// </summary>
        [JsonProperty("passphrase", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Passphrase { get; set; }
    }

    /// <summary>
    /// An object containing path to file certificate, on the file system
    /// </summary>
    public class PostmanCert
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
    public class PostmanKey
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
    public class PostmanHeader
    {
        [JsonProperty("description")]
        public PostmanDescriptionUnion? Description { get; set; }

        /// <summary>
        /// If set to true, the current header will not be sent with requests.
        /// </summary>
        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// This holds the LHS of the HTTP Header, e.g ``Content-Type`` or ``X-Custom-Header``
        /// </summary>
        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }

        /// <summary>
        /// The value (or the RHS) of the Header is stored in this field.
        /// </summary>
        [JsonProperty("value", Required = Required.Always)]
        public string Value { get; set; }
    }

    /// <summary>
    /// Using the Proxy, you can configure your custom proxy into the postman for particular url
    /// match
    /// </summary>
    public class PostmanProxyConfig
    {
        /// <summary>
        /// When set to true, ignores this proxy configuration entity
        /// </summary>
        [JsonProperty("disabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The proxy server host
        /// </summary>
        [JsonProperty("host", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Host { get; set; }

        /// <summary>
        /// The Url match for which the proxy config is defined
        /// </summary>
        [JsonProperty("match", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Match { get; set; }

        /// <summary>
        /// The proxy server port
        /// </summary>
        [JsonProperty("port", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Port { get; set; }

        /// <summary>
        /// The tunneling details for the proxy config
        /// </summary>
        [JsonProperty("tunnel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Tunnel { get; set; }
    }

    public class PostmanResponseClass
    {
        /// <summary>
        /// The raw text of the response.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// The numerical response code, example: 200, 201, 404, etc.
        /// </summary>
        [JsonProperty("code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Code { get; set; }

        [JsonProperty("cookie", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<PostmanCookie> Cookie { get; set; }

        [JsonProperty("header")]
        public PostmanHeaders? Header { get; set; }

        /// <summary>
        /// A unique, user defined identifier that can  be used to refer to this response from
        /// requests.
        /// </summary>
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("originalRequest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PostmanRequestUnion? OriginalRequest { get; set; }

        /// <summary>
        /// The time taken by the request to complete. If a number, the unit is milliseconds. If the
        /// response is manually created, this can be set to `null`.
        /// </summary>
        [JsonProperty("responseTime")]
        public PostmanResponseTime? ResponseTime { get; set; }

        /// <summary>
        /// The response status, e.g: '200 OK'
        /// </summary>
        [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
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
    public class PostmanCookie
    {
        /// <summary>
        /// The domain for which this cookie is valid.
        /// </summary>
        [JsonProperty("domain", Required = Required.Always)]
        public string Domain { get; set; }

        /// <summary>
        /// When the cookie expires.
        /// </summary>
        [JsonProperty("expires")]
        public string Expires { get; set; }

        /// <summary>
        /// Custom attributes for a cookie go here, such as the [Priority
        /// Field](https://code.google.com/p/chromium/issues/detail?id=232693)
        /// </summary>
        [JsonProperty("extensions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Extensions { get; set; }

        /// <summary>
        /// True if the cookie is a host-only cookie. (i.e. a request's URL domain must exactly match
        /// the domain of the cookie).
        /// </summary>
        [JsonProperty("hostOnly", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HostOnly { get; set; }

        /// <summary>
        /// Indicates if this cookie is HTTP Only. (if True, the cookie is inaccessible to
        /// client-side scripts)
        /// </summary>
        [JsonProperty("httpOnly", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HttpOnly { get; set; }

        [JsonProperty("maxAge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string MaxAge { get; set; }

        /// <summary>
        /// This is the name of the Cookie.
        /// </summary>
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The path associated with the Cookie.
        /// </summary>
        [JsonProperty("path", Required = Required.Always)]
        public string Path { get; set; }

        /// <summary>
        /// Indicates if the 'secure' flag is set on the Cookie, meaning that it is transmitted over
        /// secure connections only. (typically HTTPS)
        /// </summary>
        [JsonProperty("secure", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Secure { get; set; }

        /// <summary>
        /// True if the cookie is a session cookie.
        /// </summary>
        [JsonProperty("session", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Session { get; set; }

        /// <summary>
        /// The value of the Cookie.
        /// </summary>
        [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public enum PostmanAuthType { Apikey, Awsv4, Basic, Bearer, Digest, Edgegrid, Hawk, Noauth, Ntlm, Oauth1, Oauth2 }

    /// <summary>
    /// A variable may have multiple types. This field specifies the type of the variable.
    /// </summary>
    public enum PostmanVariableType { Any, Boolean, Number, String }

    /// <summary>
    /// Postman stores the type of data associated with this request in this field.
    /// </summary>
    public enum PostmanMode { File, Formdata, Graphql, Raw, Urlencoded }

    /// <summary>
    /// The host for the URL, E.g: api.yourdomain.com. Can be stored as a string or as an array
    /// of strings.
    /// </summary>
    public struct PostmanHost
    {
        public string String;
        public List<string> StringArray;

        public static implicit operator PostmanHost(string String) => new PostmanHost { String = String };
        public static implicit operator PostmanHost(List<string> StringArray) => new PostmanHost { StringArray = StringArray };
    }

    /// <summary>
    /// The complete path of the current url, broken down into segments. A segment could be a
    /// string, or a path variable.
    /// </summary>
    public struct PostmanPathElement
    {
        public PostmanPathClass PathClass;
        public string String;

        public static implicit operator PostmanPathElement(PostmanPathClass PathClass) => new PostmanPathElement { PathClass = PathClass };
        public static implicit operator PostmanPathElement(string String) => new PostmanPathElement { String = String };
    }

    public struct PostmanUrlPath
    {
        public List<PostmanPathElement> AnythingArray;
        public string String;

        public static implicit operator PostmanUrlPath(List<PostmanPathElement> AnythingArray) => new PostmanUrlPath { AnythingArray = AnythingArray };
        public static implicit operator PostmanUrlPath(string String) => new PostmanUrlPath { String = String };
    }

    /// <summary>
    /// A Description can be a raw text, or be an object, which holds the description along with
    /// its format.
    /// </summary>
    public struct PostmanDescriptionUnion
    {
        public PostmanDescription Description;
        public string String;

        public static implicit operator PostmanDescriptionUnion(PostmanDescription Description) => new PostmanDescriptionUnion { Description = Description };
        public static implicit operator PostmanDescriptionUnion(string String) => new PostmanDescriptionUnion { String = String };
        public bool IsNull => Description == null && String == null;
    }

    /// <summary>
    /// If object, contains the complete broken-down URL for this request. If string, contains
    /// the literal request URL.
    /// </summary>
    public struct PostmanUrl
    {
        public string String;
        public PostmanUrlClass UrlClass;

        public static implicit operator PostmanUrl(string String) => new PostmanUrl { String = String };
        public static implicit operator PostmanUrl(PostmanUrlClass UrlClass) => new PostmanUrl { UrlClass = UrlClass };
    }

    /// <summary>
    /// Postman allows you to version your collections as they grow, and this field holds the
    /// version number. While optional, it is recommended that you use this field to its fullest
    /// extent!
    /// </summary>
    public struct PostmanCollectionVersion
    {
        public PostmanCollectionVersionClass CollectionVersionClass;
        public string String;

        public static implicit operator PostmanCollectionVersion(PostmanCollectionVersionClass CollectionVersionClass) => new PostmanCollectionVersion { CollectionVersionClass = CollectionVersionClass };
        public static implicit operator PostmanCollectionVersion(string String) => new PostmanCollectionVersion { String = String };
    }

    public struct PostmanSrc
    {
        public List<object> AnythingArray;
        public string String;

        public static implicit operator PostmanSrc(List<object> AnythingArray) => new PostmanSrc { AnythingArray = AnythingArray };
        public static implicit operator PostmanSrc(string String) => new PostmanSrc { String = String };
        public bool IsNull => AnythingArray == null && String == null;
    }

    public struct PostmanHeaderUnion
    {
        public List<PostmanHeader> HeaderArray;
        public string String;

        public static implicit operator PostmanHeaderUnion(List<PostmanHeader> HeaderArray) => new PostmanHeaderUnion { HeaderArray = HeaderArray };
        public static implicit operator PostmanHeaderUnion(string String) => new PostmanHeaderUnion { String = String };
    }

    /// <summary>
    /// A request represents an HTTP request. If a string, the string is assumed to be the
    /// request URL and the method is assumed to be 'GET'.
    /// </summary>
    public struct PostmanRequestUnion
    {
        public PostmanRequestClass RequestClass;
        public string String;

        public static implicit operator PostmanRequestUnion(PostmanRequestClass RequestClass) => new PostmanRequestUnion { RequestClass = RequestClass };
        public static implicit operator PostmanRequestUnion(string String) => new PostmanRequestUnion { String = String };
    }

    /// <summary>
    /// No HTTP request is complete without its headers, and the same is true for a Postman
    /// request. This field is an array containing all the headers.
    /// </summary>
    public struct PostmanHeaderElement
    {
        public PostmanHeader Header;
        public string String;

        public static implicit operator PostmanHeaderElement(PostmanHeader Header) => new PostmanHeaderElement { Header = Header };
        public static implicit operator PostmanHeaderElement(string String) => new PostmanHeaderElement { String = String };
    }

    public struct PostmanHeaders
    {
        public List<PostmanHeaderElement> AnythingArray;
        public string String;

        public static implicit operator PostmanHeaders(List<PostmanHeaderElement> AnythingArray) => new PostmanHeaders { AnythingArray = AnythingArray };
        public static implicit operator PostmanHeaders(string String) => new PostmanHeaders { String = String };
        public bool IsNull => AnythingArray == null && String == null;
    }

    /// <summary>
    /// The time taken by the request to complete. If a number, the unit is milliseconds. If the
    /// response is manually created, this can be set to `null`.
    /// </summary>
    public struct PostmanResponseTime
    {
        public double? Double;
        public string String;

        public static implicit operator PostmanResponseTime(double Double) => new PostmanResponseTime { Double = Double };
        public static implicit operator PostmanResponseTime(string String) => new PostmanResponseTime { String = String };
        public bool IsNull => Double == null && String == null;
    }

    /// <summary>
    /// A response represents an HTTP response.
    /// </summary>
    public struct PostmanResponse
    {
        public List<object> AnythingArray;
        public bool? Bool;
        public double? Double;
        public long? Integer;
        public PostmanResponseClass ResponseClass;
        public string String;

        public static implicit operator PostmanResponse(List<object> AnythingArray) => new PostmanResponse { AnythingArray = AnythingArray };
        public static implicit operator PostmanResponse(bool Bool) => new PostmanResponse { Bool = Bool };
        public static implicit operator PostmanResponse(double Double) => new PostmanResponse { Double = Double };
        public static implicit operator PostmanResponse(long Integer) => new PostmanResponse { Integer = Integer };
        public static implicit operator PostmanResponse(PostmanResponseClass ResponseClass) => new PostmanResponse { ResponseClass = ResponseClass };
        public static implicit operator PostmanResponse(string String) => new PostmanResponse { String = String };
        public bool IsNull => AnythingArray == null && Bool == null && ResponseClass == null && Double == null && Integer == null && String == null;
    }

    public partial class PostmanCollection
    {
        public static PostmanCollection FromJson(string json) => JsonConvert.DeserializeObject<PostmanCollection>(json, PostmanConverter.Settings);
    }


    public static class PostmanSerialize
    {
        public static string ToJson(this PostmanCollection self) => JsonConvert.SerializeObject(self, PostmanConverter.Settings);
    }

    internal static class PostmanConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PostmanAuthTypeConverter.Singleton,
                PostmanHostConverter.Singleton,
                PostmanUrlConverter.Singleton,
                PostmanUrlPathConverter.Singleton,
                PathElementConverter.Singleton,
                PostmanDescriptionUnionConverter.Singleton,
                PostmanVariableTypeConverter.Singleton,
                PostmanCollectionVersionConverter.Singleton,
                PostmanRequestUnionConverter.Singleton,
                PostmanSrcConverter.Singleton,
                PostmanModeConverter.Singleton,
                PostmanHeaderUnionConverter.Singleton,
                PostmanResponseConverter.Singleton,
                PostmanHeadersConverter.Singleton,
                PostmanHeaderElementConverter.Singleton,
                PostmanResponseTimeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PostmanAuthTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanAuthType) || t == typeof(PostmanAuthType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "apikey":
                    return PostmanAuthType.Apikey;
                case "awsv4":
                    return PostmanAuthType.Awsv4;
                case "basic":
                    return PostmanAuthType.Basic;
                case "bearer":
                    return PostmanAuthType.Bearer;
                case "digest":
                    return PostmanAuthType.Digest;
                case "edgegrid":
                    return PostmanAuthType.Edgegrid;
                case "hawk":
                    return PostmanAuthType.Hawk;
                case "noauth":
                    return PostmanAuthType.Noauth;
                case "ntlm":
                    return PostmanAuthType.Ntlm;
                case "oauth1":
                    return PostmanAuthType.Oauth1;
                case "oauth2":
                    return PostmanAuthType.Oauth2;
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
            var value = (PostmanAuthType)untypedValue;
            switch (value)
            {
                case PostmanAuthType.Apikey:
                    serializer.Serialize(writer, "apikey");
                    return;
                case PostmanAuthType.Awsv4:
                    serializer.Serialize(writer, "awsv4");
                    return;
                case PostmanAuthType.Basic:
                    serializer.Serialize(writer, "basic");
                    return;
                case PostmanAuthType.Bearer:
                    serializer.Serialize(writer, "bearer");
                    return;
                case PostmanAuthType.Digest:
                    serializer.Serialize(writer, "digest");
                    return;
                case PostmanAuthType.Edgegrid:
                    serializer.Serialize(writer, "edgegrid");
                    return;
                case PostmanAuthType.Hawk:
                    serializer.Serialize(writer, "hawk");
                    return;
                case PostmanAuthType.Noauth:
                    serializer.Serialize(writer, "noauth");
                    return;
                case PostmanAuthType.Ntlm:
                    serializer.Serialize(writer, "ntlm");
                    return;
                case PostmanAuthType.Oauth1:
                    serializer.Serialize(writer, "oauth1");
                    return;
                case PostmanAuthType.Oauth2:
                    serializer.Serialize(writer, "oauth2");
                    return;
            }
            throw new Exception("Cannot marshal type AuthType");
        }

        public static readonly PostmanAuthTypeConverter Singleton = new PostmanAuthTypeConverter();
    }

    internal class PostmanHostConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanHost) || t == typeof(PostmanHost?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanHost { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<string>>(reader);
                    return new PostmanHost { StringArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Host");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanHost)untypedValue;
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

        public static readonly PostmanHostConverter Singleton = new PostmanHostConverter();
    }

    internal class PostmanUrlConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanUrl) || t == typeof(PostmanUrl?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanUrl { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PostmanUrlClass>(reader);
                    return new PostmanUrl { UrlClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type Url");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanUrl)untypedValue;
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

        public static readonly PostmanUrlConverter Singleton = new PostmanUrlConverter();
    }

    internal class PostmanUrlPathConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanUrlPath) || t == typeof(PostmanUrlPath?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanUrlPath { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<PostmanPathElement>>(reader);
                    return new PostmanUrlPath { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type UrlPath");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanUrlPath)untypedValue;
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

        public static readonly PostmanUrlPathConverter Singleton = new PostmanUrlPathConverter();
    }

    internal class PathElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanPathElement) || t == typeof(PostmanPathElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanPathElement { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PostmanPathClass>(reader);
                    return new PostmanPathElement { PathClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type PathElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanPathElement)untypedValue;
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

    internal class PostmanDescriptionUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanDescriptionUnion) || t == typeof(PostmanDescriptionUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new PostmanDescriptionUnion();
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanDescriptionUnion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PostmanDescription>(reader);
                    return new PostmanDescriptionUnion { Description = objectValue };
            }
            throw new Exception("Cannot unmarshal type DescriptionUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanDescriptionUnion)untypedValue;
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

        public static readonly PostmanDescriptionUnionConverter Singleton = new PostmanDescriptionUnionConverter();
    }

    internal class PostmanVariableTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanVariableType) || t == typeof(PostmanVariableType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "any":
                    return PostmanVariableType.Any;
                case "boolean":
                    return PostmanVariableType.Boolean;
                case "number":
                    return PostmanVariableType.Number;
                case "string":
                    return PostmanVariableType.String;
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
            var value = (PostmanVariableType)untypedValue;
            switch (value)
            {
                case PostmanVariableType.Any:
                    serializer.Serialize(writer, "any");
                    return;
                case PostmanVariableType.Boolean:
                    serializer.Serialize(writer, "boolean");
                    return;
                case PostmanVariableType.Number:
                    serializer.Serialize(writer, "number");
                    return;
                case PostmanVariableType.String:
                    serializer.Serialize(writer, "string");
                    return;
            }
            throw new Exception("Cannot marshal type VariableType");
        }

        public static readonly PostmanVariableTypeConverter Singleton = new PostmanVariableTypeConverter();
    }

    internal class PostmanCollectionVersionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanCollectionVersion) || t == typeof(PostmanCollectionVersion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanCollectionVersion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PostmanCollectionVersionClass>(reader);
                    return new PostmanCollectionVersion { CollectionVersionClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type CollectionVersion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanCollectionVersion)untypedValue;
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

        public static readonly PostmanCollectionVersionConverter Singleton = new PostmanCollectionVersionConverter();
    }

    internal class PostmanMinMaxLengthCheckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(string);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<string>(reader);
            if (value != null && value.Length <= 10)
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

        public static readonly PostmanMinMaxLengthCheckConverter Singleton = new PostmanMinMaxLengthCheckConverter();
    }

    internal class PostmanRequestUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanRequestUnion) || t == typeof(PostmanRequestUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanRequestUnion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PostmanRequestClass>(reader);
                    return new PostmanRequestUnion { RequestClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type RequestUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanRequestUnion)untypedValue;
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

        public static readonly PostmanRequestUnionConverter Singleton = new PostmanRequestUnionConverter();
    }

    internal class PostmanSrcConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanSrc) || t == typeof(PostmanSrc?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new PostmanSrc();
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanSrc { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<object>>(reader);
                    return new PostmanSrc { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Src");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanSrc)untypedValue;
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

        public static readonly PostmanSrcConverter Singleton = new PostmanSrcConverter();
    }

    internal class PostmanModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanMode) || t == typeof(PostmanMode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "file":
                    return PostmanMode.File;
                case "formdata":
                    return PostmanMode.Formdata;
                case "graphql":
                    return PostmanMode.Graphql;
                case "raw":
                    return PostmanMode.Raw;
                case "urlencoded":
                    return PostmanMode.Urlencoded;
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
            var value = (PostmanMode)untypedValue;
            switch (value)
            {
                case PostmanMode.File:
                    serializer.Serialize(writer, "file");
                    return;
                case PostmanMode.Formdata:
                    serializer.Serialize(writer, "formdata");
                    return;
                case PostmanMode.Graphql:
                    serializer.Serialize(writer, "graphql");
                    return;
                case PostmanMode.Raw:
                    serializer.Serialize(writer, "raw");
                    return;
                case PostmanMode.Urlencoded:
                    serializer.Serialize(writer, "urlencoded");
                    return;
            }
            throw new Exception("Cannot marshal type Mode");
        }

        public static readonly PostmanModeConverter Singleton = new PostmanModeConverter();
    }

    internal class PostmanHeaderUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanHeaderUnion) || t == typeof(PostmanHeaderUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanHeaderUnion { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<PostmanHeader>>(reader);
                    return new PostmanHeaderUnion { HeaderArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type HeaderUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanHeaderUnion)untypedValue;
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

        public static readonly PostmanHeaderUnionConverter Singleton = new PostmanHeaderUnionConverter();
    }

    internal class PostmanResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanResponse) || t == typeof(PostmanResponse?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new PostmanResponse();
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new PostmanResponse { Integer = integerValue };
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new PostmanResponse { Double = doubleValue };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new PostmanResponse { Bool = boolValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanResponse { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PostmanResponseClass>(reader);
                    return new PostmanResponse { ResponseClass = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<object>>(reader);
                    return new PostmanResponse { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Response");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanResponse)untypedValue;
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

        public static readonly PostmanResponseConverter Singleton = new PostmanResponseConverter();
    }

    internal class PostmanHeadersConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanHeaders) || t == typeof(PostmanHeaders?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new PostmanHeaders();
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanHeaders { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<PostmanHeaderElement>>(reader);
                    return new PostmanHeaders { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Headers");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanHeaders)untypedValue;
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

        public static readonly PostmanHeadersConverter Singleton = new PostmanHeadersConverter();
    }

    internal class PostmanHeaderElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanHeaderElement) || t == typeof(PostmanHeaderElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanHeaderElement { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PostmanHeader>(reader);
                    return new PostmanHeaderElement { Header = objectValue };
            }
            throw new Exception("Cannot unmarshal type HeaderElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanHeaderElement)untypedValue;
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

        public static readonly PostmanHeaderElementConverter Singleton = new PostmanHeaderElementConverter();
    }

    internal class PostmanResponseTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PostmanResponseTime) || t == typeof(PostmanResponseTime?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new PostmanResponseTime();
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new PostmanResponseTime { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new PostmanResponseTime { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type ResponseTime");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PostmanResponseTime)untypedValue;
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

        public static readonly PostmanResponseTimeConverter Singleton = new PostmanResponseTimeConverter();
    }
}

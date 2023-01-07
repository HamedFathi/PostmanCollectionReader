// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedMember.Global

#nullable enable
#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
// ReSharper disable InconsistentNaming

namespace PostmanCollectionReader;
public enum PostmanAuthType { Apikey, Awsv4, Basic, Bearer, Digest, Edgegrid, Hawk, Noauth, Ntlm, Oauth1, Oauth2 }

/// <summary>
/// Postman stores the type of data associated with this request in this field.
/// </summary>
public enum PostmanMode { File, Formdata, Graphql, Raw, Urlencoded }

/// <summary>
/// A variable may have multiple types. This field specifies the type of the variable.
/// </summary>
public enum PostmanVariableType { Any, Boolean, Number, String }

/// <summary>
/// Postman allows you to version your collections as they grow, and this field holds the
/// version number. While optional, it is recommended that you use this field to its fullest
/// extent!
/// </summary>
public struct PostmanCollectionVersion
{
    public PostmanCollectionVersionClass? CollectionVersionClass;
    public string? String;

    public static implicit operator PostmanCollectionVersion(PostmanCollectionVersionClass collectionVersionClass) => new() { CollectionVersionClass = collectionVersionClass };
    public static implicit operator PostmanCollectionVersion(string @string) => new() { String = @string };
}

/// <summary>
/// A Description can be a raw text, or be an object, which holds the description along with
/// its format.
/// </summary>
public struct PostmanDescriptionUnion
{
    public PostmanDescription? Description;
    public string? String;

    public bool IsNull => Description == null && String == null;

    public static implicit operator PostmanDescriptionUnion(PostmanDescription description) => new() { Description = description };
    public static implicit operator PostmanDescriptionUnion(string @string) => new() { String = @string };
}

/// <summary>
/// No HTTP request is complete without its headers, and the same is true for a Postman
/// request. This field is an array containing all the headers.
/// </summary>
public struct PostmanHeaderElement
{
    public PostmanHeader? Header;
    public string? String;

    public static implicit operator PostmanHeaderElement(PostmanHeader header) => new() { Header = header };
    public static implicit operator PostmanHeaderElement(string @string) => new() { String = @string };
}

public struct PostmanHeaders
{
    public List<PostmanHeaderElement>? AnythingArray;
    public string? String;

    public bool IsNull => AnythingArray == null && String == null;

    public static implicit operator PostmanHeaders(List<PostmanHeaderElement> anythingArray) => new() { AnythingArray = anythingArray };
    public static implicit operator PostmanHeaders(string @string) => new() { String = @string };
}

public struct PostmanHeaderUnion
{
    public List<PostmanHeader>? HeaderArray;
    public string? String;

    public static implicit operator PostmanHeaderUnion(List<PostmanHeader> headerArray) => new() { HeaderArray = headerArray };
    public static implicit operator PostmanHeaderUnion(string @string) => new() { String = @string };
}

/// <summary>
/// The host for the URL, E.g: api.yourdomain.com. Can be stored as a string or as an array
/// of strings.
/// </summary>
public struct PostmanHost
{
    public string? String;
    public List<string>? StringArray;

    public static implicit operator PostmanHost(string @string) => new() { String = @string };
    public static implicit operator PostmanHost(List<string> stringArray) => new() { StringArray = stringArray };
}

/// <summary>
/// The complete path of the current url, broken down into segments. A segment could be a
/// string, or a path variable.
/// </summary>
public struct PostmanPathElement
{
    public PostmanPathClass? PathClass;
    public string? String;

    public static implicit operator PostmanPathElement(PostmanPathClass pathClass) => new() { PathClass = pathClass };
    public static implicit operator PostmanPathElement(string @string) => new() { String = @string };
}

/// <summary>
/// A request represents an HTTP request. If a string, the string is assumed to be the
/// request URL and the method is assumed to be 'GET'.
/// </summary>
public struct PostmanRequestUnion
{
    public PostmanRequestClass? RequestClass;
    public string? String;

    public static implicit operator PostmanRequestUnion(PostmanRequestClass requestClass) => new() { RequestClass = requestClass };
    public static implicit operator PostmanRequestUnion(string @string) => new() { String = @string };
}

/// <summary>
/// A response represents an HTTP response.
/// </summary>
public struct PostmanResponse
{
    public List<object>? AnythingArray;
    public bool? Bool;
    public double? Double;
    public long? Integer;
    public PostmanResponseClass? ResponseClass;
    public string? String;

    public bool IsNull => AnythingArray == null && Bool == null && ResponseClass == null && Double == null && Integer == null && String == null;

    public static implicit operator PostmanResponse(List<object> anythingArray) => new() { AnythingArray = anythingArray };
    public static implicit operator PostmanResponse(bool @bool) => new() { Bool = @bool };
    public static implicit operator PostmanResponse(double @double) => new() { Double = @double };
    public static implicit operator PostmanResponse(long integer) => new() { Integer = integer };
    public static implicit operator PostmanResponse(PostmanResponseClass responseClass) => new() { ResponseClass = responseClass };
    public static implicit operator PostmanResponse(string @string) => new() { String = @string };
}

/// <summary>
/// The time taken by the request to complete. If a number, the unit is milliseconds. If the
/// response is manually created, this can be set to `null`.
/// </summary>
public struct PostmanResponseTime
{
    public double? Double;
    public string? String;

    public bool IsNull => Double == null && String == null;

    public static implicit operator PostmanResponseTime(double @double) => new() { Double = @double };
    public static implicit operator PostmanResponseTime(string @string) => new() { String = @string };
}

public struct PostmanSrc
{
    public List<object>? AnythingArray;
    public string? String;

    public bool IsNull => AnythingArray == null && String == null;

    public static implicit operator PostmanSrc(List<object> anythingArray) => new() { AnythingArray = anythingArray };
    public static implicit operator PostmanSrc(string @string) => new() { String = @string };
}

/// <summary>
/// If object, contains the complete broken-down URL for this request. If string, contains
/// the literal request URL.
/// </summary>
public struct PostmanUrl
{
    public string? String;
    public PostmanUrlClass? UrlClass;

    public static implicit operator PostmanUrl(string @string) => new() { String = @string };
    public static implicit operator PostmanUrl(PostmanUrlClass urlClass) => new() { UrlClass = urlClass };
}

public struct PostmanUrlPath
{
    public List<PostmanPathElement>? AnythingArray;
    public string? String;

    public static implicit operator PostmanUrlPath(List<PostmanPathElement> anythingArray) => new() { AnythingArray = anythingArray };
    public static implicit operator PostmanUrlPath(string @string) => new() { String = @string };
}

public static class Serialize
{
    public static string ToJson(this PostmanCollection self) => JsonSerializer.Serialize(self, PostmanConverter.Settings);
}

/// <summary>
/// Represents an attribute for any authorization method provided by Postman. For example
/// `username` and `password` are set as auth attributes for Basic Authentication method.
/// </summary>
public class PostmanApikeyElement
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public object Value { get; set; }
}

/// <summary>
/// Represents authentication helpers provided by Postman
/// </summary>
public class PostmanAuth
{
    /// <summary>
    /// The attributes for API Key Authentication.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("apikey")]
    public List<PostmanApikeyElement> Apikey { get; set; }

    /// <summary>
    /// The attributes for [AWS
    /// Auth](http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("awsv4")]
    public List<PostmanApikeyElement> Awsv4 { get; set; }

    /// <summary>
    /// The attributes for [Basic
    /// Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("basic")]
    public List<PostmanApikeyElement> Basic { get; set; }

    /// <summary>
    /// The helper attributes for [Bearer Token
    /// Authentication](https://tools.ietf.org/html/rfc6750)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("bearer")]
    public List<PostmanApikeyElement> Bearer { get; set; }

    /// <summary>
    /// The attributes for [Digest
    /// Authentication](https://en.wikipedia.org/wiki/Digest_access_authentication).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("digest")]
    public List<PostmanApikeyElement> Digest { get; set; }

    /// <summary>
    /// The attributes for [Akamai EdgeGrid
    /// Authentication](https://developer.akamai.com/legacy/introduction/Client_Auth.html).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("edgegrid")]
    public List<PostmanApikeyElement> Edgegrid { get; set; }

    /// <summary>
    /// The attributes for [Hawk Authentication](https://github.com/hueniverse/hawk)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hawk")]
    public List<PostmanApikeyElement> Hawk { get; set; }

    [JsonPropertyName("noauth")]
    public object Noauth { get; set; }

    /// <summary>
    /// The attributes for [NTLM
    /// Authentication](https://msdn.microsoft.com/en-us/library/cc237488.aspx)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ntlm")]
    public List<PostmanApikeyElement> Ntlm { get; set; }

    /// <summary>
    /// The attributes for [OAuth2](https://oauth.net/1/)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("oauth1")]
    public List<PostmanApikeyElement> Oauth1 { get; set; }

    /// <summary>
    /// Helper attributes for [OAuth2](https://oauth.net/2/)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("oauth2")]
    public List<PostmanApikeyElement> Oauth2 { get; set; }

    [JsonPropertyName("type")]
    public PostmanAuthType Type { get; set; }
}

/// <summary>
/// This field contains the data usually contained in the request body.
/// </summary>
public class PostmanBody
{
    /// <summary>
    /// When set to true, prevents request body from being sent.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("file")]
    public PostmanFile File { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("formdata")]
    public List<PostmanFormParameter> Formdata { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("graphql")]
    public Dictionary<string, object> Graphql { get; set; }

    /// <summary>
    /// Postman stores the type of data associated with this request in this field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("mode")]
    public PostmanMode? Mode { get; set; }

    /// <summary>
    /// Additional configurations and options set for various body modes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("options")]
    public Dictionary<string, object> Options { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("raw")]
    public string Raw { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("urlencoded")]
    public List<PostmanUrlEncodedParameter> Urlencoded { get; set; }
}

/// <summary>
/// An object containing path to file certificate, on the file system
/// </summary>
public class PostmanCert
{
    /// <summary>
    /// The path to file containing key for certificate, on the file system
    /// </summary>
    [JsonPropertyName("src")]
    public object Src { get; set; }
}

/// <summary>
/// A representation of an ssl certificate
/// </summary>
public class PostmanCertificate
{
    /// <summary>
    /// An object containing path to file certificate, on the file system
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cert")]
    public PostmanCert Cert { get; set; }

    /// <summary>
    /// An object containing path to file containing private key, on the file system
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("key")]
    public PostmanKey Key { get; set; }

    /// <summary>
    /// A list of Url match pattern strings, to identify Urls this certificate can be used for.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("matches")]
    public List<string> Matches { get; set; }

    /// <summary>
    /// A name for the certificate for user reference
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The passphrase for the certificate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("passphrase")]
    public string Passphrase { get; set; }
}

public partial class PostmanCollection
{
    [JsonPropertyName("auth")]
    public PostmanAuth Auth { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("event")]
    public List<PostmanEvent> Event { get; set; }

    [JsonPropertyName("info")]
    public PostmanInformation Info { get; set; }

    /// <summary>
    /// Items are the basic unit for a Postman collection. You can think of them as corresponding
    /// to a single API endpoint. Each Item has one request and may have multiple API responses
    /// associated with it.
    /// </summary>
    [JsonPropertyName("item")]
    public List<PostmanItems> Item { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("protocolProfileBehavior")]
    public Dictionary<string, object> ProtocolProfileBehavior { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("variable")]
    public List<PostmanVariable> Variable { get; set; }
}

public partial class PostmanCollection
{
    public static PostmanEnvironment? EnvironmentFromJson(string json) => JsonSerializer.Deserialize<PostmanEnvironment>(json);

    public static PostmanCollection? FromJson(string json) => JsonSerializer.Deserialize<PostmanCollection>(json, PostmanConverter.Settings);
}

public class PostmanCollectionVersionClass
{
    /// <summary>
    /// A human friendly identifier to make sense of the version numbers. E.g: 'beta-3'
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("identifier")]
    [JsonConverter(typeof(PostmanMinMaxLengthCheckConverter))]
    public string Identifier { get; set; }

    /// <summary>
    /// Increment this number if you make changes to the collection that changes its behaviour.
    /// E.g: Removing or adding new test scripts. (partly or completely).
    /// </summary>
    [JsonPropertyName("major")]
    public long Major { get; set; }

    [JsonPropertyName("meta")]
    public object Meta { get; set; }

    /// <summary>
    /// You should increment this number if you make changes that will not break anything that
    /// uses the collection. E.g: removing a folder.
    /// </summary>
    [JsonPropertyName("minor")]
    public long Minor { get; set; }

    /// <summary>
    /// Ideally, minor changes to a collection should result in the increment of this number.
    /// </summary>
    [JsonPropertyName("patch")]
    public long Patch { get; set; }
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
    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    /// <summary>
    /// When the cookie expires.
    /// </summary>
    [JsonPropertyName("expires")]
    public string Expires { get; set; }

    /// <summary>
    /// Custom attributes for a cookie go here, such as the [Priority
    /// Field](https://code.google.com/p/chromium/issues/detail?id=232693)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("extensions")]
    public List<object> Extensions { get; set; }

    /// <summary>
    /// True if the cookie is a host-only cookie. (i.e. a request's URL domain must exactly match
    /// the domain of the cookie).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hostOnly")]
    public bool? HostOnly { get; set; }

    /// <summary>
    /// Indicates if this cookie is HTTP Only. (if True, the cookie is inaccessible to
    /// client-side scripts)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("httpOnly")]
    public bool? HttpOnly { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("maxAge")]
    public string MaxAge { get; set; }

    /// <summary>
    /// This is the name of the Cookie.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The path associated with the Cookie.
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// Indicates if the 'secure' flag is set on the Cookie, meaning that it is transmitted over
    /// secure connections only. (typically HTTPS)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("secure")]
    public bool? Secure { get; set; }

    /// <summary>
    /// True if the cookie is a session cookie.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("session")]
    public bool? Session { get; set; }

    /// <summary>
    /// The value of the Cookie.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class PostmanDateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string _serializationFormat;
    public PostmanDateOnlyConverter() : this(null) { }

    public PostmanDateOnlyConverter(string? serializationFormat)
    {
        this._serializationFormat = serializationFormat ?? "yyyy-MM-dd";
    }

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return DateOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(_serializationFormat));
}

public class PostmanDescription
{
    /// <summary>
    /// The content of the description goes here, as a raw string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    /// Holds the mime type of the raw description content. E.g: 'text/markdown' or 'text/html'.
    /// The type is used to correctly render the description when generating documentation, or in
    /// the Postman app.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Description can have versions associated with it, which should be put in this property.
    /// </summary>
    [JsonPropertyName("version")]
    public object Version { get; set; }
}

public class PostmanEnvironment
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public List<PostmanEnvironmentVariable> Variables { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("_postman_variable_scope")]
    public string PostmanVariableScope { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("_postman_exported_at")]
    public DateTime? PostmanExportedAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("_postman_exported_using")]
    public string PostmanExportedUsing { get; set; }

}

public class PostmanEnvironmentVariable
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public string Value { get; set; }
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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// A unique identifier for the enclosing event.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Can be set to `test` or `prerequest` for test scripts or pre-request scripts respectively.
    /// </summary>
    [JsonPropertyName("listen")]
    public string Listen { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("script")]
    public PostmanScript Script { get; set; }
}

public class PostmanFile
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("src")]
    public string Src { get; set; }
}

public class PostmanFormParameter
{
    /// <summary>
    /// Override Content-Type header of this form data entity.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    /// <summary>
    /// When set to true, prevents this form data entity from being sent.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("src")]
    public PostmanSrc? Src { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

/// <summary>
/// A representation for a list of headers
///
/// Represents a single HTTP Header
/// </summary>
public class PostmanHeader
{
    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    /// <summary>
    /// If set to true, the current header will not be sent with requests.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// This holds the LHS of the HTTP Header, e.g ``Content-Type`` or ``X-Custom-Header``
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The value (or the RHS) of the Header is stored in this field.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

/// <summary>
/// Detailed description of the info block
/// </summary>
public class PostmanInformation
{
    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    /// <summary>
    /// A collection's friendly name is defined by this field. You would want to set this field
    /// to a value that would allow you to easily identify this collection among a bunch of other
    /// collections, as such outlining its usage or content.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Every collection is identified by the unique value of this field. The value of this field
    /// is usually easiest to generate using a UID generator function. If you already have a
    /// collection, it is recommended that you maintain the same id since changing the id usually
    /// implies that is a different collection than it was originally.
    /// *Note: This field exists for compatibility reasons with Collection Format V1.*
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("_postman_id")]
    public string PostmanId { get; set; }
    /// <summary>
    /// This should ideally hold a link to the Postman schema that is used to validate this
    /// collection. E.g: https://schema.getpostman.com/collection/v1
    /// </summary>
    [JsonPropertyName("schema")]
    public string Schema { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("version")]
    public PostmanCollectionVersion? Version { get; set; }
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
    [JsonPropertyName("auth")]
    public PostmanAuth Auth { get; set; }

    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("event")]
    public List<PostmanEvent> Event { get; set; }

    /// <summary>
    /// A unique ID that is used to identify collections internally
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Items are entities which contain an actual HTTP request, and sample responses attached to
    /// it. Folders may contain many items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("item")]
    public List<PostmanItems> Item { get; set; }

    /// <summary>
    /// A human readable identifier for the current item.
    ///
    /// A folder's friendly name is defined by this field. You would want to set this field to a
    /// value that would allow you to easily identify this folder.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("protocolProfileBehavior")]
    public Dictionary<string, object> ProtocolProfileBehavior { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("request")]
    public PostmanRequestUnion? Request { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("response")]
    public List<PostmanResponse> Response { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("variable")]
    public List<PostmanVariable> Variable { get; set; }
}

/// <summary>
/// An object containing path to file containing private key, on the file system
/// </summary>
public class PostmanKey
{
    /// <summary>
    /// The path to file containing key for certificate, on the file system
    /// </summary>
    [JsonPropertyName("src")]
    public object Src { get; set; }
}

public class PostmanPathClass
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// The proxy server host
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("host")]
    public string Host { get; set; }

    /// <summary>
    /// The Url match for which the proxy config is defined
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("match")]
    public string Match { get; set; }

    /// <summary>
    /// The proxy server port
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("port")]
    public long? Port { get; set; }

    /// <summary>
    /// The tunneling details for the proxy config
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tunnel")]
    public bool? Tunnel { get; set; }
}

public class PostmanQueryParam
{
    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    /// <summary>
    /// If set to true, the current query parameter will not be sent with the request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class PostmanRequestClass
{
    [JsonPropertyName("auth")]
    public PostmanAuth Auth { get; set; }

    [JsonPropertyName("body")]
    public PostmanBody Body { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("certificate")]
    public PostmanCertificate Certificate { get; set; }

    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("header")]
    public PostmanHeaderUnion? Header { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("method")]
    public string Method { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("proxy")]
    public PostmanProxyConfig Proxy { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public PostmanUrl? Url { get; set; }
}

public class PostmanResponseClass
{
    /// <summary>
    /// The raw text of the response.
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; set; }

    /// <summary>
    /// The numerical response code, example: 200, 201, 404, etc.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("code")]
    public long? Code { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cookie")]
    public List<PostmanCookie> Cookie { get; set; }

    [JsonPropertyName("header")]
    public PostmanHeaders? Header { get; set; }

    /// <summary>
    /// A unique, user defined identifier that can be used to refer to this response from
    /// requests.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The name of the response.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("originalRequest")]
    public PostmanRequestUnion? OriginalRequest { get; set; }

    /// <summary>
    /// The time taken by the request to complete. If a number, the unit is milliseconds. If the
    /// response is manually created, this can be set to `null`.
    /// </summary>
    [JsonPropertyName("responseTime")]
    public PostmanResponseTime? ResponseTime { get; set; }

    /// <summary>
    /// The response status, e.g: '200 OK'
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Set of timing information related to request and response in milliseconds
    /// </summary>
    [JsonPropertyName("timings")]
    public Dictionary<string, object> Timings { get; set; }
}

/// <summary>
/// A script is a snippet of Javascript code that can be used to to perform setup or teardown
/// operations on a particular response.
/// </summary>
public class PostmanScript
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("exec")]
    public PostmanHost? Exec { get; set; }

    /// <summary>
    /// A unique, user defined identifier that can be used to refer to this script from requests.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Script name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("src")]
    public PostmanUrl? Src { get; set; }

    /// <summary>
    /// Type of the script. E.g: 'text/javascript'
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class PostmanTimeOnlyConverter : JsonConverter<TimeOnly>
{
    private readonly string _serializationFormat;

    public PostmanTimeOnlyConverter() : this(null) { }

    public PostmanTimeOnlyConverter(string? serializationFormat)
    {
        this._serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
    }

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return TimeOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(_serializationFormat));
}

public class PostmanUrlClass
{
    /// <summary>
    /// Contains the URL fragment (if any). Usually this is not transmitted over the network, but
    /// it could be useful to store this in some cases.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hash")]
    public string Hash { get; set; }

    /// <summary>
    /// The host for the URL, E.g: api.yourdomain.com. Can be stored as a string or as an array
    /// of strings.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("host")]
    public PostmanHost? Host { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("path")]
    public PostmanUrlPath? Path { get; set; }

    /// <summary>
    /// The port number present in this URL. An empty value implies 80/443 depending on whether
    /// the protocol field contains http/https.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("port")]
    public string Port { get; set; }

    /// <summary>
    /// The protocol associated with the request, E.g: 'http'
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("protocol")]
    public string Protocol { get; set; }

    /// <summary>
    /// An array of QueryParams, which is basically the query string part of the URL, parsed into
    /// separate variables
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("query")]
    public List<PostmanQueryParam> Query { get; set; }

    /// <summary>
    /// The string representation of the request URL, including the protocol, host, path, hash,
    /// query parameter(s) and path variable(s).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("raw")]
    public string Raw { get; set; }

    /// <summary>
    /// Postman supports path variables with the syntax `/path/:variableName/to/somewhere`. These
    /// variables are stored in this field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("variable")]
    public List<PostmanVariable> Variable { get; set; }
}
public class PostmanUrlEncodedParameter
{
    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public string Value { get; set; }
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
    [JsonPropertyName("description")]
    public PostmanDescriptionUnion? Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// A variable ID is a unique user-defined value that identifies the variable within a
    /// collection. In traditional terms, this would be a variable name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// A variable key is a human friendly value that identifies the variable within a
    /// collection. In traditional terms, this would be a variable name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// Variable name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// When set to true, indicates that this variable has been set by Postman
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("system")]
    public bool? System { get; set; }

    /// <summary>
    /// A variable may have multiple types. This field specifies the type of the variable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public PostmanVariableType? Type { get; set; }

    /// <summary>
    /// The value that a variable holds in this collection. Ultimately, the variables will be
    /// replaced by this value, when say running a set of requests from a collection
    /// </summary>
    [JsonPropertyName("value")]
    public object Value { get; set; }
}
internal static class PostmanConverter
{
    public static readonly JsonSerializerOptions? Settings = new(JsonSerializerDefaults.General)
    {
        Converters =
        {
            PostmanAuthTypeConverter.Singleton,
            PostmanHostConverter.Singleton,
            PostmanUrlConverter.Singleton,
            PostmanUrlPathConverter.Singleton,
            PostmanPathElementConverter.Singleton,
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
            new PostmanDateOnlyConverter(),
            new PostmanTimeOnlyConverter(),
            PostmanIsoDateTimeOffsetConverter.Singleton
        },
    };
}

internal class PostmanAuthTypeConverter : JsonConverter<PostmanAuthType>
{
    public static readonly PostmanAuthTypeConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanAuthType);

    public override PostmanAuthType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
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
        throw new Exception("Cannot unmarshal type PostmanAuthType");
    }

    public override void Write(Utf8JsonWriter writer, PostmanAuthType value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case PostmanAuthType.Apikey:
                JsonSerializer.Serialize(writer, "apikey", options);
                return;
            case PostmanAuthType.Awsv4:
                JsonSerializer.Serialize(writer, "awsv4", options);
                return;
            case PostmanAuthType.Basic:
                JsonSerializer.Serialize(writer, "basic", options);
                return;
            case PostmanAuthType.Bearer:
                JsonSerializer.Serialize(writer, "bearer", options);
                return;
            case PostmanAuthType.Digest:
                JsonSerializer.Serialize(writer, "digest", options);
                return;
            case PostmanAuthType.Edgegrid:
                JsonSerializer.Serialize(writer, "edgegrid", options);
                return;
            case PostmanAuthType.Hawk:
                JsonSerializer.Serialize(writer, "hawk", options);
                return;
            case PostmanAuthType.Noauth:
                JsonSerializer.Serialize(writer, "noauth", options);
                return;
            case PostmanAuthType.Ntlm:
                JsonSerializer.Serialize(writer, "ntlm", options);
                return;
            case PostmanAuthType.Oauth1:
                JsonSerializer.Serialize(writer, "oauth1", options);
                return;
            case PostmanAuthType.Oauth2:
                JsonSerializer.Serialize(writer, "oauth2", options);
                return;
        }
        throw new Exception("Cannot marshal type AuthType");
    }
}

internal class PostmanCollectionVersionConverter : JsonConverter<PostmanCollectionVersion>
{
    public static readonly PostmanCollectionVersionConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanCollectionVersion);

    public override PostmanCollectionVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanCollectionVersion { String = stringValue };
            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<PostmanCollectionVersionClass>(ref reader, options);
                return new PostmanCollectionVersion { CollectionVersionClass = objectValue };
        }
        throw new Exception("Cannot unmarshal type PostmanCollectionVersion");
    }

    public override void Write(Utf8JsonWriter writer, PostmanCollectionVersion value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.CollectionVersionClass != null)
        {
            JsonSerializer.Serialize(writer, value.CollectionVersionClass, options);
            return;
        }
        throw new Exception("Cannot marshal type CollectionVersion");
    }
}

internal class PostmanDescriptionUnionConverter : JsonConverter<PostmanDescriptionUnion>
{
    public static readonly PostmanDescriptionUnionConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanDescriptionUnion);

    public override PostmanDescriptionUnion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return new PostmanDescriptionUnion();
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanDescriptionUnion { String = stringValue };
            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<PostmanDescription>(ref reader, options);
                return new PostmanDescriptionUnion { Description = objectValue };
        }
        throw new Exception("Cannot unmarshal type PostmanDescriptionUnion");
    }

    public override void Write(Utf8JsonWriter writer, PostmanDescriptionUnion value, JsonSerializerOptions options)
    {
        if (value.IsNull)
        {
            writer.WriteNullValue();
            return;
        }
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.Description != null)
        {
            JsonSerializer.Serialize(writer, value.Description, options);
            return;
        }
        throw new Exception("Cannot marshal type DescriptionUnion");
    }
}

internal class PostmanHeaderElementConverter : JsonConverter<PostmanHeaderElement>
{
    public static readonly PostmanHeaderElementConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanHeaderElement);

    public override PostmanHeaderElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanHeaderElement { String = stringValue };
            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<PostmanHeader>(ref reader, options);
                return new PostmanHeaderElement { Header = objectValue };
        }
        throw new Exception("Cannot unmarshal type PostmanHeaderElement");
    }

    public override void Write(Utf8JsonWriter writer, PostmanHeaderElement value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.Header != null)
        {
            JsonSerializer.Serialize(writer, value.Header, options);
            return;
        }
        throw new Exception("Cannot marshal type HeaderElement");
    }
}

internal class PostmanHeadersConverter : JsonConverter<PostmanHeaders>
{
    public static readonly PostmanHeadersConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanHeaders);

    public override PostmanHeaders Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return new PostmanHeaders();
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanHeaders { String = stringValue };
            case JsonTokenType.StartArray:
                var arrayValue = JsonSerializer.Deserialize<List<PostmanHeaderElement>>(ref reader, options);
                return new PostmanHeaders { AnythingArray = arrayValue };
        }
        throw new Exception("Cannot unmarshal type PostmanHeaders");
    }

    public override void Write(Utf8JsonWriter writer, PostmanHeaders value, JsonSerializerOptions options)
    {
        if (value.IsNull)
        {
            writer.WriteNullValue();
            return;
        }
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.AnythingArray != null)
        {
            JsonSerializer.Serialize(writer, value.AnythingArray, options);
            return;
        }
        throw new Exception("Cannot marshal type Headers");
    }
}

internal class PostmanHeaderUnionConverter : JsonConverter<PostmanHeaderUnion>
{
    public static readonly PostmanHeaderUnionConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanHeaderUnion);

    public override PostmanHeaderUnion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanHeaderUnion { String = stringValue };
            case JsonTokenType.StartArray:
                var arrayValue = JsonSerializer.Deserialize<List<PostmanHeader>>(ref reader, options);
                return new PostmanHeaderUnion { HeaderArray = arrayValue };
        }
        throw new Exception("Cannot unmarshal type PostmanHeaderUnion");
    }

    public override void Write(Utf8JsonWriter writer, PostmanHeaderUnion value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.HeaderArray != null)
        {
            JsonSerializer.Serialize(writer, value.HeaderArray, options);
            return;
        }
        throw new Exception("Cannot marshal type HeaderUnion");
    }
}

internal class PostmanHostConverter : JsonConverter<PostmanHost>
{
    public static readonly PostmanHostConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanHost);

    public override PostmanHost Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanHost { String = stringValue };
            case JsonTokenType.StartArray:
                var arrayValue = JsonSerializer.Deserialize<List<string>>(ref reader, options);
                return new PostmanHost { StringArray = arrayValue };
        }
        throw new Exception("Cannot unmarshal type PostmanHost");
    }

    public override void Write(Utf8JsonWriter writer, PostmanHost value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.StringArray != null)
        {
            JsonSerializer.Serialize(writer, value.StringArray, options);
            return;
        }
        throw new Exception("Cannot marshal type Host");
    }
}

internal class PostmanMinMaxLengthCheckConverter : JsonConverter<string>
{
    public static readonly PostmanMinMaxLengthCheckConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(string);

    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is { Length: <= 10 })
        {
            return value;
        }
        throw new Exception("Cannot unmarshal type Postmanstring");
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        if (value.Length <= 10)
        {
            JsonSerializer.Serialize(writer, value, options);
            return;
        }
        throw new Exception("Cannot marshal type string");
    }
}

internal class PostmanModeConverter : JsonConverter<PostmanMode>
{
    public static readonly PostmanModeConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanMode);

    public override PostmanMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
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
        throw new Exception("Cannot unmarshal type PostmanMode");
    }

    public override void Write(Utf8JsonWriter writer, PostmanMode value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case PostmanMode.File:
                JsonSerializer.Serialize(writer, "file", options);
                return;
            case PostmanMode.Formdata:
                JsonSerializer.Serialize(writer, "formdata", options);
                return;
            case PostmanMode.Graphql:
                JsonSerializer.Serialize(writer, "graphql", options);
                return;
            case PostmanMode.Raw:
                JsonSerializer.Serialize(writer, "raw", options);
                return;
            case PostmanMode.Urlencoded:
                JsonSerializer.Serialize(writer, "urlencoded", options);
                return;
        }
        throw new Exception("Cannot marshal type Mode");
    }
}

internal class PostmanPathElementConverter : JsonConverter<PostmanPathElement>
{
    public static readonly PostmanPathElementConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanPathElement);

    public override PostmanPathElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanPathElement { String = stringValue };
            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<PostmanPathClass>(ref reader, options);
                return new PostmanPathElement { PathClass = objectValue };
        }
        throw new Exception("Cannot unmarshal type PostmanPathElement");
    }

    public override void Write(Utf8JsonWriter writer, PostmanPathElement value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.PathClass != null)
        {
            JsonSerializer.Serialize(writer, value.PathClass, options);
            return;
        }
        throw new Exception("Cannot marshal type PathElement");
    }
}

internal class PostmanRequestUnionConverter : JsonConverter<PostmanRequestUnion>
{
    public static readonly PostmanRequestUnionConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanRequestUnion);

    public override PostmanRequestUnion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanRequestUnion { String = stringValue };
            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<PostmanRequestClass>(ref reader, options);
                return new PostmanRequestUnion { RequestClass = objectValue };
        }
        throw new Exception("Cannot unmarshal type PostmanRequestUnion");
    }

    public override void Write(Utf8JsonWriter writer, PostmanRequestUnion value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.RequestClass != null)
        {
            JsonSerializer.Serialize(writer, value.RequestClass, options);
            return;
        }
        throw new Exception("Cannot marshal type RequestUnion");
    }
}

internal class PostmanResponseConverter : JsonConverter<PostmanResponse>
{
    public static readonly PostmanResponseConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanResponse);

    public override PostmanResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return new PostmanResponse();
            case JsonTokenType.Number:
                var doubleValue = reader.GetDouble();
                return new PostmanResponse { Double = doubleValue };
            case JsonTokenType.True:
            case JsonTokenType.False:
                var boolValue = reader.GetBoolean();
                return new PostmanResponse { Bool = boolValue };
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanResponse { String = stringValue };
            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<PostmanResponseClass>(ref reader, options);
                return new PostmanResponse { ResponseClass = objectValue };
            case JsonTokenType.StartArray:
                var arrayValue = JsonSerializer.Deserialize<List<object>>(ref reader, options);
                return new PostmanResponse { AnythingArray = arrayValue };
        }
        throw new Exception("Cannot unmarshal type PostmanResponse");
    }

    public override void Write(Utf8JsonWriter writer, PostmanResponse value, JsonSerializerOptions options)
    {
        if (value.IsNull)
        {
            writer.WriteNullValue();
            return;
        }
        if (value.Integer != null)
        {
            JsonSerializer.Serialize(writer, value.Integer.Value, options);
            return;
        }
        if (value.Double != null)
        {
            JsonSerializer.Serialize(writer, value.Double.Value, options);
            return;
        }
        if (value.Bool != null)
        {
            JsonSerializer.Serialize(writer, value.Bool.Value, options);
            return;
        }
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.AnythingArray != null)
        {
            JsonSerializer.Serialize(writer, value.AnythingArray, options);
            return;
        }
        if (value.ResponseClass != null)
        {
            JsonSerializer.Serialize(writer, value.ResponseClass, options);
            return;
        }
        throw new Exception("Cannot marshal type Response");
    }
}

internal class PostmanResponseTimeConverter : JsonConverter<PostmanResponseTime>
{
    public static readonly PostmanResponseTimeConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanResponseTime);

    public override PostmanResponseTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return new PostmanResponseTime();
            case JsonTokenType.Number:
                var doubleValue = reader.GetDouble();
                return new PostmanResponseTime { Double = doubleValue };
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanResponseTime { String = stringValue };
        }
        throw new Exception("Cannot unmarshal type PostmanResponseTime");
    }

    public override void Write(Utf8JsonWriter writer, PostmanResponseTime value, JsonSerializerOptions options)
    {
        if (value.IsNull)
        {
            writer.WriteNullValue();
            return;
        }
        if (value.Double != null)
        {
            JsonSerializer.Serialize(writer, value.Double.Value, options);
            return;
        }
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        throw new Exception("Cannot marshal type ResponseTime");
    }
}

internal class PostmanSrcConverter : JsonConverter<PostmanSrc>
{
    public static readonly PostmanSrcConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanSrc);

    public override PostmanSrc Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return new PostmanSrc();
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanSrc { String = stringValue };
            case JsonTokenType.StartArray:
                var arrayValue = JsonSerializer.Deserialize<List<object>>(ref reader, options);
                return new PostmanSrc { AnythingArray = arrayValue };
        }
        throw new Exception("Cannot unmarshal type PostmanSrc");
    }

    public override void Write(Utf8JsonWriter writer, PostmanSrc value, JsonSerializerOptions options)
    {
        if (value.IsNull)
        {
            writer.WriteNullValue();
            return;
        }
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.AnythingArray != null)
        {
            JsonSerializer.Serialize(writer, value.AnythingArray, options);
            return;
        }
        throw new Exception("Cannot marshal type Src");
    }
}

internal class PostmanUrlConverter : JsonConverter<PostmanUrl>
{
    public static readonly PostmanUrlConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanUrl);

    public override PostmanUrl Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanUrl { String = stringValue };
            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<PostmanUrlClass>(ref reader, options);
                return new PostmanUrl { UrlClass = objectValue };
        }
        throw new Exception("Cannot unmarshal type PostmanUrl");
    }

    public override void Write(Utf8JsonWriter writer, PostmanUrl value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.UrlClass != null)
        {
            JsonSerializer.Serialize(writer, value.UrlClass, options);
            return;
        }
        throw new Exception("Cannot marshal type Url");
    }
}

internal class PostmanUrlPathConverter : JsonConverter<PostmanUrlPath>
{
    public static readonly PostmanUrlPathConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanUrlPath);

    public override PostmanUrlPath Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new PostmanUrlPath { String = stringValue };
            case JsonTokenType.StartArray:
                var arrayValue = JsonSerializer.Deserialize<List<PostmanPathElement>>(ref reader, options);
                return new PostmanUrlPath { AnythingArray = arrayValue };
        }
        throw new Exception("Cannot unmarshal type PostmanUrlPath");
    }

    public override void Write(Utf8JsonWriter writer, PostmanUrlPath value, JsonSerializerOptions options)
    {
        if (value.String != null)
        {
            JsonSerializer.Serialize(writer, value.String, options);
            return;
        }
        if (value.AnythingArray != null)
        {
            JsonSerializer.Serialize(writer, value.AnythingArray, options);
            return;
        }
        throw new Exception("Cannot marshal type UrlPath");
    }
}
internal class PostmanVariableTypeConverter : JsonConverter<PostmanVariableType>
{
    public static readonly PostmanVariableTypeConverter Singleton = new();

    public override bool CanConvert(Type t) => t == typeof(PostmanVariableType);

    public override PostmanVariableType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
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
        throw new Exception("Cannot unmarshal type PostmanVariableType");
    }

    public override void Write(Utf8JsonWriter writer, PostmanVariableType value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case PostmanVariableType.Any:
                JsonSerializer.Serialize(writer, "any", options);
                return;
            case PostmanVariableType.Boolean:
                JsonSerializer.Serialize(writer, "boolean", options);
                return;
            case PostmanVariableType.Number:
                JsonSerializer.Serialize(writer, "number", options);
                return;
            case PostmanVariableType.String:
                JsonSerializer.Serialize(writer, "string", options);
                return;
        }
        throw new Exception("Cannot marshal type VariableType");
    }
}
internal class PostmanIsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public static readonly PostmanIsoDateTimeOffsetConverter Singleton = new();

    private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

    private CultureInfo? _culture;

    private string? _dateTimeFormat;

    public CultureInfo Culture
    {
        get => _culture ?? CultureInfo.CurrentCulture;
        set => _culture = value;
    }

    public string? DateTimeFormat
    {
        get => _dateTimeFormat ?? string.Empty;
        set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
    }

    public DateTimeStyles DateTimeStyles { get; set; } = DateTimeStyles.RoundtripKind;

    public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateText = reader.GetString();

        if (string.IsNullOrEmpty(dateText) == false)
        {
            if (!string.IsNullOrEmpty(_dateTimeFormat))
            {
                return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, DateTimeStyles);
            }

            return DateTimeOffset.Parse(dateText, Culture, DateTimeStyles);
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        if ((DateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
            || (DateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
        {
            value = value.ToUniversalTime();
        }

        var text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

        writer.WriteStringValue(text);
    }
}
#pragma warning restore CS8618
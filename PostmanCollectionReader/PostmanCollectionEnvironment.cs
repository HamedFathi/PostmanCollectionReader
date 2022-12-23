﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PostmanCollectionReader
{
    public class Environment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<EnvironmentVariable> Values { get; set; }

        [JsonProperty("_postman_variable_scope")]
        public string PostmanVariableScope { get; set; }

        [JsonProperty("_postman_exported_at")]
        public DateTime PostmanExportedAt { get; set; }

        [JsonProperty("_postman_exported_using")]
        public string PostmanExportedUsing { get; set; }
    }

    public class EnvironmentVariable
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public partial class PostmanCollection
    {
        public static Environment EnvironmentFromJson(string json) => JsonConvert.DeserializeObject<Environment>(json);
    }
}

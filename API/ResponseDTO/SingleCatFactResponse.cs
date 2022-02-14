namespace AutomatedAPITests
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SingleCatFactResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("used")]
        public bool Used { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("sentCount")]
        public long SentCount { get; set; }
    }

    public partial class User
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("photo")]
        public Uri Photo { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }
}

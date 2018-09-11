using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPlusLeaderBoardTester
{
    public partial class KeyJson
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("map")]
        public Map Map { get; set; }

        [JsonProperty("period")]
        public long Period { get; set; }

        [JsonProperty("period_start_timestamp")]
        public long PeriodStartTimestamp { get; set; }

        [JsonProperty("period_end_timestamp")]
        public long PeriodEndTimestamp { get; set; }

        [JsonProperty("connected_realm")]
        public ConnectedRealm ConnectedRealm { get; set; }

        [JsonProperty("leading_groups")]
        public LeadingGroup[] LeadingGroups { get; set; }

        [JsonProperty("keystone_affixes")]
        public KeystoneAffixElement[] KeystoneAffixes { get; set; }

        [JsonProperty("map_challenge_mode_id")]
        public long MapChallengeModeId { get; set; }

        [JsonProperty("name")]
        public Dictionary<string, string> Name { get; set; }
    }

    public partial class ConnectedRealm
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class KeystoneAffixElement
    {
        [JsonProperty("keystone_affix")]
        public KeystoneAffixKeystoneAffix KeystoneAffix { get; set; }

        [JsonProperty("starting_level")]
        public long StartingLevel { get; set; }
    }

    public partial class KeystoneAffixKeystoneAffix
    {
        [JsonProperty("key")]
        public ConnectedRealm Key { get; set; }

        [JsonProperty("name")]
        public Dictionary<string, string> Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class LeadingGroup
    {
        [JsonProperty("ranking")]
        public long Ranking { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("completed_timestamp")]
        public long CompletedTimestamp { get; set; }

        [JsonProperty("keystone_level")]
        public long KeystoneLevel { get; set; }

        [JsonProperty("members")]
        public Member[] Members { get; set; }
    }

    public partial class Member
    {
        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("specialization")]
        public Specialization Specialization { get; set; }
    }

    public partial class Profile
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("realm")]
        public Realm Realm { get; set; }
    }

    public partial class Realm
    {
        [JsonProperty("key")]
        public ConnectedRealm Key { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public partial class Specialization
    {
        [JsonProperty("key")]
        public ConnectedRealm Key { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Map
    {
        [JsonProperty("name")]
        public Dictionary<string, string> Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}

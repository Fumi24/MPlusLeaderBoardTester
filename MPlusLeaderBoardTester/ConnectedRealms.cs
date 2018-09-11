using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPlusLeaderBoardTester
{
    public partial class ConnectedRealms
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("connected_realms")]
        public Self[] ConnectedRealmsConnectedRealms { get; set; }
    }

    public partial class Self
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public Self Self { get; set; }
    }
}

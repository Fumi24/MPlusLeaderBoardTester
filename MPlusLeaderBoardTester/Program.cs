using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace MPlusLeaderBoardTester
{
    class Program
    {
        public int CurrentPeriod = 662;
        public List<int> ConnectedRealmIDs = new List<int>();
        public List<int> DungeonIDs = new List<int>();
        public Dictionary<int, string> Realms = new Dictionary<int, string>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.run();
        }
        public void run()
        {
            DungeonIDs.Add(244);
            DungeonIDs.Add(245);
            DungeonIDs.Add(246);
            DungeonIDs.Add(247);
            DungeonIDs.Add(248);
            DungeonIDs.Add(249);
            DungeonIDs.Add(250);
            DungeonIDs.Add(251);
            DungeonIDs.Add(252);
            DungeonIDs.Add(353);

            GetConnectedRealms();
            foreach (var ID in ConnectedRealmIDs)
            {
                Realms.Add(ID, TranslateRealmID(ID));
            }
            HighestKeyOnServer();
        }
        public void GetConnectedRealms()
        {
            var client = new RestClient("https://eu.api.battle.net/data/wow/connected-realm/?namespace=dynamic-eu&locale=en_GB&access_token=daybqy79p62emjmxxhbh42bu");
            var request = new RestRequest();
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Two ways to get the result:
                string rawResponse = response.Content;
                ConnectedRealms myClass = JsonConvert.DeserializeObject<ConnectedRealms>(rawResponse);
                foreach (var item in myClass.ConnectedRealmsConnectedRealms)
                {
                    Regex regex = new Regex(@"\d+");
                    Match match = regex.Match(item.Href);
                    ConnectedRealmIDs.Add(Convert.ToInt32(match.Value));
                }
            }
        }
        public void HighestKeyOnServer()
        {
            foreach (var Realm in Realms)
            {
                foreach (var Dungeon in DungeonIDs)
                {
                    var client = new RestClient("https://eu.api.battle.net/data/wow/connected-realm/" + Realm.Key + "/mythic-leaderboard/" + Dungeon + "/period/662?namespace=dynamic-eu&access_token=daybqy79p62emjmxxhbh42bu");
                    var request = new RestRequest();
                    var response = client.Execute(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Two ways to get the result:
                        string rawResponse = response.Content;
                        KeyJson myClass = JsonConvert.DeserializeObject<KeyJson>(rawResponse);
                        Console.WriteLine(Realm.Value);
                        foreach (var item in myClass.Map.Name)
                        {
                            if (item.Key == "en_US")
                                Console.WriteLine(item.Value);
                        }
                        foreach (var item in myClass.LeadingGroups)
                        {
                            if (item.Ranking == 1)
                            {
                                Console.WriteLine(item.KeystoneLevel);
                            }
                        }
                    }
                }
            }
        }
        public string TranslateRealmID(int ID)
        {
            var client = new RestClient("https://eu.api.battle.net/data/wow/connected-realm/" + ID + "?namespace=dynamic-eu&locale=en_GB&access_token=924u98gjbww6ctk8n6p8zx9v");
            var request = new RestRequest();
            var response = client.Execute(request);
            string slug = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                RealmJson realm = JsonConvert.DeserializeObject<RealmJson>(rawResponse);
                foreach (var item in realm.Realms)
                {
                    slug = item.Slug;
                }
            }
            return slug;
        }
    }
}

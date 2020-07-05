using Newtonsoft.Json;
using Orikivo.Static;
using System.Collections.Generic;

namespace Orikivo
{
    // merits must have seperate goal tracking.
    public class Merit
    {
        public Merit(ushort id, ushort rank, ushort group, string name, string description, bool classified, string iconUrl = "")
        {
            Id = id;
            RankId = rank;
            GroupId = group;
            Name = name;
            Description = description;
            Classified = classified;
            _iconUrl = iconUrl;
        }

        public Merit(ushort id, ushort rank, ushort group, string name, string description, bool classified, MeritCriterion criterion, Reward reward, string iconUrl = "") : this(id, rank, group, name, description, classified, iconUrl)
        {
            Criteria = new List<MeritCriterion>();
            Criteria.Add(criterion);

            Rewards = new List<Reward>();
            Rewards.Add(reward);
        }

        public Merit(ushort id, ushort rank, ushort group, string name, string description, bool classified, MeritCriterion criterion, List<Reward> rewards, string iconUrl = "") : this(id, rank, group, name, description, classified, iconUrl)
        {
            Criteria = new List<MeritCriterion>();
            Criteria.Add(criterion);

            Rewards = rewards;
        }

        public Merit(ushort id, ushort rank, ushort group, string name, string description, bool classified, List<MeritCriterion> criteria, Reward reward, string iconUrl = "") : this(id, rank, group, name, description, classified, iconUrl)
        {
            Criteria = criteria;

            Rewards = new List<Reward>();
            Rewards.Add(reward);
        }

        [JsonConstructor]
        public Merit(ushort id, ushort rank, ushort group, string name, string description, bool classified, List<MeritCriterion> criteria, List<Reward> rewards, string iconUrl = "") : this(id, rank, group, name, description, classified, iconUrl)
        {
            Criteria = criteria;
            Rewards = rewards;
        }
        
        [JsonProperty("id")]
        public ushort Id { get; }
        [JsonProperty("rank")]
        public ushort RankId { get; }
        [JsonProperty("group")]
        public ushort GroupId { get; }

        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("description")]
        public string Description { get; }
        [JsonProperty("classified")]
        public bool Classified { get; } // if the criteria is visible or not.
        [JsonProperty("criteria")]
        public List<MeritCriterion> Criteria { get; }
        [JsonProperty("rewards")]
        public List<Reward> Rewards { get; } // the pool of items to be granted.

        [JsonProperty("icon_url")]
        private string _iconUrl;
        public string IconUrl { get { return string.IsNullOrWhiteSpace(_iconUrl) ? "" : $"{Locator.Resources}merits//icons//{_iconUrl}"; } }

        public string IdValue { get { return $"{GroupId.ToString("00")}{Id.ToString("000")}{RankId.ToString("00")}"; } }


        /*
        public bool MetCriteria(OriUser user)
        {
            foreach(MeritCriterion criterion in Criteria)
                if (!criterion.Check(user))
                    return false;
            
            return true;
        }
        */
    }
}

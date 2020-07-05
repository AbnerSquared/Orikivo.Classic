using Newtonsoft.Json;
using System;

namespace Orikivo
{
    public class MeritCriterion
    {
        [JsonConstructor]
        public MeritCriterion(MeritGoalType goal, ulong bound, EventType? eventType = null, MeritValueType? type = null)
        {
            if (!(bound > 0))
                throw new Exception("The upper bound of a merit cannot be equal to or less than 0.");

            Goal = goal;
            
            switch(Goal)
            {
                // MeritGoalType.Collect
                case MeritGoalType.Own:
                    if (!type.HasValue)
                        throw new Exception("MeritGoalType.Own requires that MeritValueType be used for its criterion.");
                    Type = type;
                    break;
                case MeritGoalType.Event:
                    if (!eventType.HasValue)
                        throw new Exception("MeritGoalType.Event requires that EventType be used for its criterion.");
                    Event = eventType;
                    break;
            } // add default?

            Bound = bound;
        }

        [JsonProperty("goal")]
        public MeritGoalType Goal { get; }
        [JsonProperty("value_type")]
        public MeritValueType? Type { get; }
        [JsonProperty("event_type")]
        public EventType? Event { get; }
        [JsonProperty("bound")]
        public ulong Bound { get; }
        /*
        public bool Check(OriUser user)
        {
            switch(Goal)
            {
                case MeritGoalType.Own:
                    if (Type == null)
                        throw new Exception("The MeritValueType required to check a criterion is null.");
                    switch (Type)
                    {
                        case MeritValueType.Balance:
                            if (user.Wallet.Balance > Bound)
                                return true;
                            break;
                        case MeritValueType.Debt:
                            if (user.Wallet.Debt > Bound)
                                return true;
                            break;
                    }
                    break;
                case MeritGoalType.Event:
                    if (Event == null)
                        throw new Exception("The EventType required to check a criterion is null.");
                    switch(Event)
                    {
                        case EventType.Daily:
                            if (user.Cache.Events[EventType.Daily] > Bound)
                                return true;
                            break;
                        case EventType.Vote:
                            if (user.Cache.Events[EventType.Vote] > Bound)
                                return true;
                            break;
                        case EventType.Spectral:
                            if (user.Cache.Events[EventType.Spectral] > Bound)
                                return true;
                            break;
                    }
                    break;
            }

            return false;
        }
        */
    }
}

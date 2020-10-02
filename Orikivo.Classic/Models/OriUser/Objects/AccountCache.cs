namespace Orikivo
{
    public class AccountCache
    {
        public PlazaCache Plaza {get; set;} // cache of all stored events/interactions/outcomes/etc.
        public MeritCache Merits {get; set;} // cache of all earned merits
        public UpgradeCache Upgrades {get; set;} // cache of all stored upgrades
        public CooldownCache Cooldowns {get; set;} // cache of all cooldowns
        public ArcadeCache Arcade {get; set;} // data cache of all long-term/active games.
        public CasinoCache Casino {get; set;} // data cache of all long-term/active gambles.
        public LicenseCache License {get; set;} // data cache of the last license built; used to determine if the card is up to date/if it needs to render again.
    }
}
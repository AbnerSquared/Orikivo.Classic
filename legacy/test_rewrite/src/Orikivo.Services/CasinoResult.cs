using Discord;
using Orikivo.Static;
using Orikivo.Systems.Presets;

namespace Orikivo.Services
{
    public class CasinoResult
    {
        public static string Base = "{0} | {1} | {2}";
        public CasinoResult(OldAccount a, WagerMode mode, double wager, bool victory, decimal risk, double reward, string input, string outcome)
        {
            Player = a;
            Mode = mode;
            Item = FindItem();

            Wager = wager;
            Reward = reward;
            Risk = risk;
            Victory = victory;

            Input = input;
            Outcome = outcome;
        }

        public OldAccount Player { get; set; } // the id of the account that bet.
        public WagerItem Item { get; set; }
        public WagerMode Mode { get; set; } // the betting game mode that was played.
        public string Input { get; set; } // the string describing your input for the bet.
        public string Outcome { get; set; } // the string describing the exact roll, flip or point of the bet.
        public double Wager { get; set; } // how much the player bet.
        public double Reward { get; set; } // the winnings this bet yields.
        public decimal Risk { get; set; } // the actual raw percentage of change there was to lose.
        public bool Victory { get; set; } // if the person who wagered won.
        public string LosingSummary { get; set; } // an optional summary.

        public void WithLosingSummary(string summary)
        {
            LosingSummary = summary;
        }

        private string GetModeName()
        {
            switch (Mode)
            {
                case WagerMode.SelectiveRoll:
                    return "Selective Roll";
                case WagerMode.RangedRoll:
                    return "Ranged Roll";
                case WagerMode.Doubler:
                    return "Double or Nothing";
                case WagerMode.CoinFlip:
                    return "Coin Flip";
                default:
                    return "Unknown Mode";
            }
        }

        private WagerItem FindItem()
        {
            if (Mode.EqualsAny(WagerMode.SelectiveRoll, WagerMode.RangedRoll))
            {
                return WagerItem.Dice;
            }
            if (Mode.EqualsAny(WagerMode.Doubler))
            {
                return WagerItem.Tick;
            }
            if (Mode.EqualsAny(WagerMode.CoinFlip))
            {
                return WagerItem.Coin;
            }

            return WagerItem.Empty;
        }

        private string GetItemIcon()
        {
            switch(Item)
            {
                case WagerItem.Tick:
                    return $"{EmojiIndex.Tick}";
                case WagerItem.Dice:
                    return $"{EmojiIndex.Dice}";
                case WagerItem.Coin:
                    return $"{EmojiIndex.Coin}"; ;
                default:
                    return "";
            }
        }

        public Embed Generate()
        {
            EmbedBuilder e = EmbedData.DefaultEmbed;
            EmbedFooterBuilder f = new EmbedFooterBuilder();
            f.WithText(ToString());

            // Colors
            Color onEmptyColor = EmbedData.GetColor("steamerror");
            Color onLoseColor = EmbedData.GetColor("error");
            Color onWinColor = EmbedData.GetColor("origreen");

            // Titles
            string onWinTitle = "+ {0}";
            string onLoseTitle = "- {0}";
            string onOORTitle = "> {0}";

            // Money display
            string money = $"{EmojiIndex.Balance}" + "{0}".MarkdownBold();

            string defLoseDesc = "You lost at chance at {0}.";
            string defWinDesc = "You have earned " + "(x{0})".MarkdownBold() + " the initial bet!";
            string defEmptyDesc = "You do know you need money, right?";
            string defOORDesc = "You asked to wager a bit too much.";

            // exceptions based on balance.
            if (Player.Balance == 0)
            {
                e.WithColor(onEmptyColor);
                e.WithTitle(string.Format(money, "null"));
                e.WithDescription(defEmptyDesc);

                return e.Build();
            }
            if (Player.Balance - Wager < 0)
            {
                if (!Player.Config.Overflow)
                {
                    e.WithColor(onEmptyColor);
                    e.WithTitle(string.Format(onOORTitle, string.Format(money, Player.Balance.ToPlaceValue())));
                    e.WithDescription(defOORDesc);

                    return e.Build();
                }
                Wager = Player.Balance;
            }

            Player.Take((ulong)Wager);
            e.WithFooter(f);

            if (Victory)
            {
                Player.Give((ulong)Reward);
                e.WithColor(onWinColor);
                e.WithTitle(string.Format(onWinTitle, string.Format(money, Reward.ToPlaceValue())));
                e.WithDescription(string.Format(defWinDesc, Risk.ToString("##,0.0#")));

                return e.Build();
            }
            else
            {
                e.WithColor(onLoseColor);
                e.WithTitle(string.Format(onLoseTitle, string.Format(money, Wager.ToPlaceValue())));
                e.WithDescription(LosingSummary ?? string.Format(defLoseDesc, string.Format(money, Reward.ToPlaceValue())));

                return e.Build();
            }
        }

        public override string ToString()
        {
            // 0 - the landing result of the dice
            // 1 - the game mode name
            // 2 - the statistics of the game
            // aka the dice you rolled, the sides you bet on.
            return string.Format(Base, $"{GetItemIcon()}{Outcome}", GetModeName(), Input);
        }
    }
}
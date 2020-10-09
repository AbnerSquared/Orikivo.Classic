using Discord;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Orikivo.Modules
{
    public static class OptionsHelper
    {
        public static bool TryParseOption(Emoji emoji, out AccountOption ao)
        {
            ao = AccountOption.AutoFix;
            if (emoji.TryGetAccountOption(out ao))
            {
                return true;
            }
            return false;
        }
        public static bool TryParseOption(string s, out AccountOption ao)
        {
            ao = AccountOption.AutoFix;
            Type option = typeof(AccountOption);
            foreach (string name in option.GetEnumNames())
            {
                name.Debug();
                if (name.Matches(s, MatchHandling.Match, MatchValueHandling.StartsWith))
                {
                    ao = (AccountOption)option.GetField(name).GetRawConstantValue();
                    return true;
                }
            }

            return false;
        }
        public static bool TryParseOption(int i, out AccountOption ao)
        {
            if (!Enum.TryParse($"{i}", out ao))
                return false;
            return true;
        }

        public static List<Interpreter> InterpretAll()
        {
            AccountOptions opts = AccountOptions.Default;
            List<Interpreter> itrs = new List<Interpreter>();
            foreach (PropertyInfo p in opts.ValidProperties)
            {
                object value = p.GetValue(opts);
                if (!value.Exists())
                {
                    if (opts.EmptyFormat == NullObjectHandling.Ignore)
                        continue;
                }

                itrs.Add(Interpret(p));
            }

            return itrs;
        }

        public static Interpreter Interpret(PropertyInfo p)
        {
            AccountOptions opts = AccountOptions.Default;
            p.TryGetIcon(out Emoji icon);
            p.TryGetName(out string name);
            p.TryGetDefinition(out string definition);
            p.TryGetAccountOption(out AccountOption option);
            return new Interpreter(p.PropertyType, name ?? p.Name, definition, value: p.GetValue(opts).Read(), icon: icon, id: (ulong)option);
        }

        public static Interpreter GetInterpreter(AccountOption ao)
        {
            AccountOptions opts = AccountOptions.Default;
            if (opts.TryGetOptionProperty(ao, out PropertyInfo p))
            {
                return Interpret(p);
            }
            throw new Exception("Invalid account option property.");
        }
    }
}
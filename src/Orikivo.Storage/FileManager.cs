using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Orikivo.Static;
using System.Linq;

namespace Orikivo.Storage
{
    public class FileManager
    {
        public static ShopCache GetShops()
        {
            string dir = Directory.CreateDirectory($"{Locator.Resources}\\shops\\").FullName;
            List<OriShop> shops = GetJsonFiles(dir).Select(Manager.Load<OriShop>).ToList();

            return new ShopCache(shops);
        }

        public static ItemCache GetItems()
        {
            string dir = Directory.CreateDirectory($"{Locator.Resources}//items//").FullName;
            List<OriItem> items = GetJsonFiles(dir).Select(Manager.Load<OriItem>).ToList();

            return new ItemCache(items);
        }

        public static FontCache GetFonts()
        {
            char[][][][] arrayMap = Manager.LoadDynamicArray<char[][][][]>(Locator.ArrayMap);
            string path = Directory.CreateDirectory($"{Locator.Resources}//fonts//").FullName;
            List<FontFace> fonts = GetJsonFiles(path).Select(Manager.Load<FontFace>).ToList();

            return new FontCache(fonts, arrayMap);
        }

        public static MeritCache GetMerits()
        {
            string path = Directory.CreateDirectory($"{Locator.Resources}//merits//").FullName;
            List<Merit> merits = GetJsonFiles(path).Select(Manager.Load<Merit>).ToList();

            return new MeritCache(merits);
        }

        public static List<string> GetJsonFiles(string directory)
            => Directory.Exists(directory) ? Directory.GetFiles(directory, "*.json").ToList() : new List<string>();

        public static string TryGetDirectory<T>()
        {
            string dir = @$".\{Locator.Data}\";

            if (typeof(T) == typeof(OldAccount))
                dir += $"{Locator.Accounts}";
            else if (typeof(T) == typeof(Server))
                dir += $"{Locator.Guilds}";

            dir = Directory.CreateDirectory(dir).FullName;
            return dir;
        }

        public static string TryGetPath<T>(T obj)
        {
            string path = TryGetDirectory<T>();
            path += obj switch
            {
                IStorable storable => $"\\{storable.Id}.{Locator.Output}",
                OldGlobal _ => $"global.{Locator.Output}",
                _ => $"{obj}.{Locator.Output}"
            };

            return path;
        }

        public static List<string> TryGetFiles(string directory)
        {
            return Directory.Exists(directory) ? Directory.GetFiles(directory).ToList() : new List<string>();
        }

        public static ConcurrentDictionary<ulong, T> GetContainer<T>()
        {
            var tmp = new ConcurrentDictionary<ulong, T>();
            UpdateContainer(tmp, TryGetFiles(TryGetDirectory<T>()));
            return tmp;
        }

        public static ConcurrentDictionary<ulong, T> UpdateContainer<T>(ConcurrentDictionary<ulong, T> container, List<string> index)
        {
            foreach (string path in index)
            {
                var tmp = Manager.Load<T>(path);
                tmp.Debug();
                container.AddOrUpdate(PathToId(path), tmp, (k, v) => tmp);
            }

            return container;
        }

        public static ulong PathToId(string path)
        {
            return ulong.Parse(Path.GetFileNameWithoutExtension(path));
        }
    }
}
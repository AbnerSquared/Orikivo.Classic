using Orikivo.Storage;
using System.IO;
using System.Reflection;
using System.Text;

namespace Orikivo
{
    public static class CacheIndex
    {
        public static FontCache Fonts { get; private set; }
        public static TokenCache Tokens { get; private set; }
        public static MeritCache Merits { get; private set; }

        static CacheIndex()
        {
            //Sprites = FileManager.GetSprites();
            Fonts = FileManager.GetFonts();
            Merits = FileManager.GetMerits();
        }

        public static void ReadAssembly(Assembly a)
        {
            StringBuilder sb = new StringBuilder();

            a.ExportedTypes.ForEach(x => sb.AppendLine(x.ToString()));
            a.GetManifestResourceNames().ForEach(x => sb.AppendLine(x));
            a.FullName.Debug("full name");
            a.CodeBase.Debug("code base");

            Manager.WriteTextAsync(sb.ToString(), ".//misc//tree.txt");
        }

        public static string GetEmbeddedResource(string resource, Assembly assembly)
        {
            resource = FormatResourceName(assembly, resource);

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            {
                if (resource == null)
                    return null;
                using (StreamReader reader = new StreamReader(resource))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static string FormatResourceName(Assembly assembly, string resource)
        {
            return $"{assembly.GetName().Name}.{resource.Replace(" ", "_").Replace("\\", ".").Replace("/", ".")}";
        }
    }
}

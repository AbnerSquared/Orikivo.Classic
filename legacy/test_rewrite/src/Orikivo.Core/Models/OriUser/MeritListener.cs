using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orikivo
{
    public class MeritListener
    {
        public MeritListener()
        {
            Merits = CacheIndex.Merits.Merits;
        }

        public List<Merit> Merits { get; }

        /*
        public void Listen(OriUser user)
        {
            foreach(Merit merit in Merits.Where(x => !x.EqualsAny(user.Cache.Merits.Claimed.Enumerate(y => y.Source).ToArray())))
            {
                if (merit.MetCriteria(user))
                    user.Cache.Merits.Log(merit);
            }
        }
        */
    }
}

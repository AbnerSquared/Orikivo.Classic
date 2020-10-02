using System.Collections.Generic;

namespace Orikivo
{
    /// <summary>
    /// Defines a collection structure.
    /// </summary>
    public interface IContextCollection<T>
    {
        List<T> Values { get; set; }
    }
}
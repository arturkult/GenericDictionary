using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionaries.Repositories.Interfaces
{
    public interface IDictionaryRepository
    {
        IEnumerable<object> GetProperDictionaryByName(string DictionaryName);
    }
}

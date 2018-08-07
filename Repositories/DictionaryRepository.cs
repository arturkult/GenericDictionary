using Dictionaries.Models;
using Dictionaries.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dictionaries.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        DictionaryContext context;

        public DictionaryRepository(DictionaryContext context)
        {
            this.context = context;
        }

        public IEnumerable<object> GetProperDictionaryByName(string DictionaryName)
        {
            var dbSet = context.GetType().GetProperty(DictionaryName).GetGetMethod();
            IQueryable<object> result = dbSet.Invoke(context, null) as IQueryable<object>;

            if(result.Count()!=0)
            {
                var item = result.FirstOrDefault();

                foreach(PropertyInfo property in item.GetType().GetProperties())
                {
                    if(property.MemberType == MemberTypes.Property)
                    {
                        var type = property.PropertyType;
                        if (!(type.IsPrimitive
                            || type.Equals(typeof(string))))
                        {
                            DictionaryHelper.Set(context, type).Load();
                        }
                            
                    }
                }
            }
            result = dbSet.Invoke(context, null) as IQueryable<object>;

            return result.AsEnumerable<object>();
        }
    }
}

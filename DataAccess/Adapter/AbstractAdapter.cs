using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace DataAccess.Adapter
{
    public abstract class AbstractAdapter<T,K> where K:EntityObject
    {
        public abstract T Transform(K dbObject);

        public virtual ICollection<T> Transform(ICollection<K> dbObjects)
        {
            List<T> data = new List<T>();

            foreach (var item in dbObjects)
            {
                data.Add(Transform(item));
            }

            return data;
        }
    }
}

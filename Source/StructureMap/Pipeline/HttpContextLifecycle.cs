using System;
using System.Collections;

namespace StructureMap.Pipeline
{
    public class HttpContextLifecycle : ILifecycle
    {
        public static readonly string ITEM_NAME = "STRUCTUREMAP-INSTANCES";


        public void EjectAll()
        {
            FindCache().DisposeAndClear();
        }

        public IObjectCache FindCache()
        {
            IDictionary items = findHttpDictionary();

            if (!items.Contains(ITEM_NAME))
            {
                lock (items.SyncRoot)
                {
                    if (!items.Contains(ITEM_NAME))
                    {
                        var cache = new MainObjectCache();
                        items.Add(ITEM_NAME, cache);

                        return cache;
                    }
                }
            }

            return (IObjectCache) items[ITEM_NAME];
        }

        public string Scope { get { return InstanceScope.HttpContext.ToString(); } }

        public static bool HasContext()
        {
            throw new InvalidOperationException(typeof(HttpContextLifecycle).Name + " is not supported in the Client Profile version of StructureMap");
        }

        public static void DisposeAndClearAll()
        {
            new HttpContextLifecycle().FindCache().DisposeAndClear();
        }


        protected virtual IDictionary findHttpDictionary()
        {
            throw new InvalidOperationException(GetType().Name + " is not supported in the Client Profile version of StructureMap");
        }
    }
}
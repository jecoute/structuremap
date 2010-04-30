using System;
using System.Collections;

namespace StructureMap.Pipeline
{
    public class HttpSessionLifecycle : HttpContextLifecycle
    {
        protected override IDictionary findHttpDictionary()
        {
            throw new InvalidOperationException(GetType().Name + " is not supported in the Client Profile version of StructureMap");
        }
    }
}
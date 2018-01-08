using System;
using System.Collections.Concurrent;
using Newtonsoft.Json.Serialization;

namespace Common
{
    public class CrossPlatformSerializationBinder : DefaultSerializationBinder
    {
        static readonly bool IsNetCore = Type.GetType("System.String, System.Private.CoreLib") != null;
        readonly ConcurrentDictionary<string, Type> _mappedTypes = new ConcurrentDictionary<string, Type>();

        public override Type BindToType(string assemblyName, string typeName)
        {
            _mappedTypes.TryGetValue(typeName, out Type t);

            if (t != null)
                return t;

            var originalTypeName = typeName;

            if (IsNetCore)
            {
                typeName = typeName.Replace("mscorlib", "System.Private.CoreLib");
                assemblyName = assemblyName.Replace("mscorlib", "System.Private.CoreLib");
            }
            else
            {
                typeName = typeName.Replace("System.Private.CoreLib", "mscorlib");
                assemblyName = assemblyName.Replace("System.Private.CoreLib", "mscorlib");
            }

            t = base.BindToType(assemblyName, typeName);
            _mappedTypes.TryAdd(originalTypeName, t);
            return t;
        }
    }
}

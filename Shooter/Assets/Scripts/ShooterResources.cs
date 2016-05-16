using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Newtonsoft.Json;

namespace Shooter
{
    public static class ShooterResources 
    {
        private static readonly Dictionary<Type, Object> ResourceHolder = new Dictionary<Type, Object>();

        static ShooterResources()
        {
            var textAsset = Resources.Load<TextAsset>("Resources");
            var resourcePaths = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);

            foreach (var pair in resourcePaths)
            {
                var type = Type.GetType(pair.Key);
                if (type == null)
                {
                    Debug.LogError("Type not found for resource : " + pair.Key);
                    continue;
                }

                var resource = Resources.Load(pair.Value);
                if (resource == null)
                {
                    Debug.LogError("Resource not found on path : " + pair.Value);
                    continue;
                }

                ResourceHolder.Add(type, resource);
            }
        }

        public static Object GetResource(Type type)
        {
            if (!ResourceHolder.ContainsKey(type))
            {
                Debug.LogError("Resource not found for type : " + type);
                return null;
            }

            return ResourceHolder[type];
        }
    }
}

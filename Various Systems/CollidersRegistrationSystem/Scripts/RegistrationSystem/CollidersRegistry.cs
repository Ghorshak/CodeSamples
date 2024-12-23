using System.Collections.Generic;
using UnityEngine;
using GameSystems;

namespace RegistrationSystem
{
    // won't be added automatically if doesn't exist because of a generic type
    public abstract class CollidersRegistry<T> : Singleton<CollidersRegistry<T>>
    {
        private Dictionary<Collider, T> DictByCollider { get; } = new();
        private List<Collider> IgnoredColliders { get; } = new();

        public bool TryRegisterCollider(Collider collider, T obj)
        {
            bool registered = DictByCollider.TryAdd(collider, obj);

            return registered;
        }

        public bool TryUnregisterCollider(Collider collider)
        {
            return DictByCollider.Remove(collider);
        }

        public bool TryGet(Collider collider, out T value)
        {
            return DictByCollider.TryGetValue(collider, out value);
        }

        public void RegisterIgnoredCollider(Collider collider)
        {
            if (IgnoredColliders.Contains(collider) == false)
                IgnoredColliders.Add(collider);
        }

        public void UnregisterIgnoredCollider(Collider collider)
        {
            IgnoredColliders.Remove(collider);
        }

        public bool CheckIfColliderIsIgnored(Collider collider)
        {
            return IgnoredColliders.Exists(c => c == collider);
        }
    }
}
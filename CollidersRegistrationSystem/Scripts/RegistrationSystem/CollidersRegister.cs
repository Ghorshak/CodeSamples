using System.Collections.Generic;
using System.Linq;
using GameSystems;
using UnityEngine;

namespace RegistrationSystem
{
    public abstract class CollidersRegister<T> : MonoBehaviour
    {
        protected abstract CollidersRegistry<T> RegistryInstance { get; }

        [field: SerializeField, Space,
            Tooltip("When disabled, ALL register's colliders will be registered automatically when the register is enabled. When enabled each collider will be registered separately at the moment when it normally would be checked with the registry (when collision event using this collider will occur).")]
        protected bool RegisterCollidersManually { get; set; } = true;

        [field: SerializeField] private bool AutoCollidersSetOnValidate { get; set; } = true;
        [field: SerializeField] protected Transform RootTransform { get; set; }
        [field: SerializeField, Space] protected List<Collider> Colliders { get; set; } = new();
        [field: SerializeField, Space] private List<Collider> IgnoredColliders { get; set; } = new();

        protected T RegisterComponent { get; set; }

        private void OnValidate()
        {
            if (AutoCollidersSetOnValidate)
            {
                if (RootTransform == null)
                    RootTransform = GetRootTransform();

                Colliders = GetColliders();
            }
        }

        protected virtual Transform GetRootTransform()
        {
            return transform.root;
        }

        protected virtual List<Collider> GetColliders(bool onlyConvex = false)
        {
            return RootTransform.GetComponentsInChildren<Collider>().Where(IsMatchedCollider).ToList();

            bool IsMatchedCollider(Collider c)
            {
                if (onlyConvex == false)
                    return !c.isTrigger;

                return !c.isTrigger && (c is not MeshCollider || (c is MeshCollider mc && mc.convex));
            }
        }

        private void Awake()
        {
            RegisterComponent = GetComponentInChildren<T>();
            if (RegisterComponent == null)
                Debug.LogError($"[{GetType().Name}] RegisterComponent of type {typeof(T).Name} is trying to be initialized but failed miserably.");
        }

        private void OnEnable()
        {
            if (RegisterCollidersManually == false)
                RegisterColliders();

            RegisterIgnoredColliders();
        }

        public void RegisterCollider(Collider collider)
        {
            if (RegisterComponent != null && RegisterCollidersManually && Colliders.Contains(collider))
                RegistryInstance.TryRegisterCollider(collider, RegisterComponent);
        }

        private void RegisterColliders()
        {
            if (RegisterComponent != null)
            {
                foreach (var collider in Colliders)
                    RegistryInstance.TryRegisterCollider(collider, RegisterComponent);
            }
        }

        private void RegisterIgnoredColliders()
        {
            foreach (var collider in IgnoredColliders)
                RegistryInstance.RegisterIgnoredCollider(collider);
        }

        private void UnregisterColliders()
        {
            if (Singleton.IsApplicationQuiting == false) // helps with cleanup and prevents new registry instance creation
            {
                foreach (var collider in Colliders)
                    RegistryInstance.TryUnregisterCollider(collider);
            }
        }

        private void UnregisterIgnoredColliders()
        {
            if (Singleton.IsApplicationQuiting == false) // helps with cleanup and prevents new registry instance creation
            {
                foreach (var collider in IgnoredColliders)
                    RegistryInstance.UnregisterIgnoredCollider(collider);
            }
        }

        private void OnDisable()
        {
            UnregisterColliders();
            UnregisterIgnoredColliders();
        }
    }
}
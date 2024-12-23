using UnityEngine;

namespace ExampleNamespace
{
    public class Example : MonoBehaviour, IExample
    {
        [field: SerializeField] private Collider Collider { get; set; }

        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int ExampleIntValue { get; private set; }

        public void TestGetInfoFromRegistry()
        {
            if (CollidersExampleRegistry.Instance.TryGet(Collider, out var value))
            {
                Debug.Log($"Success! {nameof(Collider)} on gameObject {Collider.name} is present in the registry. It's related with {value.Name} and it's ExampleIntValue = {value.ExampleIntValue}");
            }
            else
            {
                Debug.LogError("Failed to get collider's IExample interface");
            }
        }
    }
}

using RegistrationSystem;

namespace ExampleNamespace
{
    public class CollidersExampleRegister : CollidersRegister<IExample>
    {
        protected override CollidersRegistry<IExample> RegistryInstance => CollidersExampleRegistry.Instance;

        // specific case code if needed
    }
}

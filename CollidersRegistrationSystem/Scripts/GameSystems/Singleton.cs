using UnityEngine;

namespace GameSystems
{
    public class Singleton : MonoBehaviour
    {
        public static bool IsApplicationQuiting { get; private set; } = false;

        protected virtual void OnApplicationQuit()
        {
            IsApplicationQuiting = true;
        }
    }
}

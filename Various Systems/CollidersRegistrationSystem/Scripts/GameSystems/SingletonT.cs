using UnityEngine;

namespace GameSystems
{
    // some simple singleton implementation
    public abstract class Singleton<T> : Singleton where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject($"[Singleton] {typeof(T).Name}");
                        _instance = singletonObject.AddComponent<T>();

                        DontDestroyOnLoad(singletonObject);
                    }
                }
                
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
using UnityEngine;

namespace Demo {
    public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject {
        private static T _instance;
        public static T instance {
            get {
                if (_instance == null) {
                    T[] results = Resources.FindObjectsOfTypeAll<T>();
                    if (results.Length > 0) {
                        _instance = results[0];
                    }
                }

                return _instance;
            }
        }
    }
}

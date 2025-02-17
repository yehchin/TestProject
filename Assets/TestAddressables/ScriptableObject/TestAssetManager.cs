using UnityEngine;

namespace Demo
{
    [CreateAssetMenu(fileName = "TestAssetManager", menuName = "TestAddressables/TestAssetManager")]
    public class TestAssetManager : SingletonScriptableObject<TestAssetManager>
    {
        public TestAsset[] Assets;
    }
}

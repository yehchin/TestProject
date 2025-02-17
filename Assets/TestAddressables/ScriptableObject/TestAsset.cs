using UnityEngine;

namespace Demo
{
    [CreateAssetMenu(fileName = "TestAsset", menuName = "TestAddressables/TestAsset")]
    public class TestAsset : ScriptableObject
    {
        public string Id;
        public GameObject Source;
    }
}

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Demo
{
    public class TestAddressables : MonoBehaviour
    {

        public AssetLabelReference preloadLabel;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        async void Start()
        {

            // var o = await Addressables.LoadAssetAsync<GameObject>("Assets/TestAddressables/ScriptableObject/Cube.prefab").Task;
            var handle = await Addressables.LoadAssetsAsync<TestAsset>(preloadLabel, null).Task;

            if (handle != null)
            {
                for (int i = 0; i < handle.Count; i++)
                {
                    Debug.Log(handle[i].name);
                    if (handle[i].name == "TestAsset1")
                    {
                        Debug.Log(handle[i].Source);
                    }
                }
            }
            // Debug.Log(TestAssetManager.instance.Assets[0].Id);
            // Debug.Log(TestAssetManager.instance.Assets[0].Source);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

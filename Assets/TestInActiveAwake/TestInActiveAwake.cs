using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestInActiveAwake : MonoBehaviour
{
    [SerializeField]
    [ReadOnly]
    private GameObject go;

    private Scene scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // go = GameObject.Find("TestAwake");

        scene = SceneManager.CreateScene("uniqueSceneName", new CreateSceneParameters { localPhysicsMode = LocalPhysicsMode.Physics3D });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var g = Instantiate(go, scene);
            Instantiate(go);
        }
    }
}

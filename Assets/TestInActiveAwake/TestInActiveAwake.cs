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
        // 物件 active 情況
        if (Input.GetKeyDown(KeyCode.A))
        {
            go.SetActive(true);
            GameObject g = Instantiate(go, scene) as GameObject;
            Debug.Log(g.scene.name);
        }
        // 物件 inactive 情況
        if (Input.GetKeyDown(KeyCode.S))
        {
            go.SetActive(false);
            GameObject g = Instantiate(go, scene) as GameObject;
            Debug.Log(g.scene.name);
        }
        // 測試有指定場景跟沒指定場景
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(go, scene);
            Instantiate(go);
        }
    }
}

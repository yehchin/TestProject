using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Demo
{
    public class TestPhysicsScene : MonoBehaviour
    {
        int index = 0;
        const int max = 3;

        List<PhysicsScene> physicsSceneList = new List<PhysicsScene>();

        [SerializeField] GameObject scenePrefab;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && index <= 3)
            {
                CreateSceneParameters createSceneParameters = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
                Scene scene = SceneManager.CreateScene($"DemoPhysicsScene{index}", createSceneParameters);
                GameObject gameObject = Instantiate(scenePrefab);
                SceneManager.MoveGameObjectToScene(gameObject, scene);
                PhysicsScene physicsScene = scene.GetPhysicsScene();
                physicsSceneList.Add(physicsScene);
                index++;
            }
        }

        void FixedUpdate()
        {
            physicsSceneList.ForEach(physicsScene => physicsScene.Simulate(Time.fixedDeltaTime));
        }
    }
}

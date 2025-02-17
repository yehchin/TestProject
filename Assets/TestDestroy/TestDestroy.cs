using UnityEngine;

namespace Demo
{
    public class TestDestroy : MonoBehaviour
    {
        public TestObject testObject;
        private TestModel testModel;

        private GameObject destoryObject;
        private TestObject testObjectInstance;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            TestObject o = Instantiate(testObject, Vector3.zero, Quaternion.identity);
            testModel = new TestModel();
            o.testModel = testModel;
            o.gameObject.SetActive(true);
            destoryObject = o.gameObject;
            testObjectInstance = o;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(testModel);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Destroy(destoryObject);
                Debug.Log(destoryObject);
                Debug.Log(testObjectInstance);
            }
        }
    }
}

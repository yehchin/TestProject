using UnityEngine;

namespace Demo
{
    public class TestManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log(GetComponent<TestInterface>());
            Debug.Log(GetComponent<ITest>());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

using UnityEngine;

namespace Demo
{
    public class TestUUID : MonoBehaviour
    {
        public GameObject _gameObject;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log(_gameObject.GetInstanceID());
            var b = Instantiate(_gameObject);
            Debug.Log(b.GetInstanceID());
            var c = Instantiate(_gameObject);
            Debug.Log(c.GetInstanceID());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

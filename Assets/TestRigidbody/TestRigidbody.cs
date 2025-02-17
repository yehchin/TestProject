using UnityEngine;

namespace Demo
{
    public class TestRigidbody : MonoBehaviour
    {
        public Rigidbody rb;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                // rb.transform.rotation = Quaternion.LookRotation(Vector3.zero);
                Debug.Log(rb.transform.eulerAngles);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.forward * 10);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector3.back * 10);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector3.left * 10);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * 10);
            }

        }
    }
}

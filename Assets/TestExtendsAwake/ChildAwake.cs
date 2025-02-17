using UnityEngine;

namespace Demo
{
    public class ChildAwake : ParentAwake
    {

        void Awake()
        {
            Debug.Log("ChildAwake");
            base.Awake();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Initaliase()
        {
            base.Initaliase();
            Debug.Log("ChildAwake Instantiate");
        }
    }
}

using UnityEngine;

namespace Demo
{
    public class TestExtendsManager : MonoBehaviour
    {
        public ParentAwake parentAwake;
        public ChildAwake childAwake;
        public Transform hideRoot;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ParentAwake instance = Instantiate<ChildAwake>(childAwake, hideRoot);
            instance.Initaliase();

            new ExtendsScript();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

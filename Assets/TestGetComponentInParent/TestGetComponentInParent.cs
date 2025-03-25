using UnityEngine;

public class TestGetComponentInParent : MonoBehaviour
{

    public ParentComponent parentComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentComponent = GetComponentInParent<ParentComponent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

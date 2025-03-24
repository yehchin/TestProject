using UnityEngine;

public class InActiveObject : MonoBehaviour
{

    void Awake()
    {
        Debug.Log(gameObject.scene.name);
        Debug.Log("Awake");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}

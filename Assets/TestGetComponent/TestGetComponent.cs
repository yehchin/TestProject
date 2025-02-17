using System;
using UnityEngine;

namespace Demo
{
    public class TestGetComponent : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            var coms = FindObjectsByType<AComponent>(FindObjectsSortMode.None);
            foreach (var item in coms)
            {
                Debug.Log(item.GetType());
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

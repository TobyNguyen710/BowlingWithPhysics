using UnityEngine;
using UnityEngine.Events;
using System;

public class FallTrigger : MonoBehaviour
{
    //Adding an OnPinFall public event in case any other object
 //needs to know whether a Pin has Fallen i.e. Our GameManager
 public UnityEvent OnPinFall = new();
 public bool isPinFallen = false;
    private void OnTriggerEnter(Collider triggeredObject)
    {
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen");
            // using $"" is C#'s string formatting
            // similar to Python's f-string
            // or Java's String.format()
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

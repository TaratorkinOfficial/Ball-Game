using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private UiController uiController;
    void Start()
    {
            uiController = FindObjectOfType<UiController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiController.Finish();
        }
    }
    void Update()
    {
        
    }
}

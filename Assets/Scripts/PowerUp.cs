using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    private VariablesManager variablesManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            variablesManager = FindObjectOfType<VariablesManager>();
            variablesManager.AddCoins(1);
            Pickup();
        }
    }
    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

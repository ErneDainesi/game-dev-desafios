using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionCollisionManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            playerInventory.AddToInventory(gameObject.tag);
            Destroy(gameObject);
        }
    }
}

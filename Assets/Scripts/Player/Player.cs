using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (GameManager.PlayerHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRaycastManager : MonoBehaviour
{
    [SerializeField] private Transform startPoint, endPoint;
    [SerializeField] private DoorType door;
    [SerializeField] private GameObject enemy;
    private float rayDistance;
    enum DoorType
    {
        Health,
        Enemy
    };

    private void Start()
    {
        rayDistance = (startPoint.position - endPoint.position).magnitude;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(startPoint.position, startPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                CheckDoor();               
            }

        }
    }

    private void CheckDoor()
    {
        switch (door)
        {
            case DoorType.Enemy:
                // Esto no esta funcionando bien
                // Instantiate(enemy, transform.position, transform.rotation);
                GameManager.PlayerHealth -= 50;
                break;
            case DoorType.Health:
                GameManager.PlayerHealth += 100;
                break;
        }
    }
}

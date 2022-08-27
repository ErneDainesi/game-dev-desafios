using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();
    [SerializeField] private PlayerGun playerGun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            playerGun.SetWeapon(GetRandomWeapon());
        }
    }

    public void AddToInventory(string item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item]++;
        }
        else
        {
            inventory.Add(item, 1);
        }
    }

    // Emular abrir inventario
    private void ShowInventory()
    {
        foreach (var item in inventory)
        {
            Debug.Log(item);
        }
    }

    private GameObject GetRandomWeapon()
    {
        int index = Random.Range(0, weapons.Count);
        return weapons[index];
    }
}

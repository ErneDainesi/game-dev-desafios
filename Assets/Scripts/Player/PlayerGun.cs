using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && ammo > 0)
        {
            Shoot();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && ammo == 0)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        ammo--;
    }

    private void Reload()
    {
        ammo = 10;
    }

    public void SetWeapon(GameObject newBullet)
    {
        bullet = newBullet;
    }
}

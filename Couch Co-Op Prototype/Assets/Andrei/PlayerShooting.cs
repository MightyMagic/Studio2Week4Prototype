using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject turret;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject bulletSpawnPoint;

    [SerializeField] int ammoCount;
    [SerializeField] float bulletSpeed;
    void Start()
    {
        ammoText.text = "Ammo left: " + ammoCount;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount > 0)
            Shoot();
    }

    void Shoot()
    {
        ammoCount--;
        ammoText.text = "Ammo left: " + ammoCount;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, turret.transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();    
       // rb.velocity = turret.transform.forward * bulletSpeed;
        rb.AddForce(turret.transform.forward * bulletSpeed, ForceMode.VelocityChange);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject turret;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject bulletSpawnPoint;

    [SerializeField] int ammoCount;
    [SerializeField] float bulletSpeed;
    [SerializeField] AudioSource playerGunAudio;
    [SerializeField] GameObject shotExplosion;

    void Start()
    {
        ammoText.text = "Ammo left: " + ammoCount;
        shotExplosion.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount > 0)
            Shoot();
    }
    void Shoot()
    {

       playerGunAudio.Play();
       StartCoroutine(ExplosiveParticle());

        ammoCount--;
        ammoText.text = "Ammo left: " + ammoCount;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, turret.transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();    

        rb.AddForce(turret.transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    IEnumerator ExplosiveParticle()
    {
        shotExplosion.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        shotExplosion.SetActive(false);
    }

    public void ChangeAmmo(int amount)
    {
        ammoCount += amount;
        ammoText.text = "Ammo left: " + ammoCount;
    }
}

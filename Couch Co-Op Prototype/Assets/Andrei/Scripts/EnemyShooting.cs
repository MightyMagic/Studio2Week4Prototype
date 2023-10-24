using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] float distanceToShoot;

    [SerializeField] int ammoCount;
    [SerializeField] float bulletSpeed;
    [SerializeField] AudioSource playerGunAudio;
    [SerializeField] GameObject shotExplosion;

    GameObject player;
    [SerializeField] float delayBetweenShots;
    float timer = 0f;

    void Start()
    {
        shotExplosion.SetActive(false);
        player = GameObject.Find("CarObject");
    }

    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < distanceToShoot)
        {
            if(timer > delayBetweenShots)
            {
                timer = 0f;
                Shoot();
            }
            else
            {
                timer += Time.deltaTime;
            }          
        }
    }

    void Shoot()
    {
        playerGunAudio.Play();
        StartCoroutine(ExplosiveParticle());


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
}

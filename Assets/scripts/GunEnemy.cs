using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    private float timer = 1f;
    private float bulletTime;

    public Transform spawnPoint;
    public GameObject enemyBullet;
    public float enemySpeed;


    // Update is called once per frame
    void Update()
    {
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0)
            return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletRig, 5f);
    }
}

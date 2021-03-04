using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    private float timeUntilFire;
    private PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (PlayerMovement.canShoot == true)
        {
            Debug.Log("Able to shoot");
            if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
            {
                Shoot();
                Debug.Log("Shoot");
                timeUntilFire = Time.time + fireRate;
            }
        }
        
    }

    private void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}

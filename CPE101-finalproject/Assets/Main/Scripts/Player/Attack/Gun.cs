using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;

    private float nextFire;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Range);
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation * Quaternion.Euler(0, 0, -90));
    }
}

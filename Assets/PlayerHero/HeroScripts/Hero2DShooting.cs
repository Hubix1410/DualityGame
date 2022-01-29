using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2DShooting : MonoBehaviour
{

    public GameObject BulletPrefab;
    public Transform FirePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}



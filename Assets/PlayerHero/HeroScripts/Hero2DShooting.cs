using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2DShooting : MonoBehaviour
{

    public GameObject BulletPrefab;
    public Transform FirePoint;

    public Hero2DController heroControllerScript;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") || heroControllerScript.CurrentState == 1)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}



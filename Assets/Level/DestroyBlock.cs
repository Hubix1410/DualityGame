﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{

    public LayerMask bulletLayer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

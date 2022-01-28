﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2DController : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpForce = 5f;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
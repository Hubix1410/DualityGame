using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2DController : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpForce = 5f;

    public GameObject HeroObject;

    private int RotationDirection;
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

        IsGrounded();
        RotationCheck();
    }

    void RotationCheck()
    {
        if (Input.GetKeyDown(KeyCode.A) && RotationDirection == 0)
        {
            HeroObject.transform.Rotate(0, 180, 0);
            RotationDirection = 1;
        }

        if (Input.GetKeyDown(KeyCode.D) && RotationDirection == 1)
        {
            HeroObject.transform.Rotate(0, 180, 0);
            RotationDirection = 0;
        }
    }

    private bool IsGrounded() {
        return true;
    }
}

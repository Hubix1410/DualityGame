using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2DController : MonoBehaviour
{
    // 1 is bright
    // 0 is dark
    public int CurrentState = 1;

    public GameObject BulletPrefab;
    public Transform FirePoint;

    public float MovementSpeed = 5f;
    public float JumpForce = 5f;
    public int amountOfJumps;
    private int RotationDirection;

    public GameObject HeroObject;
    private Rigidbody2D _rigidbody;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform gorundCheck;

    public Animator animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeState();
        }

        if (Input.GetButtonDown("Fire1") && CurrentState == 1)
        {
            Shoot();
        }

        RotationCheck();
    }


    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        isGrounded = Physics2D.OverlapCircle(gorundCheck.position, 0.2f, groundLayer);

        if (isGrounded == true)
        {
            amountOfJumps = 0;
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
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

    void Jump()
    {
        switch (CurrentState)
        {
            case 0:
                if (isGrounded)
                {
                    _rigidbody.velocity = Vector2.up * JumpForce;
                    amountOfJumps++;
                }
                break;
            case 1:
                if (amountOfJumps < 1 || isGrounded)
                {
                    _rigidbody.velocity = Vector2.up * JumpForce;
                    amountOfJumps++;
                }
                break;
        }
    }

    void ChangeState()
    {
        switch (CurrentState)
        {
            case 0:
                CurrentState = 1;
                break;
            case 1:
                CurrentState = 0;
                break;
        }
        Debug.Log(CurrentState);
    }
}

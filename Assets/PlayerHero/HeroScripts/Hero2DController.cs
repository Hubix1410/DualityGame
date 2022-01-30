using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero2DController : MonoBehaviour
{
    // 1 is bright
    // 0 is dark
    public int CurrentState = 1;
    public int amountOfJumps;
    public int RotationDirection;

    public LayerMask groundLayer;
    public LayerMask spikeLayer;
    public LayerMask endLayer;

    public GameObject BulletPrefab;
    public GameObject HeroObject;

    public Rigidbody2D _rigidbody;

    public Transform FirePoint;
    public Transform spikesCheck;
    public Transform spawnPoint;
    public Transform gorundCheck;

    public float MovementSpeed = 5f;
    public float JumpForce = 5f;

    public bool isGrounded;
    public bool isTouchingSpikes;
    public bool endGame;

    public SpriteRenderer spriteRenderer;

    public Sprite BlackBox;
    public Sprite WhiteBox;

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

        if (Input.GetButtonDown("Fire1") && CurrentState == 0)
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

        isTouchingSpikes = Physics2D.OverlapCircle(spikesCheck.position, 0.6f, spikeLayer);

        if (isTouchingSpikes == true)
        {
            ReturnToSpawn();
        }

        endGame = Physics2D.OverlapCircle(spikesCheck.position, 0.6f, endLayer);

        if (endGame == true)
        {
            EndGame();
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
                spriteRenderer.sprite = BlackBox;
                break;
            case 1:
                CurrentState = 0;
                spriteRenderer.sprite = WhiteBox;
                break;
        }
        Debug.Log(CurrentState);
    }

    void ReturnToSpawn()
    {
        gameObject.transform.position = spawnPoint.transform.position;
    }

    void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

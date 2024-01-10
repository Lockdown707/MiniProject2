using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Turning")]
    public float turnSpeed = 10f;
    public float horizontalInput;
    [Header("Forward")]
    public float speed = 20f;
    public float forwardInput;
    [Header("Shooting")]
    public GameObject projectile;
    public GameObject bulletSpawn;
    [Header("Jumping")]
    public float jumpForce;
    public bool isOnGround = true;
    [Header("Components")]
    //Rigidbody
    private Rigidbody rb;
    //Animator
    public Animator animator;
    //GameManager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Move Forward on vertical axis
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Turning on horizontal axis
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //Shooting
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectile, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
        //Jumping
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            animator.SetBool("isOnGround", isOnGround);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("isOnGround", isOnGround);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Add Death annimation here
            Destroy(gameObject);
            //gameManager.UpdateScore(1);
        }
    }
    }

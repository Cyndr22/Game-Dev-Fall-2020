using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    float horizontal;
    float vertical;

    public float moveSpeed = 20.0f;
    public float maxHealth;
    public float health;
    public float points;

    public GunController gun;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(-horizontal, 0f, -vertical);
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 lookPoint = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z));
        }

        gun.shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetMouseButtonUp(0))
        {
            gun.shooting = false;
        }

        if (health <= 0)
        {
            Die();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        body.velocity = moveVelocity;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            body.velocity = Vector3.zero;
        }
    }

    public void Die() 
    {
        Application.Quit();
    }
}

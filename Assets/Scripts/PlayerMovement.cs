using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 400;
    float currentSpeed;

    public float rotationSpeed = 10;
    float h, v;

    Rigidbody2D body;

    float modifierLastsfor = 0;
    bool modifierActive = true;
    float elapsed = 0;

    public string HorizontalInputName = "Horizontal";
    public string VerticalInputName = "Vertical";
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = movementSpeed;
    }

    
    void Update()
    {
        if (modifierActive)
        {
            elapsed += Time.deltaTime;

            if (elapsed >= modifierLastsfor)
            {
                modifierActive = false;
                currentSpeed = movementSpeed;
                elapsed = 0;
            }
        }
        h = Input.GetAxisRaw(HorizontalInputName);
        v = Input.GetAxisRaw(VerticalInputName);

        transform.Rotate(0, 0, -h * rotationSpeed);

        
    }

    private void FixedUpdate()
    {
        body.velocity = transform.up * v * currentSpeed * Time.deltaTime;
    }
     private void OnTriggerEnter2D(Collider2D Collision)
    {
        UpdatePlayer(Collision);
    }
    private void OnTriggerStayr2D(Collider2D collision)
    {
        UpdatePlayer(collision);
    }
   

    private void UpdatePlayer(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Modifier"))
        {
            SpeedModifier speedModifier = collision.gameObject.GetComponent<SpeedModifier>();
            modifierLastsfor = speedModifier.lastFor;
            modifierActive = true;
            elapsed = 0;
        }
    }
}

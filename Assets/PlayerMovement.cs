using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 3.0f;
    public float jumpSpeed = 7.0f;
    Vector3 respawnPos;
    public Health playerHealth;

    bool inAir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = rb.velocity;

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            movement.x = moveSpeed;
            GetComponent<SpriteRenderer>().flipX = false;

            if (inAir == false)
            {
                GetComponent<Animator>().SetBool("running", true);
            }
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            movement.x = -moveSpeed;
            GetComponent<SpriteRenderer>().flipX = true;
            if (inAir == false)
            {
                GetComponent<Animator>().SetBool("running", true);
            }
        }
        else 
        {
            movement.x = 0;
            GetComponent<Animator>().SetBool("running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) {
            movement.y = jumpSpeed;
            GetComponent<Animator>().SetBool("jumping", true);
            inAir = true;
        }

        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Hit object named: " + collision.gameObject.name);

        GetComponent<Animator>().SetBool("jumping", false);
        inAir = false;

        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (rb.velocity.y < 0)
            {
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else
            {
                transform.position = respawnPos;
            }
        }

        if (collision.gameObject.CompareTag("Enemy")) 
        {
            playerHealth.TakeDamage(1);
        }
    }
}

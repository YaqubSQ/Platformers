using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 3.0f;
    public float jumpSpeed = 7.0f;
    Vector3 respawnPos;

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

        if (Input.GetKey(KeyCode.RightArrow)) {
            movement.x = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            movement.x = -moveSpeed;
        }
        else {
            movement.x = 0;
        }

        //velocity.y must be greater than a small negative value like -0.01
        //AND must be less than a small positive value like 0.01

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > -0.01f && rb.velocity.y < 0.01f) {
            movement.y = jumpSpeed;
        }

        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Hit object named: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy")) {

            if (rb.velocity.y < 0) {
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else {
                transform.position = respawnPos;
            }
        }
    }
}

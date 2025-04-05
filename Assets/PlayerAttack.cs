using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform melleeCheck;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    private void Attack()
    {
        Collider2D collision = Physics2D.OverlapCircle(melleeCheck.position, 1, enemyLayer); 
        if (collision != null)
        {
            Debug.Log("Player hit enemy: " + collision.gameObject.name);
                
        }
    }
}

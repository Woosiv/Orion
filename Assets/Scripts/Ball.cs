using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Collider2D self;
    public GameObject player;
    public float velocity = 3f;
    public Sprite playerProjectile;
    void Start()
    {
        rb.velocity = new Vector2(0, -10); 
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(6, 6);
        Physics2D.IgnoreLayerCollision(6, 8);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) {
            Debug.Log("Oof ow I'm hurt");
            if (player) {
                player.GetComponent<Player>().takeDamage(1);
            }
            Destroy(gameObject);
        }
        if (transform.position.y > 6) 
            Destroy(gameObject);
    }
    
    void FixedUpdate() {
        rb.velocity = rb.velocity.normalized * velocity;

        
        // Handles direction for the ball after physics interactions
        float movX = rb.velocity.x;
        float movY = rb.velocity.y;
        float theta;
        if (movX != 0)
            theta = Mathf.Tan(movY/-movX);
        else
            theta = 0f;
        rb.rotation = theta * Mathf.Rad2Deg;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Output the Collider's GameObject's name
        if (collision.gameObject.tag == "Player") {
            float diff = gameObject.transform.position.x - collision.gameObject.transform.position.x;
            if (diff < 0) 
                rb.velocity = new Vector2(Math.Abs(rb.velocity.x) * -1, rb.velocity.y); 
            else 
                rb.velocity = new Vector2(Math.Abs(rb.velocity.x), rb.velocity.y); 
            gameObject.tag = "Projectile";
            gameObject.layer = 10;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerProjectile;
        }
    }
}

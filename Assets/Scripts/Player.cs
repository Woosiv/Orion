using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10000f;
    public Rigidbody2D self;
    public float maxVelocity = 10f;
    public GameObject healthBar;
    public int health;
    public int leftScreenEdge = -5;
    public int rightScreenEdge = 5;
    public int botScreenEdge = -5;
    public int topBoundary = -3;

    // Start is called before the first frame update
    void Start()
    {
        health = 18;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Debug.Log("I'm dead :(");
            // Debug.Log(player.health);
            Destroy(gameObject);
        }
        // if (transform.position.x < leftScreenEdge)
        // {
        //     transform.position = new Vector2(leftScreenEdge, transform.position.y);
        // }
        // else if (transform.position.x > rightScreenEdge)
        // {
        //     transform.position = new Vector2(rightScreenEdge, transform.position.y);
        // }

        // // Make sure player can't leave the top boundary
        // if (transform.position.y > topBoundary)
        // {
        //     transform.position = new Vector2(transform.position.x, topBoundary);
        // }

        // // Make sure player can't leave the bottom portion of the screen
        // else if (transform.position.y < botScreenEdge)
        // {
        //     transform.position = new Vector2(transform.position.x, botScreenEdge);
        // }
        // transform.position = Vector2.MoveTowards(transform.position, pos, maxDist);
    }
    
    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Vector2 pos = transform.position;
        Vector2 newVel = new Vector2(0,0);
        // Vector2 sum = new Vector2(0,0);
        newVel.x += h * speed * Time.deltaTime;
        newVel.y += v * speed * Time.deltaTime;
        if (h == 0)
            newVel.x = 0f;
        if (v == 0)
            newVel.y = 0f;
        self.velocity = newVel;
    }

    public void takeDamage(int damage) {
        health -= damage;
        healthBar.GetComponent<healthBar>().takeDamage(damage);
    }
}

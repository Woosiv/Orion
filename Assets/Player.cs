using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10000f;
    public Rigidbody2D self;
    public float maxVelocity = 10f;
    public GameObject healthBar;
    // Start is called before the first frame update
    public int health;
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

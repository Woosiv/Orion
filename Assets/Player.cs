using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10000f;
    public Rigidbody2D self;
    public float maxDist = 10f;
    
    // Start is called before the first frame update
    public int health = 10;
    void Start()
    {
        health = 10;
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
        Vector2 pos = new Vector2(0,0);
        // Vector2 sum = new Vector2(0,0);
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;
        if (h == 0)
            pos.x = 0f;
        if (v == 0)
            pos.y = 0f;
        self.velocity = pos;
    }
}

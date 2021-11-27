using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaceholder : MonoBehaviour
{
    public Rigidbody2D self;
    public float velocity;
    private int currHealth;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
        // Debug.Log(Physics2D.GetIgnoreLayerCollision(8,8));
        self = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(6, 9);
        self.velocity = new Vector2(-1f, .35f).normalized * velocity;
        currHealth = GameObject.FindGameObjectsWithTag("Blocks").Length;
        healthBar.GetComponent<healthBar>().currHealth = currHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage) {
        currHealth -= damage;
        healthBar.GetComponent<healthBar>().takeDamage(damage);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("How?");
        Debug.Log(collision.collider.gameObject.layer);
    }
}

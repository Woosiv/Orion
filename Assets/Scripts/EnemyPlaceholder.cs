using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaceholder : MonoBehaviour
{
    public Rigidbody2D self;
    public float velocity;
    private int currHealth;
    public GameObject healthBar;
    public GameObject currBullet;
    public GameObject bullet;
    public bool attack;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody2D>();
        healthBar = GameObject.FindGameObjectsWithTag("EnemyHealth")[0];
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(6, 9);
        self.velocity = new Vector2(-1f, .35f).normalized * velocity;
        currHealth = GameObject.FindGameObjectsWithTag("Blocks").Length;
        healthBar.GetComponent<healthBar>().currHealth = currHealth;
        healthBar.GetComponent<healthBar>().setUp();

    }

    // Update is called once per frame
    void Update()
    {
        if (attack && currBullet == null)
        {
            currBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            currBullet.GetComponent<Ball>().rb.velocity = new Vector2(0, -10);
            // bulletCount++;
        }
    }

    public void takeDamage(int damage) {
        currHealth -= damage;
        healthBar.GetComponent<healthBar>().takeDamage(damage);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.gameObject.name.Contains("t Border")){
            gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
        }
    }
}

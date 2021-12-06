using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpiusBehavior : MonoBehaviour
{
    public Rigidbody2D self;
    public float velocity;
    private int currHealth;
    public GameObject healthBar;
    public GameObject currBullet;
    public GameObject bullet;
    public bool attack;
    public GameObject bossForm;
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
        StartCoroutine(AttackPatterns());

    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth == 0) {
            bossForm.SetActive(true);
            Destroy(gameObject);
        }
        // if (attack && currBullet == null)
        // {
        //     currBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        //     currBullet.GetComponent<Ball>().rb.velocity = new Vector2(0, -10);
        //     // bulletCount++;
        // }
    }

    IEnumerator AttackPatterns() {
        // Debug.Log("Hello");
        while (currHealth > 0) {
            // Debug.Log("Hey");
            int move = Random.Range(0, 1);
            switch (move) {
                case 0:
                    yield return ClawAttack(.15f);
                    break;
            }
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator ClawAttack(float seconds) {
        Debug.Log("Starting Claw Attack");
        int claw = Random.Range(0, 2);
        velocity /= 2;
        for (int i = 0; i < 2; i++) {
            // Debug.Log("creating a bullet");
            GameObject temp;
            Vector2 dir = Vector2.right;
            temp = Instantiate(bullet, transform.position, Quaternion.identity);
            dir = Vector2.down + (Random.Range(0f, .4f)*Vector2.right);
            temp.GetComponent<Ball>().rb.velocity = dir;
            yield return new WaitForSeconds(seconds);
        }
        velocity *= 2;
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

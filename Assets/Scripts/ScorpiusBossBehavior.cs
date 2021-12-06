using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpiusBossBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    public Rigidbody2D self;
    public int moves = 1;
    public float velocity = 3f;
    private System.Action[] test;
    public int maxHealth;
    public int currHealth;
    public GameObject healthBar;
    void Start()
    {
        transform.position = new Vector3(0f, 2f, -1f);
        self.velocity = new Vector2(-1f, .5f).normalized * 3f;
        currHealth = 30;
        healthBar = GameObject.FindGameObjectsWithTag("EnemyHealth")[0];
        healthBar.GetComponent<healthBar>().currHealth = currHealth;
        healthBar.GetComponent<healthBar>().setUp();
        StartCoroutine(AttackPatterns());
        
    }

    void FixedUpdate() {
        if (currHealth <= 0) 
            Destroy(gameObject);
        if (Mathf.Round(self.velocity.y) == 0) {
            self.velocity = new Vector2(self.velocity.x, 1f);
        }
        if (Mathf.Round(self.velocity.x) == 0) {
            self.velocity = new Vector2(1, self.velocity.y);
        }
        self.velocity = self.velocity.normalized * velocity;
    }

    IEnumerator AttackPatterns() {
        // Debug.Log("Hello");
        while (currHealth > 0) {
            // Debug.Log("Hey");
            int move = Random.Range(0, 3);
            switch (move) {
                case 0:
                    yield return ClawAttack(.15f);
                    break;
                case 1:
                    yield return FoamAttack(.25f);
                    break;
                case 2:
                    yield return TailAttack(.1f);
                    break;
            }
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator ClawAttack(float seconds) {
        Debug.Log("Starting Claw Attack");
        int claw = Random.Range(0, 2);
        velocity /= 2;
        for (int i = 0; i < 7; i++) {
            // Debug.Log("creating a bullet");
            GameObject temp;
            Vector2 dir = Vector2.right;
            switch (claw) {
                // Right Claw
                case 0:
                    temp = Instantiate(bullet, new Vector2(transform.position.x + .5f, transform.position.y - 1.5f), Quaternion.identity);
                    dir = Vector2.down + (Random.Range(0f, .4f)*Vector2.right);
                    temp.GetComponent<Ball>().rb.velocity = dir;
                    break;
                // Left Claw
                case 1:
                    temp = Instantiate(bullet, new Vector2(transform.position.x - .5f, transform.position.y - 1.5f), Quaternion.identity);
                    dir = Vector2.down + (Random.Range(0f, .4f)*Vector2.left);
                    temp.GetComponent<Ball>().rb.velocity = dir;
                    break;
            }
            yield return new WaitForSeconds(seconds);
        }
        velocity *= 2;
    }

    IEnumerator FoamAttack(float seconds) {
        Debug.Log("Starting Foam Attack");
        velocity /= 2.5f;
        for (int i = 0; i < 7; i++) {
            GameObject temp = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y - 1f), Quaternion.identity);
            Vector2 dir = Vector2.down + (Random.Range(-.25f, .25f)*Vector2.right);
            temp.GetComponent<Ball>().rb.velocity = dir;
            temp.GetComponent<Ball>().velocity *= .7f;
            yield return new WaitForSeconds(seconds);
        }
        velocity *= 2.5f;
    }

    IEnumerator TailAttack(float seconds){
        Debug.Log("Starting Tail Attack");
        Vector2 reference = self.velocity;
        Vector2 dir = Vector2.down + (Random.Range(-.5f,.5f)*Vector2.right);
        velocity = 0f;
        for (int i = 0; i < 7; i++) {
            GameObject temp = Instantiate(bullet, new Vector2(transform.position.x - .2f, transform.position.y + 1f), Quaternion.identity);
            temp.GetComponent<Ball>().rb.velocity = dir;
            // temp.GetComponent<Ball>().velocity *= .7f;
            yield return new WaitForSeconds(seconds);
        }
        velocity = 3f;
        self.velocity = reference;
    }

    void takeDamage(int damage) {
        currHealth -= damage;
        healthBar.GetComponent<healthBar>().takeDamage(damage);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(Physics.GetIgnoreLayerCollision(9,10));
        if (collision.gameObject.tag == "Projectile") {
            Debug.Log("Hello?");
            takeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}

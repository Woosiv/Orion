using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    public int moves = 1;
    public float velocity = 3f;
    private System.Action[] test;
    public int maxHealth;
    public int currHealth;
    void Start()
    {
        transform.position = new Vector3(0f, 2f, -1f);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, .5f).normalized * 3f;
        currHealth = 10;
        StartCoroutine(AttackPatterns());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moves > 0) {
            moves--;
            // StartCoroutine(BeamAttack(.25f));
        }
    }

    void FixedUpdate() {
        gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized * velocity;
    }

    IEnumerator AttackPatterns() {
        Debug.Log("Hello");
        while (currHealth > 0) {
            Debug.Log("Hey");
            yield return BeamAttack(.15f);
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator BeamAttack(float seconds) {
        Debug.Log("Starting Beam Attack");
        velocity /= 2;
        for (int i = 0; i < 7; i++) {
            // Debug.Log("creating a bullet");
            GameObject temp = Instantiate(bullet, new Vector2(transform.position.x + .5f, transform.position.y - 1.5f), Quaternion.identity);
            Vector2 dir = Vector2.down + (Random.Range(0f, .4f)*Vector2.right);
            Debug.Log(dir);
            temp.GetComponent<Ball>().rb.velocity = dir;
            // Debug.Log("Set the value of temp");
            // Debug.Log(temp.GetComponent<Ball>().rb.velocity);
            yield return new WaitForSeconds(seconds);
        }
        velocity *= 2;
    }

    // IEnumerator FoamAttack(float seconds) {

    // }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     Debug.Log(collision.gameObject.tag);
    // }
    // IEnumerator 
}

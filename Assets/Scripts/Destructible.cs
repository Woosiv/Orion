using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int hitCount = 1;
    public int bulletCount = 0;
    public GameObject bullet;
    public bool attack;
    public GameObject currBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attack && currBullet == null)
        {
            currBullet = Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
            bulletCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Projectile") {
            hitCount--;
            Destroy(collision.gameObject);
            if (hitCount == 0) { 
                GameObject.Find("Enemy").GetComponent<EnemyPlaceholder>().takeDamage(1);
                Destroy(gameObject);
            }
        }
        
    }
}

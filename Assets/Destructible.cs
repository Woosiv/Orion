using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int hitCount = 1;
    public int bulletCount = 0;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCount == 0)
        {
            Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
            bulletCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("hoi");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Projectile") {
            hitCount--;
            Debug.Log("im here");
            // Destroy(collision.gameObject);
            if (hitCount == 0) 
                Destroy(gameObject);

        }
        
    }
}

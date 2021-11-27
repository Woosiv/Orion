using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaceholder : MonoBehaviour
{
    public Rigidbody2D self;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
        // Debug.Log(Physics2D.GetIgnoreLayerCollision(8,8));
        self = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(6, 6);
        self.velocity = new Vector2(-1f, .45f).normalized * velocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

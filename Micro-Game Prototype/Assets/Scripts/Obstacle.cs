using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IPooledObject
{
    public float speed = 10.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }
}

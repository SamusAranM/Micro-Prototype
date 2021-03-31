using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, IPooledObjects
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // start is called before the first frame update
    public void OnObjectSpawn()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0); // make the obstacle go from right to left

        //  it said somewhere not to use Camera.main but not sure if it only applied to repeated use
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < screenBounds.x * 2) // checks to see if the prefab is out of view
        {
            Debug.Log("Out of the screen");
        }
    }
}

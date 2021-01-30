using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateForward : MonoBehaviour
{

    public Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        vel = transform.GetComponent<Rigidbody2D>().velocity;
        transform.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg - 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

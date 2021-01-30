using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateForward : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector2 vel = transform.GetComponent<Rigidbody2D>().velocity;
        transform.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg - 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

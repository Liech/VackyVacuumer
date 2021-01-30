using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : IFireable
{
  public float StartVelocity = 5;
  public GameObject Bullet;
  public float spawnDistance = 0.4f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public override void fire()
  {
    float angle = Mathf.PI * transform.GetComponent<Rigidbody2D>().rotation / 180.0f;
    Vector2 dir = new Vector2(Mathf.Sin(-angle), Mathf.Cos(-angle)) * spawnDistance;

    GameObject g = Instantiate(Bullet,transform.position + new Vector3(dir.x,dir.y,0),transform.rotation);
    g.GetComponent<Rigidbody2D>().velocity = dir * StartVelocity;
  }
}
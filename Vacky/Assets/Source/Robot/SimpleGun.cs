using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : IFireable
{
  public float StartVelocity = 5;
  public GameObject Bullet;
  public float spawnDistance = 0.4f;
  public GameObject fireSound;

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

    float angle = Mathf.PI * transform.parent.GetComponent<Rigidbody2D>().rotation / 180.0f;
    Vector2 dir = new Vector2(Mathf.Sin(-angle), Mathf.Cos(-angle)) * spawnDistance;

    GameObject g = Instantiate(Bullet,transform.parent.position + new Vector3(dir.x,dir.y,0),transform.parent.rotation);
    g.GetComponent<Rigidbody2D>().velocity = dir * StartVelocity;
    if (fireSound) Instantiate(fireSound);
  }
}

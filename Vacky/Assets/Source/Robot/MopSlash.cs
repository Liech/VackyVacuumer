using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopSlash : IFireable
{
  public float rotateSpeed = 200;
  public float stunDuration = 0.5f;

  public override void fire()
  {
    transform.parent.GetComponent<WASD>().stun(stunDuration);
    transform.parent.GetComponent<Rigidbody2D>().angularVelocity = rotateSpeed;
  }
}

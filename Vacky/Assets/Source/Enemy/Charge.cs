using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : IController
{
  public float speed = 10;
  public float rotationSpeed = 30;
  public float angleTolerance = 5;
  public GameObject SoundOnCharge;

  GameObject target;
  bool charge = false;

  // Update is called once per frame
  void FixedUpdate()
  {
    if (target && !charge)
    {
      float angle = Mathf.PI * transform.GetComponent<Rigidbody2D>().rotation / 180.0f;
      Vector3 targetDir = target.transform.position - transform.position;
      Vector3 currentDir = new Vector2(Mathf.Sin(-angle), Mathf.Cos(-angle));
      float delta = Vector2.SignedAngle(currentDir, targetDir);
      if (delta < -rotationSpeed)
        delta = -rotationSpeed;
      if (delta > rotationSpeed)
        delta = rotationSpeed;
      transform.GetComponent<Rigidbody2D>().angularVelocity = delta;
      if (Mathf.Abs(delta) < angleTolerance)
      {
        charge = true;
        if (SoundOnCharge) Instantiate(SoundOnCharge);
      }
      Debug.Log(delta);
    }
    if (charge)
    {
      float angle = Mathf.PI * transform.GetComponent<Rigidbody2D>().rotation / 180.0f;
      transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sin(-angle) * speed, Mathf.Cos(-angle) * speed);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<WASD>())
    {
      target = collision.gameObject;
    }
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<WASD>())
    {
      target = collision.gameObject;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    target = null;
    charge = false;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    charge = false;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveBonkTurn : IController, IStunnable
{
  public Vector2 currentDirection = new Vector2(1, 0);
  public float MoveSpeed = 1;
  private bool _isStunned = false;
  

  void Start()
  {
    currentDirection.Normalize();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (_isStunned)
      return;
    Vector2 vel = currentDirection * MoveSpeed;
    GetComponent<Rigidbody2D>().velocity = vel;
    GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg - 90;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    currentDirection *= -1;
    //Vector3 s = transform.localScale;
    //s.x *= -1;
    //transform.localScale = s;
    //GetComponentInChildren<SpriteRenderer>().flipX = !GetComponentInChildren<SpriteRenderer>().flipX;
  }

  public void stun(float seconds)
  {
    StopAllCoroutines();
    _isStunned = true;
    StartCoroutine("stopStun", seconds);
  }

  private IEnumerator stopStun(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    _isStunned = false;
  }
}

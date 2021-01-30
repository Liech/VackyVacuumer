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
    
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (_isStunned)
      return;
    GetComponent<Rigidbody2D>().velocity = currentDirection * MoveSpeed;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    currentDirection *= -1;
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

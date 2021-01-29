using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveBonkTurn : MonoBehaviour, IStunnable
{
  public Vector2 currentDirection = new Vector2(1, 0);
  public float MoveSpeed = 1;
  public float stunTime = 3;
  public int   damage = 20;
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
    Debug.Log("Bonk");
    currentDirection *= -1;

    IStunnable stunnable;
    if (collision.gameObject.transform.TryGetComponent<IStunnable>(out stunnable))
      stunnable.stun(stunTime);
    Life l;
    if (collision.gameObject.transform.TryGetComponent<Life>(out l))
      l.addDamage(damage);

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

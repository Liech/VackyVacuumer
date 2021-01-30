using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : IController , IStunnable
{
  public float Speed = 1.0f;
  public float RotationSpeed = 1.0f;
  public float BackwardsDrive = 1.0f;

  private bool _isStunned = false;

  // Start is called before the first frame update
  void Start()
  {
    Singleton.instance.protagonist = gameObject;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (_isStunned)
      return;

    bool w = Input.GetKey(KeyCode.W);
    bool a = Input.GetKey(KeyCode.A);
    bool s = Input.GetKey(KeyCode.S);
    bool d = Input.GetKey(KeyCode.D);

    float xSpeed = -((a ? -1.0f : 0) * BackwardsDrive + (d ? 1.0f : 0)) * RotationSpeed;
    float ySpeed = (s ? -1.0f : 0) + (w ? 1.0f : 0)*Speed;

    transform.GetComponent<Rigidbody2D>().angularVelocity = xSpeed;
    float angle = Mathf.PI * transform.GetComponent<Rigidbody2D>().rotation / 180.0f;
    transform.GetComponent<Rigidbody2D>().velocity = new Vector2( Mathf.Sin(-angle) * ySpeed, Mathf.Cos(-angle) * ySpeed);
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

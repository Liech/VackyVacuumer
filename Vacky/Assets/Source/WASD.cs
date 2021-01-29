using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
  public float Speed;

  private bool _isStunned = false;

  // Start is called before the first frame update
  void Start()
  {
      
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

    float xSpeed = (a ? -1.0f : 0) + (d ? 1.0f : 0);
    float ySpeed = (s ? -1.0f : 0) + (w ? 1.0f : 0);

    //transform.GetComponent<Rigidbody2D>().angularVelocity = 
    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed,ySpeed);
  }

  public void stun(float seconds)
  {
    StopAllCoroutines();
    _isStunned = true;
    StartCoroutine("stopStun");
  }

  private IEnumerator stopStun(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    _isStunned = false;
  }
}

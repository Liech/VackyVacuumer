using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socialize : MonoBehaviour
{
  GameObject target;
  bool pressede = false;
  public void FixedUpdate()
  {
    bool e = Input.GetKey(KeyCode.E);
    if (e && !Singleton.instance.blockInput && target && !pressede)
    {
      target.GetComponents<CanTalk>()[0].talk();
      pressede = true;
    }
    else if (!e && pressede && !Singleton.instance.blockInput)
      pressede = false;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<CanTalk>())
    {
      target = collision.gameObject;
      transform.Find("EKey").GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    target = null;
    transform.Find("EKey").GetComponent<SpriteRenderer>().enabled = false;
  }
}

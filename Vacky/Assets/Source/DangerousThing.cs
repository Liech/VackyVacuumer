using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousThing : MonoBehaviour
{
  public int Damage = 15;
  public int Stun   = 4;
  public bool On = true;
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (!On)
      return;
    if (collision.gameObject.GetComponent<Life>())
    {
      collision.gameObject.GetComponent<Life>().addDamage(Damage);
    }
    IStunnable stunnable;
    if (collision.gameObject.transform.TryGetComponent<IStunnable>(out stunnable))
    {
      stunnable.stun(Stun);
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousThing : MonoBehaviour
{
  public int Damage = 15;
  public int Stun   = 4;
  public bool On = true;
  public bool feuchteReinigung = false;
  public DamageCategory damageType = DamageCategory.BonkDamage;
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (!On)
      return;
    if (collision.collider.gameObject.GetComponent<Life>())
    {
      collision.collider.gameObject.GetComponent<Life>().addDamage(Damage, damageType);
    }
    IStunnable stunnable;
    if (collision.collider.gameObject.transform.TryGetComponent<IStunnable>(out stunnable))
    {
      stunnable.stun(Stun);
    }
  }
}

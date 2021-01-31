using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnCollision : MonoBehaviour
{
  public bool explosion = true;
  public float explosionRadius = 0.3f;

  void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(gameObject); 
    if(explosion)
      TileGrenade.explode(transform.position, explosionRadius, Singleton.instance.explosionDreck, true);
  }
}

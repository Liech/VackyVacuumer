using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BonkOnCollision : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.GetComponent<Tilemap>())
      SoundSingleton.instance.playBonk(transform);
  }
}

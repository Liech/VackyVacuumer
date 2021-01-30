using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IsDreckMap : MonoBehaviour
{
  void Start()
  {
    Singleton.instance.DirtTileMaps.Add(GetComponent<Tilemap>());
  }

  void OnDestroy()
  {
    Singleton.instance.DirtTileMaps.Remove(GetComponent<Tilemap>());
  }
}

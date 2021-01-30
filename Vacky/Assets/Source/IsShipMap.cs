using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IsShipMap : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Singleton.instance.ShipTileMaps.Add(GetComponent<Tilemap>());
  }

  void OnDestroy()
  {
    Singleton.instance.ShipTileMaps.Remove(GetComponent<Tilemap>());
  }

}

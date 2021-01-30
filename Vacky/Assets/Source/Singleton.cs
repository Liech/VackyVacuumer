using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Singleton : MonoBehaviour
{
  public static Singleton instance;

  public HashSet<Tilemap> DirtTileMaps;
  public HashSet<Tilemap> ShipTileMaps;

  // Start is called before the first frame update
  public Singleton() 
  {
    DirtTileMaps = new HashSet<Tilemap>();
    ShipTileMaps = new HashSet<Tilemap>();
    instance = this;
  }

  // Update is called once per frame
  void Update()
  {

  }
}

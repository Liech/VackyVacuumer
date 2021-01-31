using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Singleton : MonoBehaviour
{
  public static Singleton instance;

  public HashSet<Tilemap> DirtTileMaps;
  public HashSet<Tilemap> ShipTileMaps;
  public HashSet<IsEnemy> Enemys;
  public LifeBar lifebar;
  public AmmoBar dreckbar;
  public GameObject protagonist;
  public GameObject Dialog;
  public bool blockInput = false;
  public bool Glitch = false;
  public GameObject cam;
  public float Screenshake = 0;
  public TileBase explosionDreck;

  // Start is called before the first frame update
  public Singleton() 
  {
    DirtTileMaps = new HashSet<Tilemap>();
    ShipTileMaps = new HashSet<Tilemap>();
    Enemys = new HashSet<IsEnemy>();
    instance = this;
  }

  // Update is called once per frame
  void Update()
  {

  }

}

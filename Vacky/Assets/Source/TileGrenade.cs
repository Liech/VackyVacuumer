using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGrenade : MonoBehaviour
{
  public float radius = 1;
  public Tilemap  map;
  public TileBase changeTo;
  // Start is called before the first frame update
  void Start()
  {
    if (map == null)
      throw new System.Exception("No Tilemap for tilegrenade");

    Vector3Int from   = map.WorldToCell(transform.position - new Vector3(radius, radius, 0));
    Vector3Int to     = map.WorldToCell(transform.position + new Vector3(radius, radius, 0));
    Vector3Int center = map.WorldToCell(transform.position );

    for (int x = from[0]; x < to[0]; x++)
      for (int y = from[1]; y < to[1]; y++)
        if ((new Vector2(x+0.5f,y+0.5f) - new Vector2(center.x,center.y)).magnitude < radius / map.transform.localScale[0])
          map.SetTile(new Vector3Int(x,y,0), changeTo);

    Destroy(gameObject);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnDrawGizmos()
  {
    Gizmos.color = new Color(0.4f, 0.4f, 0.4f, 0.4f);
    Gizmos.DrawSphere(transform.position, radius);
  }
}

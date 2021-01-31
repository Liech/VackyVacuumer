using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGrenade : MonoBehaviour
{
  public float radius = 1;
  public bool onDirtMap = false;
  public TileBase changeTo;
  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine("explode");
  }

  private IEnumerator explode()
  {
    yield return new WaitForSeconds(0.1f);
    explode(transform.position, radius, changeTo, onDirtMap);
    Destroy(gameObject);
  }

  public static void explode(Vector3 position, float r, TileBase newTile, bool onDirt)
  {
    HashSet<Tilemap> maps;
    if (onDirt)
      maps = Singleton.instance.DirtTileMaps;
    else
      maps = Singleton.instance.ShipTileMaps;

    foreach (var map in maps)
    {
      if (map == null)
        throw new System.Exception("No Tilemap for tilegrenade");

      Vector3Int from = map.WorldToCell  (position - new Vector3(r, r, 0));
      Vector3Int to = map.WorldToCell    (position + new Vector3(r, r, 0));
      Vector3Int center = map.WorldToCell(position);

      for (int x = from[0]; x < to[0]; x++)
        for (int y = from[1]; y < to[1]; y++)
        {
          Vector2 pos = new Vector2(map.transform.position.x, map.transform.position.y) + new Vector2(map.transform.localScale[0] * x, map.transform.localScale[0] * y);
          if (Physics2D.OverlapPoint(pos))
            continue;
          if ((new Vector2(x + 0.5f, y + 0.5f) - new Vector2(center.x, center.y)).magnitude < r / map.transform.localScale[0])
            map.SetTile(new Vector3Int(x, y, 0), newTile);
        }
    }
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

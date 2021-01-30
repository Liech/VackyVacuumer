using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//kollision des protagonisten
[RequireComponent(typeof(WASD))]
public class Bonk : MonoBehaviour
{
  private WASD control;
  public GameObject _bonkMesh;
  public List<GameObject> _bonkers;
  public List<Vector3Int> _bonkerCoords;
  public int _maxMemory = 5;

  public bool _enabled;
  // Start is called before the first frame update
  void Start()
  {
    control = transform.GetComponent<WASD>();
    _bonkers = new List<GameObject>();
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public void turnOn()
  {
    _enabled = true;
  }

  public void turnOff()
  {
    _enabled = false;
    for (int i = 0; i < _bonkers.Count; i++)
    {
      Destroy(_bonkers[i]);
    }
    _bonkers.Clear();
    _bonkerCoords.Clear();
  }

  void OnCollisionStay2D(Collision2D collision)
  {
    //GetComponent<Life>().addDamage(10);
    Debug.Log("Bonk");
    var tmap = collision.collider.gameObject.GetComponent<Tilemap>();
    if (tmap)
    {
      var colPoint = new Vector3(collision.GetContact(0).point[0], collision.GetContact(0).point[1], 0);
      var colPointImpro = (colPoint - transform.position).normalized * 0.01f + colPoint + Vector3.back;
      var cell = tmap.WorldToCell(colPointImpro);
      if (_bonkerCoords.Contains(cell))
        return;
      var pos = tmap.GetCellCenterWorld(cell);
      var bonk = Instantiate(_bonkMesh, collision.transform.position + pos, _bonkMesh.transform.rotation);
      _bonkers.Add(bonk);
      _bonkerCoords.Add(cell);
      if (_bonkers.Count > _maxMemory)
      {
        Destroy(_bonkers[0]);
        _bonkers.RemoveAt(0);
        _bonkerCoords.RemoveAt(0);
      }
      //Instantiate(_bonkMesh, new Vector3(collision.GetContact(0).point[0], collision.GetContact(0).point[1], -1.0f), Quaternion.identity, collision.collider.transform);
    }

  }
}

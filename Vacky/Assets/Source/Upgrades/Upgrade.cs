using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
  public GameObject UpgraderObject;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  public virtual void doUpgrade(GameObject target)
  {
    if (!UpgraderObject)
      throw new System.Exception("No Upgrade Set");
    GameObject upgrader = Instantiate(UpgraderObject, target.transform);
    
    target.GetComponent<Upgradeable>().addUpgrade(upgrader.GetComponent<Upgrader>());
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.gameObject.GetComponent<Upgradeable>())
      return;
    Debug.Log("Upgrade collect");
    doUpgrade(collision.gameObject);
    Destroy(gameObject);
  }
}

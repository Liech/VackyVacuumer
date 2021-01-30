using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : IController
{
  public GameObject bullet;
  public float reloadTime = 3;
  public float spawnDistance = 1;
  public float bulletSpeed = 2;

  bool canFire = false;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  //public void stun(float seconds)
  //{
  //  StopAllCoroutines();
  //  
  //  StartCoroutine("stopStun", seconds);
  //}
  //
  //private IEnumerator reload(float seconds)
  //{
  //  yield return new WaitForSeconds(seconds);
  //  canFire = true;
  //}
}

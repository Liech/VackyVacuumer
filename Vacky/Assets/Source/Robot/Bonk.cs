using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//kollision des protagonisten
[RequireComponent(typeof(WASD))]
public class Bonk : MonoBehaviour
{
  private WASD control;

  // Start is called before the first frame update
  void Start()
  {
    control = transform.GetComponent<WASD>();   
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    //GetComponent<Life>().addDamage(10);
    Debug.Log("Bonk");
  }
}

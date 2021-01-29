using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
  public uint life = 100;
  public uint maxlife = 100;
  public GameObject lifeBar;

  // Start is called before the first frame update
  void Start()
  {
    if (lifeBar == null)
      throw new System.Exception("Lifebar not set");

  }

  // Update is called once per frame
  void Update()
  {
    if (lifeBar)
    {
      LifeBar img = lifeBar.GetComponent<LifeBar>();
      img.setLife((float)life / (float)maxlife);
    }
  }
}

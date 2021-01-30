using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
  public int life = 100;
  public int maxlife = 100;
  public GameObject lifeBar;
  private bool alive = true;

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

  public void addDamage(int dmg)
  {
    life -= dmg;
    if (life < 0)
    {
      life = 0;
      if (alive)
      {
        alive = false;
        GetComponent<WASD>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.3f,0.3f,0.3f);
      }
    }
  }
}

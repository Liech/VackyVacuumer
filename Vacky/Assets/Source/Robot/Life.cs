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
  }

  // Update is called once per frame
  void Update()
  {
    float perc = (float)life / (float)maxlife;
    if (lifeBar)
    {
      LifeBar img = lifeBar.GetComponent<LifeBar>();
      img.setLife(perc);
    }
    transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f + perc/2, 0.5f + perc/2);
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
        if (GetComponent<IController>())
          GetComponent<IController>().enabled = false;
        if (GetComponent<DangerousThing>())
          GetComponent<DangerousThing>().On = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.3f,0.3f,0.3f);
      }
    }
  }
}

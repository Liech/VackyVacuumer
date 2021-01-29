using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void setLife(float percentage)
  {
   
    if (percentage < 0) percentage = 0;
    if (percentage > 1) percentage = 1;

    int imgNr = (int)(percentage * (transform.childCount - 1));

    for (int i = 0; i < transform.childCount; i++)
      transform.GetChild(imgNr).gameObject.SetActive(imgNr == i);
  }
}

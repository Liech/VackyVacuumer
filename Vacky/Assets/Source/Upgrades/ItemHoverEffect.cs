using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoverEffect : MonoBehaviour
{
  public float speed = 0.05f;
  public float amount = 1;

  private float currentPos = 0;

  // Start is called before the first frame update
  void Start()
  {
    if (transform.childCount == 0)
      throw new System.Exception("Hovering child impossible");
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.childCount == 0)
      return;

    currentPos += speed;
    while (currentPos > 1) 
      currentPos -= 1.0f;

    transform.GetChild(0).transform.localPosition = new Vector3(0, amount * Mathf.Cos(currentPos* Mathf.PI * 2), 0);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmDialog : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Singleton.instance.Dialog = gameObject;
    gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {

  }
}

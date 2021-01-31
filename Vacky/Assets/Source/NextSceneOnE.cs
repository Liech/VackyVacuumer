using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnE : MonoBehaviour
{
  public string nextScene;
    void Start()
    {
        
    }
  bool pressed = false;
    // Update is called once per frame
    void Update()
    {
      if (!pressed && Input.GetKey(KeyCode.E))
      {
      pressed = true;
      SceneManager.LoadScene(nextScene);
    }
    }
}

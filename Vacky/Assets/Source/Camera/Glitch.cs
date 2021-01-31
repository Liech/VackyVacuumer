using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glitch : MonoBehaviour {

  public Material mat;
  public float Range = 0.02f;
  void OnRenderImage(RenderTexture src, RenderTexture dest)
  {
    if (!Singleton.instance.Glitch)
    {
      mat.SetFloat("_Range", 0);
      Graphics.Blit(src, dest, mat);
      return;
    }
    mat.SetFloat("_Range", Range);
    mat.SetFloat("_Random", Random.value);
    Graphics.Blit(src, dest, mat);
  }  
}

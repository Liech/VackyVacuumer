using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexture : MonoBehaviour {

  public List<Sprite> PossibleTextures;

	// Use this for initialization
	void Start () {
    
    GetComponent<SpriteRenderer>().sprite = PossibleTextures[Random.Range(0,PossibleTextures.Count)];
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAttack : MonoBehaviour
{
  public float _attackDuration = 5;
  private float _currAtkdur = 0;
  // Start is called before the first frame update
  void Start()
  {
    _currAtkdur = 0; //imiditly cycle through attack
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (_currAtkdur < _attackDuration)
    {
      _currAtkdur += Time.fixedDeltaTime;
      return;
    } else
    {
      _currAtkdur = 0;
    }
    var attacks = GetComponents<IController>();
    int attack = (int)(Random.Range(0, attacks.Length - 0.1f));
    for (int i = 0; i < attacks.Length; i++)
    {
      if (i == attack)
        attacks[i].enabled = true;
      else
        attacks[i].enabled = false;
    }
  }
}

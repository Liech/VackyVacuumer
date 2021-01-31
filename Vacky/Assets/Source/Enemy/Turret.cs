using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : IController
{
  public GameObject bullet;
  public float reloadTime = 3;
  public float spawnDistance = 1;
  public float bulletSpeed = 2;
  public float reshotTime = 3;
  public int bulletsInMagazine = 3;

  bool canFire = true;
  int bullets = 0;
  public void Start()
  {
    bullets = bulletsInMagazine;
  }
  public void fire(GameObject target)
  {
    if (!canFire)
      return;
    bullets--;
    Vector2 dir = target.transform.position - transform.position;
    dir.Normalize();

    RaycastHit2D hit = Physics2D.Raycast(transform.position, dir);
    GameObject shell = Instantiate(bullet, transform.position + new Vector3(dir.x,dir.y,0)*spawnDistance, Quaternion.identity);

    shell.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;

    canFire = false;
    if (bullets <= 0)
    {
      StartCoroutine("reload", reloadTime);
      bullets = bulletsInMagazine;
    }
    else
      StartCoroutine("reload", reshotTime);

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<WASD>())
      fire(collision.gameObject);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<WASD>())
      fire(collision.gameObject);
  }
  private IEnumerator reload(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    canFire = true;
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = new Color(0.5f, 0.0f, 0.0f, 0.3f);
    Gizmos.DrawSphere(transform.position, spawnDistance);
  }
}

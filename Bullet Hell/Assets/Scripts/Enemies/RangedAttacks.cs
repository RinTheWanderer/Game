using UnityEngine;
using System.Collections;

public class RangedAttacks : FireGenericProjectile {

	public GameObject prefab;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Attack1 ();
	}


	public void Attack1 (){
		projectileSpeed = 100f;
		ShootProjectile (prefab, new Vector2 (transform.position.x, transform.position.y), playerVector3, true, false, 50, 50, 1);
	
	}
}

using UnityEngine;
using System.Collections;

public class RangedAttacks : FireGenericProjectile {

	public GameObject prefab;
	private bool canAttack = true;
	private float attackCount;
	private float attackTimer = 0.1f;


	
	// Update is called once per frame
	void Update () {
		base.Update ();
		Attack1 ();
	}


	public void Attack1 (){
		//ShootProjectile (1,100, prefab, new Vector2 (transform.position.x, transform.position.y), playerVector3, true, false, 50, 50);
		ShootProjectile (1, 200, prefab, firePositionOffset(0,0), playerVector3, true, true);
	}

	public void Attack2 (){
		yOffset = 0f;
		xOffset = -75f;
		ShootProjectile (1, 25, prefab, firePositionOffset(xOffset,yOffset), playerVector3, false, false, 0, -150);
		xOffset += 25f;
		ShootProjectile (1, 50, prefab, firePositionOffset(xOffset,yOffset), playerVector3, false, false, 0, -150);
		xOffset += 25f;		
		ShootProjectile (1, 75, prefab, firePositionOffset(xOffset,yOffset), playerVector3, false, false, 0, -150);
		xOffset += 25f;		
		ShootProjectile (1,100, prefab, firePositionOffset (xOffset, yOffset), playerVector3, false, false, 0, -150);
		xOffset += 25f;		
		ShootProjectile (1,125, prefab, firePositionOffset(xOffset,yOffset), playerVector3, false, false, 0, -150);
		xOffset += 25f;		
		ShootProjectile (1, 150, prefab, firePositionOffset(xOffset,yOffset), playerVector3, false, false, 0, -150);
		xOffset += 25f;		
		ShootProjectile (1,175, prefab, firePositionOffset(xOffset,yOffset), playerVector3, false, false, 0, -150);

	}
}

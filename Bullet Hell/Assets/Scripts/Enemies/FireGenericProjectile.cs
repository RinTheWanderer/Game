using UnityEngine;
using System.Collections;

public abstract class FireGenericProjectile : AbstractEnemyBehavior {

	protected float xOffset;
	protected float yOffset;
	private Rigidbody2D prefabRigidBody;

	private Vector3 adjustedTargetLoc = new Vector3 (0,0,0);


	protected virtual Vector2 firePositionOffset (float x, float y){
		var posX = transform.position.x + x;
		var posY = transform.position.y + y;
		return new Vector2 (posX, posY);
	}

	protected virtual Vector3 adjustedTargetPos (Vector3 target, float x, float y){
		var posX = target.x - x;
		var posY = target.y - y;
		adjustedTargetLoc = new Vector3 (posX, posY, target.z);
		return adjustedTargetLoc;
	}


	protected virtual void ShootProjectile (float damage, float projectileSpeed, GameObject prefab, Vector2 pos, Vector3 target, bool towardsPlayer = false, bool homing = false, float xSpeed = 0, float ySpeed = 0){
		Vector3 targetPosition = target;
		var clone = Instantiate (prefab, pos, Quaternion.identity) as GameObject;

		if (towardsPlayer) {
			if (homing) {
				targetPosition = adjustedTargetPos (targetPosition, xOffset, yOffset);
			}
			clone.GetComponent<Rigidbody2D> ().velocity = MoveTowardsTarget (targetPosition, projectileSpeed);
		} else if (!homing) {
			clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xSpeed, ySpeed);
		}
	}


	public GameObject ChangePrefabScale (GameObject prefab, float scale){
		var tempScale = transform.localScale;
		prefab.transform.localScale = new Vector3 (scale * tempScale.x, scale* tempScale.y, scale* tempScale.z);
		return prefab;
	}
}

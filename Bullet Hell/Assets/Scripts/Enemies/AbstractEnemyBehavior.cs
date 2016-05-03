using UnityEngine;
using System.Collections;

public abstract class AbstractEnemyBehavior : MonoBehaviour {

	public MonoBehaviour[] disableScripts;

	protected Rigidbody2D body2d;
	//protected CollisionState collisionState;

	public bool playerDetected = false;
	protected PlayerManager player;
	public float detectionRadiusMin = 0f;
	public float detectionRadiusMax = 300f;
	protected float distanceToPlayer;
	public Color detectionRadiusColor = Color.green;

	protected Vector3 playerVector3;

	protected bool playerAbove;
	protected bool playerRight;
	protected float yAxisDirection;
	protected float xAxisDirection;


	protected virtual void Awake(){
		body2d = GetComponent<Rigidbody2D>();
		//collisionState = GetComponent<CollisionState> ();
		player = FindObjectOfType <PlayerManager>();
		playerVector3 = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}


	protected virtual void ToggleScripts (bool value){
		foreach (var script in disableScripts) {
			script.enabled = value;
		}
	}


	public virtual void Update(){
		DetectPlayer ();
		playerVector3 = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		distanceToPlayer = (Mathf.Sqrt (Mathf.Pow ((transform.position.x - playerVector3.x), 2) + Mathf.Pow ((transform.position.y - playerVector3.y), 2)));
		if (playerVector3.x > transform.position.x)
			playerRight = true;
		else
			playerRight = false;
		if (playerVector3.y > transform.position.y)
			playerAbove = true;
		else
			playerAbove = false;
		if (playerRight)
			xAxisDirection = 1;
		else
			xAxisDirection = -1;
		if (playerAbove)
			yAxisDirection = 1;
		else
			yAxisDirection = -1;
	}


	public virtual void DetectPlayer (){
		if (detectionRadiusMax >= distanceToPlayer && detectionRadiusMin <= distanceToPlayer)
			playerDetected = true;
		else
			playerDetected = false;
	}

	void OnDrawGizmos(){
		var pos = new Vector2 (transform.position.x, transform.position.y);

		Gizmos.color = detectionRadiusColor;
		Gizmos.DrawWireSphere (pos, detectionRadiusMax);
		Gizmos.DrawWireSphere (pos, detectionRadiusMin);
	}

	/*public virtual float TargetLocationXMultiplier (Targetable target)
	{
		var targetPosX = target.transform.position.x;
		var targetPosY = target.transform.position.y;
		var XMult = -(transform.position.x - targetPosX) / (Mathf.Sqrt (Mathf.Pow ((transform.position.x - target.transform.position.x), 2) + Mathf.Pow ((transform.position.y - target.transform.position.y), 2)));
		return XMult;
	}

	public virtual float TargetLocationYMultiplier (Targetable target)
	{
		var targetPosX = target.transform.position.y;
		var targetPosY = target.transform.position.y;
		var YMult = -(transform.position.y - targetPosY) / (Mathf.Sqrt (Mathf.Pow ((transform.position.x - target.transform.position.x), 2) + Mathf.Pow ((transform.position.y - target.transform.position.y), 2)));
		return YMult;
	}*/

	public virtual Vector2 MoveTowardsTarget ( Vector3 target, float speed){
		var targetPosX = target.x;
		var targetPosY = target.y;
		var XMult = -(transform.position.x - targetPosX) / (Mathf.Sqrt (Mathf.Pow ((transform.position.x - target.x), 2) + Mathf.Pow ((transform.position.y - target.y), 2)));
		var YMult = -(transform.position.y - targetPosY) / (Mathf.Sqrt (Mathf.Pow ((transform.position.x - target.x), 2) + Mathf.Pow ((transform.position.y - target.y), 2)));
		Vector2 TravelVector = new Vector2 (speed * XMult, speed * YMult);
		return TravelVector;
	}
}

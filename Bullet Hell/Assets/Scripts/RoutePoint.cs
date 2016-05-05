using UnityEngine;
using System.Collections;

[System.Serializable]
public class RoutePoint : MonoBehaviour {
//	public GameObject target;
	public float speed;
	public Vector3 point;
//	public Vector3 targetStart;
//	public int tracking, magnetism;
//Tracking type 0: no tracking, 1: aim at initial spot but don't update, 2: homing.
//Magnetism Value 0 to 180. 0 is none, 180 is perfect tracking. number represents degrees turned toward target per frame.

	public RoutePoint (Vector3 _point, float _speed = 0){//, GameObject _target = null, int _tracking = 0, int _magnetism = 0) {
//		target = _target;
//		if (target != null) {
//			targetStart = target.transform.position;
//		}
		speed = _speed;
		point = _point;
//		tracking = _tracking;
//		magnetism = _magnetism;
	}

	void Start () {

	}

	void Update () {

	}
}

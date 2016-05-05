using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Route : MonoBehaviour {
	public RoutePoint[] routePoints;
	public object[] test = new object[] {new Vector3 (0,1,0), 5, "hello"};
	void Awake () {
//		routePoints[0] = new RoutePoint (new Vector3 (1,1,0), 50);
		Debug.Log(test);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
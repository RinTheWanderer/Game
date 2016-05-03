using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D target){
		if (target.tag == "Player") {
			
			Destroy (gameObject);
		}
		else if (target.tag == "OutofBounds"){
			Destroy (gameObject);
		} 
		else {
			Physics2D.IgnoreCollision (gameObject.GetComponent<Collider2D> (), target);
		}
	}
}

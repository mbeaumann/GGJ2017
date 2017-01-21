using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public GameObject pere;

	public void OnTriggerStay2D(Collider2D col){
		Debug.Log ("col");
		if (Input.GetAxis ("Fire") != 0) {
			kill ();
		}
	}

	private void kill(){
		Debug.Log ("kill");
		Destroy(this.gameObject);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class Torch : MonoBehaviour {
	
	public int nbRays = 5;
	public int angle = 25;
	public int portee = 10;

	void Update(){
		castRays ();
	}


	void castRays(){

		int gap = angle / nbRays;
		int angleMin = (int)(-angle * 0.5f);
		int angleMax = (int)(angle * 0.5f);
			
		RaycastHit hit;
		for (int i = angleMin; i < angleMax; i += gap) {
		
			Vector3 vec = (Quaternion.Euler (0, i, 0) * transform.forward).normalized * portee;
			if (Physics.Raycast(transform.position, vec, out hit, portee)) {
				if (hit.collider.gameObject.tag == "Player") {
					hit.collider.gameObject.SendMessage ("kill");
				}
			}
			Debug.DrawRay (transform.position, vec, Color.red);
		}
	}

	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage ("kill");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

	public void kill() {
		Spawner.enemy--;
		GetComponent<sonGarde> ().soundDeath ();
		StartCoroutine("desactive");
	}

	IEnumerator desactive(){
		foreach (Transform tmp in transform.GetComponentsInChildren<Transform>()) {
			tmp.gameObject.SetActive (false);
		}
		yield return new WaitForSeconds (2);
		Destroy (this.gameObject);
	}

}

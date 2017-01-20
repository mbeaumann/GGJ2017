using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine.UI;

public class Torch : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage ("kill");
		}
	}
}

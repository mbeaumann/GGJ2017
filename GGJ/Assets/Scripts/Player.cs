using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	Vector3 vecAccel;
	CharacterController cController;
	// Use this for initialization
	void Start () {
		speed = 300.0f;
		cController = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		vecAccel = new Vector3(x, 0, y);
		cController.SimpleMove(vecAccel * Time.deltaTime * speed);
	}


	public void kill(){
		Debug.Log ("Mort");
	}

}

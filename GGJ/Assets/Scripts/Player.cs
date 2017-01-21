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

	void checkCol(){
		if (vecAccel.x != 0) {
			RaycastHit hit;
			if (Physics.Linecast (transform.position, new Vector3 (transform.position.x + 1, 0, transform.position.z), out hit)) {
				if (hit.distance < 0.5f) {
					vecAccel.x = 0;
				}
			}
		}

		if (vecAccel.z != 0) {
			RaycastHit hit;
			if (Physics.Linecast (transform.position, new Vector3 (transform.position.x, 0, transform.position.z + 1), out hit)) {
				if (hit.distance < 0.5f) {
					Debug.Log (hit.collider.gameObject.name);
					vecAccel.z = 0;
				}
			}
		}

	}

	public void kill(){
		Debug.Log ("Mort");	
	}

}

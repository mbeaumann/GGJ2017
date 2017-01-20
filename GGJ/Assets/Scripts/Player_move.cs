using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {

	public Transform trans;
	public float speed;
	// Use this for initialization
	void Start () {
		trans = this.GetComponent<Transform>();
		speed = 150.0f;

	}

	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate(x, y, 0);
	}
}

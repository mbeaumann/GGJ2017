using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {

	public Transform trans;
	public float speed = 90.0f;
	// Use this for initialization
	void Start () {
		trans = this.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate(x, y, 0);
	}
}

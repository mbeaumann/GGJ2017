using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {

	public Transform trans;
	public float speed = 10.0f;
	public float leap_speed = 30.0f;
	public int endurance = 100;
	public bool can_leap = true;
	public int endu_decay = 5;
	public int endu_regen = 1;
	// Use this for initialization
	void Start () {
		trans = this.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		float x;
		float y;
		if(endurance == 100) {
			can_leap = true;
		}
		if(Input.GetKey(KeyCode.LeftShift) && can_leap) {
			endurance -= endu_decay;
			if(endurance <= endu_decay) {
				can_leap = false;
			}
			x = Input.GetAxis("Horizontal") * Time.deltaTime * leap_speed;
			y = Input.GetAxis("Vertical") * Time.deltaTime * leap_speed;
		}
		else {
			if(endurance < 100) {
				endurance += endu_regen;
			}
			x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
			y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		}

		transform.Translate(x, 0, y);
	}
}

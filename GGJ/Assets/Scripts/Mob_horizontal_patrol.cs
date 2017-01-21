using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_horizontal_patrol : MonoBehaviour {

	public Vector3 initPos;
	public float speed = 2.0f;
	public bool right = true;
	public float amplitude = 4.0f;
	public bool token = true;
	// Use this for initialization
	void Start () {
		initPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(token) {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
			if(right) {
				if(transform.position.x - initPos.x >= amplitude) {
					token = false;
					right = !right;
					StartCoroutine("rotate");
				}
			}
			else {
				if(transform.position.x - initPos.x <= -amplitude) {
					token = false;
					right = !right;
					StartCoroutine("rotate");
				}
			}
		}

	}

	public IEnumerator rotate() {
		yield return new WaitForSeconds(1);
		transform.Rotate(0, 0, 90);
		yield return new WaitForSeconds(1);
		transform.Rotate(0, 0, 90);
		token = true;

	}

}

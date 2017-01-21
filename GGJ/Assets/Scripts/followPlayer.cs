using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(player)
			transform.position = new Vector3(player.position.x, 20, player.position.z);
	}
}

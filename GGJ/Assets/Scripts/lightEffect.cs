using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightEffect : MonoBehaviour {

	public Light light;

	void Start(){
		light = GetComponent<Light> ();

	}

	void Update () {
		light.intensity = Spawner.enemy * 0.025f;
	}
}

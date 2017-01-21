using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class sonGarde : MonoBehaviour {

	public AudioClip[] sounds;
	AudioSource source;

	void Start(){
		source = GetComponent<AudioSource> ();
	}

	public void Update(){
		source.PlayOneShot (sounds [0]);
		source.Play ();
	}

	public void soundDeath(){
		
		source.PlayOneShot (sounds [0]);
		source.Play ();
	}

}

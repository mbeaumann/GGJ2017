using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

	public const int maxSpawned = 20;
	public static int enemy;

	public GameObject prefab;
	public int timer = 8;

	void Awake(){
		enemy = 5;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine("spawn");
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator spawn() {
		while(true) {
			yield return new WaitForSeconds(timer);
			Instantiate(prefab, transform.position, transform.rotation);
			enemy++;
			if(enemy >= maxSpawned) {
				Debug.Log("Fin de jeu, nooblord");
				SceneManager.LoadScene (2);
			}
		}
	}
}

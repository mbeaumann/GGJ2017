using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour {

	public void changeScene(){
		Debug.Log ("check");
		SceneManager.LoadScene(1);
	}
}

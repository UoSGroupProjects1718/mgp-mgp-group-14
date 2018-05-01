using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCTRL : MonoBehaviour {

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName); //Loads the specified scene in the button when clicked
	}
}
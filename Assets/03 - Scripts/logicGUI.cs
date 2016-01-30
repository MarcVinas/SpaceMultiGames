using UnityEngine;
using System.Collections;

public class logicGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			Application.LoadLevel(0);
		}
	}

    public void goToMenu()
    {
		Debug.Log("goToMenu()");

        Application.LoadLevel(0);
    }

	public void reloadLevel()
	{
		Debug.Log("reloadLevel()");
		Application.LoadLevel (Application.loadedLevel);
	}
}

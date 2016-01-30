using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LB_LogicGame : MonoBehaviour {
	public GameObject prefabBomb;
	public Transform Planet;
	public AudioClip clipDestroyPlanet;

	public float timer;
	public float timeToAppear;
	[HideInInspector]
	public int score=0;
	[HideInInspector]
	public int life;
	public Text lblScore;
	public Text lblLife;
	public Text bestScore;
	public Text curentScore;
	public GameObject panelPlayAgain;
	public GameObject prefabExplosion;
	public Transform planetCenter;
	private bool destroyPlanet;
	// Use this for initialization
	void Start () {
		destroyPlanet = false;
		timer = 0.0f;
		life = 3;
		panelPlayAgain.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyPlanet)
			return;
		if (life == 0) {
			Instantiate (prefabExplosion, planetCenter.position, Quaternion.identity);
			GetComponent<AudioSource> ().PlayOneShot (clipDestroyPlanet);
			destroyPlanet = true;
			Invoke ("GameOver", 0.75f);
			planetCenter.GetComponent<Renderer> ().enabled = false;
			gameObject.BroadcastMessage ("DestroyedPlanet");
			//Invoke ("DestroyBomb", 0.3f);
			return;
		} 
		lblScore.text = "Score = " + score;
		lblLife.text = "Life = " + life;
		timer += Time.deltaTime;
		if (timer > timeToAppear) {
			timer = 0.0f;
			Vector3 position = Planet.position + Random.onUnitSphere * 1.5f; //radius of planet: 2
			GameObject oExplosion = Instantiate (prefabBomb, position, Quaternion.identity)  as GameObject;    
			oExplosion.transform.parent = this.transform; 
		}
	}


	public void GameOver()
	{
		Debug.Log("GameOver()");
		//TODO comprobar que funcione

		int ibestScore = PlayerPrefs.GetInt ("LB_BestScore", 0);
		// no funciona los botones de reiniciar y 
		//int ibestScore = 30;
		if (ibestScore < score) {
			ibestScore = score;
			PlayerPrefs.SetInt ("LB_BestScore", ibestScore);
		}
		bestScore.text = "Best Score: " + ibestScore;
		curentScore.text = "Current Score: " + score;
		panelPlayAgain.SetActive (true);

	}
	public void DestroyBomb ()
	{
		Destroy (gameObject);
	}
}



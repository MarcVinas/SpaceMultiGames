using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LB_LogicGame : MonoBehaviour {
	public GameObject prefabBomb;
	public Transform Planet;
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
	private bool finalExlposion;
	// Use this for initialization
	void Start () {
		finalExlposion = true;
		timer = 0.0f;
		life = 3;
		panelPlayAgain.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			Invoke ("DestroyBomb", 0.3f);
			//TODO hay alguna forma de controlar que solo se llame una vez?
			if(finalExlposion){
				Instantiate (prefabExplosion, planetCenter.position, Quaternion.identity);
				finalExlposion=false;
			}
			GameOver ();
		} else {
			lblScore.text = "Score = " + score;
			lblLife.text = "Life = " + life;
			timer += Time.deltaTime;
			if (timer > timeToAppear) {
				timer = 0.0f;
				Vector3 position = Planet.position + Random.onUnitSphere * 1.5f; //radius of planet: 2
				Instantiate (prefabBomb, position, Quaternion.identity);    
			}
		}
	}

	public void GameOver()
	{
		//TODO ibestScore hardcoded + uso de PlayerPrefs
		//int ibestScore = PlayerPrefs.GetInt ("LB_BestScore", 0);
		// no funciona los botones de reiniciar y 
		int ibestScore = 30;
		if (ibestScore < score) {
			ibestScore = score;
			//PlayerPrefs.SetInt ("LB_BestScore", ibestScore);
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



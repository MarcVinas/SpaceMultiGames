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
	// Use this for initialization
	void Start () {
		timer = 0.0f;
		life = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(life==0){
			//Instantiate (prefabExplosion, planetCenter.position, Quaternion.identity);
		}
		lblScore.text = "Score = "+score;
		lblLife.text = "Life = "+life;
		timer += Time.deltaTime;
		if (timer > timeToAppear) {
			timer = 0.0f;
			Vector3 position = Planet.position + Random.onUnitSphere * 1.5f ; //radius of planet: 2
			Instantiate (prefabBomb, position, Quaternion.identity);    
		}
	}

	/*public void GameOver()
	{
		int ibestScore = PlayerPrefs.GetInt ("LB_BestScore", 0);
		if (ibestScore < iScore) {
			ibestScore = iScore;
			PlayerPrefs.SetInt ("LB_BestScore", ibestScore);
		}
		bestScore.text = "Best Score: " + ibestScore;
		curentScore.text = "Current Score: " + iScore;
		panelPlayAgain.SetActive (true);
	}
}*/


}
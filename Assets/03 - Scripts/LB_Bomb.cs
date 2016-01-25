using UnityEngine;
using System.Collections;

public class LB_Bomb : MonoBehaviour {
	public AudioClip deactivateBomb;
	public AudioClip explodeBomb;
	public float timer = 0.0f;
	public float timeToDie;
	public GameObject prefabExplode;
	public GameObject o;
	private LB_LogicGame lg;
	// Use this for initialization
	void Start () {
		//1a opcion de enlazar objetos
		//logicGame = GameObject.FindGameObjectWithTag ("LogicGame");

		GameObject o= GameObject.FindGameObjectWithTag ("LogicGame");
		if(o!=null){
			lg= o.GetComponent<LB_LogicGame>();

		}
	}
	
	// Update is called once per frame
	void Update()
	{

        float t = timer / timeToDie;
        Color currentColor = Color.Lerp(Color.green, Color.red, t);
        GetComponent<Renderer>().material.color = currentColor;

        timer += Time.deltaTime;
        if (timer > timeToDie)
        {
			lg.score-=1;
			lg.life-=1;
            Destroy(gameObject);
			//altavoz
			GetComponent<AudioSource> ().PlayOneShot (explodeBomb);
			GetComponent<Renderer> ().enabled = false;
			Invoke ("DestroyBomb", 0.3f);
			Instantiate (prefabExplode,transform.position, Quaternion.identity);

        }
        
    }

    void OnMouseDown()
    {

		lg.score+=1;
        Destroy(gameObject);
		GetComponent<AudioSource> ().PlayOneShot (deactivateBomb);
		//isDead = true;
		//GetComponent<Renderer> ().enabled = false;
		Invoke ("DestroyBomb", 1.0f);

    }

	public void DestroyBomb ()
	{
		Destroy (gameObject);
	}

}

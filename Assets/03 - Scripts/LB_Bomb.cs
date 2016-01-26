using UnityEngine;
using System.Collections;

public class LB_Bomb : MonoBehaviour {
	public AudioClip deactivateBomb;
	public AudioClip explodeBomb;
	public float timer = 0.0f;
	public float timeToDie;
	public GameObject prefabExplode;
	public GameObject prefabDesactivate;
	public GameObject o;
	private LB_LogicGame lg;
	private bool isDead;
	// Use this for initialization
	void Start () {
		//1a opcion de enlazar objetos
		isDead = false;

		GameObject o= GameObject.FindGameObjectWithTag ("LogicGame");
		if(o!=null){
			lg= o.GetComponent<LB_LogicGame>();

		}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (isDead)
			return;
        float t = timer / timeToDie;
        Color currentColor = Color.Lerp(Color.green, Color.red, t);
        GetComponent<Renderer>().material.color = currentColor;

        timer += Time.deltaTime;
        if (timer > timeToDie)
        {
			isDead=true;
			timer=0.0f;
			lg.score-=1;
			lg.life-=1;

			//altavoz
			GetComponent<AudioSource> ().PlayOneShot (explodeBomb);
			GetComponent<Renderer> ().enabled = false;
			Invoke ("DestroyBomb", 0.3f);
			Instantiate (prefabExplode,transform.position, Quaternion.identity);

        }
        
    }

    void OnMouseDown()
    {
		if (isDead) 
			return;

			lg.score += 1;
        
		GetComponent<AudioSource> ().PlayOneShot (deactivateBomb);
		//isDead = true;
		GetComponent<Renderer> ().enabled = false;
		isDead = true;

		Invoke ("DestroyBomb", 1.0f);


    }

	public void DestroyBomb ()
	{
		Destroy (gameObject);
	}

}

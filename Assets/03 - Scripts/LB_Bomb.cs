using UnityEngine;
using System.Collections;

public class LB_Bomb : MonoBehaviour {
	public float timer = 0.0f;
	public float timeToDie;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
        float t = timer / timeToDie;
        Color currentColor = Color.Lerp(Color.green, Color.red, t);
        GetComponent<Renderer>().material.color = currentColor;

        timer += Time.deltaTime;
        if (timer > timeToDie)
        {
            Destroy(gameObject);
        }
        
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

}

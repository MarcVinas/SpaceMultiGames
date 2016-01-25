using UnityEngine;
using System.Collections;

public class LB_LogicGame : MonoBehaviour {
	public GameObject prefabBomb;
	public Transform Planet;
	public float timer;
	public float timeToAppear;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > timeToAppear) {
			timer = 0.0f;
			Vector3 position = Planet.position + Random.onUnitSphere * 1.5f ; //radius of planet: 2
			Instantiate (prefabBomb, position, Quaternion.identity);    
		}
	}
}

/*

public Transform planetCenter;
    public GameObject prefab;
    public float timer;
    public float timeToAppear;

    // Use this for initialization
    void Start () {
        timer = 0.0f;
    }
    
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > timeToAppear) {
            timer = 0.0f;
            Vector3 position = planetCenter.position + Random.onUnitSphere * 2.0f ; //radius of planet: 2
            Instantiate (prefab, position, Quaternion.identity);    
        }
    }
*/
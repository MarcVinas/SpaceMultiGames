using UnityEngine;
using System.Collections;
//using UnityEngine.Sce
public class LogicMenu : MonoBehaviour {

	public GameObject[] lights;
	public Transform spaceShip;
	public Transform cube;
	float count;
	float timer;
    float posY_InitShip;
    // Use this for initialization
    void Start () {
        restetLights();
        timer = 0.0f;
        count = 0.0f;
    }
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			Application.LoadLevel(0);
            posY_InitShip = spaceShip.position.y;
        }
        //mover nave
        cube.transform.Rotate(new Vector3(0, 10 * Time.deltaTime, 0));
        count += Time.deltaTime;
        float value = Mathf.Cos(count) * 0.2f;
        Vector3 pos = spaceShip.transform.position;
        pos.y = posY_InitShip + value; ;
        spaceShip.position = pos;


        //encender una luz random
        int lightSelected=Random.Range (0,4);
		timer += Time.deltaTime;
		if (timer > 2) 
		{
			timer=0;
			restetLights();
			lights [lightSelected].SetActive (true);

		}
	}
	private void restetLights()
	{
		for (int i=0; i<lights.Length; i++) 
		{
			lights [i].SetActive (false);
		}
	}

}






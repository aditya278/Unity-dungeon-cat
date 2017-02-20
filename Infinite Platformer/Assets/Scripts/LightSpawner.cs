using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour {

	static int lightSpawn;
	public GameObject lights;
	GameObject lightObj;
	public Transform challengesSpawnPoint;
	public float scrollSpeed = 7.0f;
	public bool gover = false;

	// Use this for initialization
	void Start () {
		lightObj = Instantiate(lights, new Vector2(challengesSpawnPoint.position.x, 2f), Quaternion.identity) as GameObject;
		lightObj.transform.parent = transform;
		lightSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {

		if (gover)
			return;
		else {
			
			lightSpawn++;
			if (lightSpawn == 200) {
				lightObj = Instantiate (lights, new Vector2 (challengesSpawnPoint.position.x, 1.7f), Quaternion.identity) as GameObject;
				lightObj.transform.parent = transform;
				lightSpawn = 0;
			}
		

			GameObject currentObject;
			for (int i = 0; i < transform.childCount; i++) {
				currentObject = transform.GetChild (i).gameObject;
				ScrollChallenge (currentObject);
				if (currentObject.transform.position.x <= -15f) {
					Destroy (currentObject);
				}
			}
		}
		/*ScrollChallenge (lightObj);
		if (lightObj.transform.position.x <= -15f) {
			Destroy (lightObj);
		}*/

	}

	void ScrollChallenge (GameObject currentChallenge) {

		currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
	}

}
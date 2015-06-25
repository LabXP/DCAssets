using UnityEngine;
using System.Collections;

public class GameControllerLevel4 : MonoBehaviour {
	public int KidsClicked;
	public float KidSpawnTime;

	public GameObject kid;
	public GameObject river;

	public static GameControllerLevel4 instance = null;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this);
		}

		StartCoroutine (SpawnKid());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickKid(){
		KidsClicked++;
	}

	IEnumerator SpawnKid(){
		while (true) {
			KidSpawnTime = Random.Range (0.3f, 0.5f);
			yield return new WaitForSeconds(KidSpawnTime);
			int x = Random.Range (0,20);
			if (river.transform.GetChild(x).transform.tag == "RiverWater"){
				GameObject ph = Instantiate (kid) as GameObject;
				Kid phKid = ph.GetComponent<Kid>();
				phKid.phRiver = river.transform.GetChild(x).gameObject;
				phKid.phRiver.transform.SetParent(ph.gameObject.transform.parent);
				phKid.phRiver.SetActive(false);
				phKid.x = x;
				ph.transform.SetParent (river.transform);
				ph.transform.SetSiblingIndex(x);
				phKid.river = ph.transform.parent.gameObject;
			}

		}
	}

}

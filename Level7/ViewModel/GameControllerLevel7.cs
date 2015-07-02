using UnityEngine;
using System.Collections;

public class GameControllerLevel7 : MonoBehaviour {
	public static GameControllerLevel7 instance = null;

	public GameObject trash;
	public GameObject street;
	//public GameObject trashCan;

	public int TrashSpawnAmount;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this);
		}

		TrashSpawnAmount = Random.Range (50, 75);

	}

	void Start(){
		while (TrashSpawnAmount>0) {
			SpawnTrash();
		}
	}

	void SpawnTrash(){

			int x = Random.Range (0, 216);
			if (street.transform.GetChild (x).transform.tag == "Street") {
				GameObject ph = Instantiate (trash) as GameObject;
				Trash phTrash = ph.GetComponent<Trash> ();
				phTrash.phStreet = street.transform.GetChild (x).gameObject;
				phTrash.phStreet.transform.SetParent (ph.gameObject.transform.parent);
				phTrash.phStreet.SetActive (false);
				phTrash.x = x;
				ph.transform.SetParent (street.transform);
				ph.transform.SetSiblingIndex (x);
				phTrash.street = ph.transform.parent.gameObject;
				TrashSpawnAmount--;
			}

	}
}

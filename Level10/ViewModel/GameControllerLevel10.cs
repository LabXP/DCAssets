using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerLevel10 : MonoBehaviour {
	public GameObject streetPrefab;
	public GameObject housePrefab;
	public GameObject city;
	public GameObject[] problemsPrefab;

	private bool tempOK;
	private int a;
	[SerializeField]private StreetTag[] streets;

	[SerializeField]private int spawnCount;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnMap ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnMap(){
		while (spawnCount < 208) {
			yield return new WaitForEndOfFrame();

			if (spawnCount < 16){
				if (Random.Range(0,100) > 30 || spawnCount > 1 && city.transform.GetChild(spawnCount-1).transform.tag == "Street"){
				GameObject ph = Instantiate(housePrefab) as GameObject;
				ph.transform.SetParent(city.transform);
				spawnCount++;
			} else {
				GameObject ph = Instantiate(streetPrefab) as GameObject;
				ph.transform.SetParent(city.transform);
				spawnCount++;
				}
			} else if (spawnCount < 32){
				if (city.transform.GetChild(spawnCount-16).transform.tag == "Street"){
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				} else {
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}
			} else if (spawnCount < 48){
				GameObject ph = Instantiate(streetPrefab) as GameObject;
				ph.transform.SetParent(city.transform);
				spawnCount++;
			}	else if (spawnCount < 64){
				if (city.transform.GetChild(spawnCount-32).transform.tag == "Street"){
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				} else {
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}
			} else if (spawnCount < 80){

				if (city.transform.GetChild(spawnCount-16).transform.tag == "Street" && Random.Range(0,50) > 30 && city.transform.GetChild(spawnCount-1).transform.tag != "Street" || !tempOK && city.transform.GetChild(spawnCount-16).transform.tag == "Street"){
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					if (!tempOK && city.transform.GetChild(spawnCount-16).transform.tag == "Street"){
						tempOK = true;
						//ph.GetComponent<Image>().color = Color.cyan;
						//city.transform.GetChild(spawnCount-16).GetComponent<Image>().color = Color.magenta;
						print ("tempOk");
					}
					spawnCount++;
				} else {
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}
			} else if (spawnCount < 96){
				if (city.transform.GetChild(spawnCount-16).transform.tag == "Street"){
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				} else {
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}
			} else if (spawnCount < 112){
				GameObject ph = Instantiate(streetPrefab) as GameObject;
				ph.transform.SetParent(city.transform);
				spawnCount++;
			} else if (spawnCount < 128){
				if (Random.Range(0,100) > 30 || city.transform.GetChild(spawnCount-1).transform.tag == "Street"){
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				} else {
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}
			} else if (spawnCount < 144){
				if (city.transform.GetChild(spawnCount-16).transform.tag == "Street" || Random.Range(0,100)> 45){
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				} else {
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}
			} else if (spawnCount < 160){
				if (city.transform.GetChild(spawnCount-32).transform.tag == "Street" && city.transform.GetChild(spawnCount-1).transform.tag != "Street"  && spawnCount > 144|| city.transform.GetChild(spawnCount-16).transform.tag == "Street" && city.transform.GetChild(spawnCount-32).transform.tag != "Street" && city.transform.GetChild(spawnCount-1).transform.tag != "Street"){
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				} else {
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}

			} else if (spawnCount < 176){
				if (city.transform.GetChild(spawnCount-16).transform.tag == "Street"){
					GameObject ph = Instantiate(streetPrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				} else {
					GameObject ph = Instantiate(housePrefab) as GameObject;
					ph.transform.SetParent(city.transform);
					spawnCount++;
				}
			}  else if (spawnCount < 192){
				GameObject ph = Instantiate(streetPrefab) as GameObject;
				ph.transform.SetParent(city.transform);
				spawnCount++;
			} else if (spawnCount < 208){

					if (Random.Range(0,100) > 30 || spawnCount > 1 && city.transform.GetChild(spawnCount-1).transform.tag == "Street"){
						GameObject ph = Instantiate(housePrefab) as GameObject;
						ph.transform.SetParent(city.transform);
						spawnCount++;
					} else {
						GameObject ph = Instantiate(streetPrefab) as GameObject;
						ph.transform.SetParent(city.transform);
						spawnCount++;
					}

			}
		}
		streets = FindObjectsOfType<StreetTag> ();

		int problems = Random.Range (4, 6);

		while (a < problems) {
			int b = Random.Range(0, streets.Length);
			GameObject ph = Instantiate(problemsPrefab[Random.Range(0, problemsPrefab.Length)]) as GameObject;
			ph.transform.SetParent(city.transform);
			ph.transform.SetSiblingIndex(streets[b].gameObject.transform.GetSiblingIndex());
			Destroy (streets[b].gameObject);
			problems--;
		}

	}
}

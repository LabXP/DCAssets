using UnityEngine;
using System.Collections;

public class GameControllerLevel1 : MonoBehaviour {
	public int Timer;
	public bool end, win, lose;

	public Hole[] holes;

	public GameObject hole, grass, mountain;

	public int FilledScore;

	int x = 0;
	// Use this for initialization
	void Start () {
		CreateGrid ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > Timer) {
			end = true;
		}
		if (end) {
			CheckWin();
		}
	}

	void CheckWin(){
		foreach (Hole hole in holes) {
			if(hole.Filled){
				FilledScore++;
			}
		}

		if (FilledScore > holes.Length * 0.7) {
			win = true;
		} else {
			lose = true;
		}

	}

	void CreateGrid(){

		
		while (x < 36) {
			int r = Random.Range (0,99);
			if (r < 50){
				GameObject ph = Instantiate(hole) as GameObject;
				ph.transform.SetParent(mountain.transform);
			} else {
				GameObject ph = Instantiate(grass) as GameObject;
				ph.transform.SetParent(mountain.transform);
			}
			x++;
		}
		holes = FindObjectsOfType<Hole> ();
	}

}

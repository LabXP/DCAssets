using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hole : MonoBehaviour {
	public bool Filled;

	void Update(){
		if (Filled) {
			GetComponent<Image>().color = Color.cyan;
		}
	}

}

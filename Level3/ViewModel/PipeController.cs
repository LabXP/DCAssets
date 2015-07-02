using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour {

	Quaternion temp;
	PontaController[] pontas;

	public bool waterInPipe;
	// Use this for initialization
	void Awake () {
		pontas = GetComponentsInChildren<PontaController>();
	}	
	
	// Update is called once per frame
	public void Rotation () {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90f);
	}

	public void ListennerWater(){
		foreach(PontaController ponta in pontas){
			if(ponta.getHaveWater()){
				waterInPipe = true;
			}
		}
	}


}

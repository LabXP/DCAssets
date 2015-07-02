using UnityEngine;
using System.Collections;

public class PontaController : MonoBehaviour {

	private bool haveWater;

	public bool getHaveWater (){
		return haveWater;
	}
	public void setHaveWater(bool haveWather){
		this.haveWater = haveWater;
	}
}

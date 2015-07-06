using UnityEngine;
using System.Collections;

public class PontaController : MonoBehaviour {


	public bool haveWater;

	public bool getHaveWater () {
		return haveWater;
	}

	public void setHaveWater(bool haveWater ){
		this.haveWater = haveWater;
	}
}

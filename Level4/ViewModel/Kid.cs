using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kid : MonoBehaviour {
	public Button button;

	public GameObject phRiver;
	public int x;

	public GameObject river;
	// Use this for initialization
	void Awake () {
		button = GetComponent<Button> ();	
		Destroy (gameObject, 3f);	
		button.onClick.AddListener(() => { GameControllerLevel4.instance.ClickKid();  KidClicked();});
	}
	
	// Update is called once per frame
	void Update () {
	

			
	}

	void OnDestroy(){
		phRiver.transform.SetParent (river.transform);
		phRiver.transform.SetSiblingIndex (x);
		phRiver.SetActive (true);

	}

	void KidClicked(){
		Destroy (gameObject);
	}


}

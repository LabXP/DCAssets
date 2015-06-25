using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Mountain : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public void OnPointerEnter(PointerEventData eventData){
		//print("Mouse entered " + gameObject.transform.name);
	}
	
	public void OnPointerExit(PointerEventData eventData){
		//print("Mouse left " + gameObject.transform.name);
	}
	
	public void OnDrop(PointerEventData eventData){
		Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Seed seed = eventData.pointerDrag.GetComponent<Seed> ();
		if (seed != null) {
			print ("b");
			if(transform.GetChild(seed.childIndex).GetComponent<Hole>()){
				transform.GetChild(seed.childIndex).GetComponent<Hole>().Filled = true;
				print ("a");
			}
		}
		
		
	}
	
	
}

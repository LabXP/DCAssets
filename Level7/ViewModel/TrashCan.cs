using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TrashCan : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public void OnPointerEnter(PointerEventData eventData){
		//print("Mouse entered " + gameObject.transform.name);
	}
	
	public void OnPointerExit(PointerEventData eventData){
		//print("Mouse left " + gameObject.transform.name);
	}
	
	public void OnDrop(PointerEventData eventData){
		Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);
		
		Trash trash = eventData.pointerDrag.GetComponent<Trash> ();
		if (trash != null) {
			print ("b");
			trash.parentToReturnTo = gameObject.transform;
			Destroy(trash.gameObject);
		}
		
		
	}
	
	
}

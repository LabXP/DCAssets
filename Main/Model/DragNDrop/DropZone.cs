using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData){
		print("Mouse entered " + gameObject.transform.name);
	}

	public void OnPointerExit(PointerEventData eventData){
		print("Mouse left " + gameObject.transform.name);
	}

	public void OnDrop(PointerEventData eventData){
		print("Mouse entered " + gameObject.transform.name);


	}


}

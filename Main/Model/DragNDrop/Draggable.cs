using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public void OnBeginDrag(PointerEventData eventData){
		print("BeginDrag");
	}

	public void OnDrag(PointerEventData eventData){
		print("Drag");
		transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){
		print("EndDrag");
	}

}

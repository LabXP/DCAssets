using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Seed : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public Transform parentToReturnTo = null;
	public GameObject mountain;

	void Awake(){
		mountain = FindObjectOfType<Mountain> ().gameObject;
	}

	public void OnBeginDrag(PointerEventData eventData){
		print("BeginDrag");
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		parentToReturnTo = transform.parent;

		transform.SetParent (transform.parent.parent);
	}
	public int childIndex;
	public void OnDrag(PointerEventData eventData){
		print("Drag");

		
		transform.position = eventData.position;

		for(int i=0; i < mountain.transform.childCount; i++) {
			if(this.transform.position.x < mountain.transform.GetChild(i).position.x+45 && this.transform.position.y > mountain.transform.GetChild(i).position.y-45) {
				
				print ("ola"+i);
				

				childIndex = i;
				
				break;
			}
		}

			
	}
	
	public void OnEndDrag(PointerEventData eventData){
		print("EndDrag");
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		transform.SetParent (parentToReturnTo);
	}
	
}

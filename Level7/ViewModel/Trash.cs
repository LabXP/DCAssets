using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public Transform parentToReturnTo = null;
	public GameObject street;

	public GameObject phStreet;
	public int x;
	
	void Awake(){
		street = FindObjectOfType<Street> ().gameObject;
	}


	void OnDestroy(){
		phStreet.transform.SetParent (street.transform);
		phStreet.transform.SetSiblingIndex (x);
		phStreet.SetActive (true);
	}


	public void OnBeginDrag(PointerEventData eventData){
		print("BeginDrag");
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		parentToReturnTo = transform.parent;
		
		transform.SetParent (transform.parent.parent);

		phStreet.transform.SetParent (street.transform);
		phStreet.transform.SetSiblingIndex (x);
		phStreet.SetActive (true);
	}

	public int childIndex;
	public void OnDrag(PointerEventData eventData){
		print("Drag");
		transform.position = eventData.position;
	
	}

	
	public void OnEndDrag(PointerEventData eventData){
		print("EndDrag");
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		transform.SetParent (parentToReturnTo);
		transform.SetSiblingIndex (x);

		phStreet.transform.SetParent (gameObject.transform.parent.parent);
		phStreet.SetActive (false);
	}
	
}

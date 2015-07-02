using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	// Segue o personagem só no x
	public Transform target;
	public float lookAheadFactor;

	void Update ()
	{
		transform.position = new Vector3 (target.transform.position.x + lookAheadFactor, transform.position.y, transform.position.z);
	}

}

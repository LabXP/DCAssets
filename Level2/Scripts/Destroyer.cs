using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
	// Aquele retangulo que é filho da camera
	// Tudo que encosta nele é destruido (cenario e obstaculos)
	void OnTriggerEnter2D (Collider2D other)
	{
		Destroy (other.gameObject);
	}
}

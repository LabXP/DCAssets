using UnityEngine;
using System.Collections;

public class BgSpawner : MonoBehaviour
{
	//Ele spawna o cenario no ponto que acaba o outro de antes

	public GameObject[] bgs;		//Array com os cenarios possiveis
	public float spawnTimer = 0.8f;			//De quanto em quanto tempo ele spawna
	
	void Start ()
	{
		Invoke ("Spawn", spawnTimer);
	}
	
	void Spawn ()
	{
		Instantiate (bgs [Random.Range (0, bgs.Length)], transform.position, Quaternion.identity);
	}
}

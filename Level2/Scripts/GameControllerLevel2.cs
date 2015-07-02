using UnityEngine;
using System.Collections;

public class GameControllerLevel2 : MonoBehaviour
{

	public GameObject[] obstacles;			//Array com osbtaculos
	public float minSpawnTime, maxSpawnTime;		//Os tempo limites pra spawnar obstaculos

	private GameObject spawnPoint;		// Ponto de spawn (filho da camera)

	void Start ()
	{
		spawnPoint = GameObject.Find ("SpawnPoint");

		StartCoroutine (SpawnObstacle ());
	}

	IEnumerator SpawnObstacle ()
	{
		while (true) {
			Instantiate (obstacles [Random.Range (0, obstacles.Length)], spawnPoint.transform.position, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (minSpawnTime, maxSpawnTime));
		}
	}
}

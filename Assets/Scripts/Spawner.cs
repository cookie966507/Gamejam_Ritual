using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] spirits;
	public GameObject camera;
	public float yRange;
	public float xRange = 0;
	public float camAhead = 7f;
	public float lifeTime = 15f;
	public float spawnFreqUpper = 1f;
	public float spawnFreqLower = .2f;
	public float zSpawn = 0f;
	public float yInitPos;
	
	
	// Use this for initialization
	void Start () {
		StartCoroutine ("spawnSpirits");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 camPos = camera.transform.position;
		transform.position = new Vector3 (camPos.x + camAhead, yInitPos, camPos.z); 
	}
	
	IEnumerator spawnSpirits ()
	{
		while (true) {
			int random = (int) Random.Range(0, spirits.Length);
			GameObject spirit = spirits[random];
			float xSpawn = transform.position.x;
			float ySpawn = transform.position.y;
			float yRangeTemp = Random.Range(-yRange, yRange);
			float xRangeTemp = Random.Range(-xRange, xRange);
			Vector3 startPos = new Vector3(xSpawn + xRangeTemp, yRangeTemp + ySpawn, zSpawn);
			Object spiritBallClone = Instantiate(spirit, startPos, spirit.transform.rotation);
			Destroy(spiritBallClone, lifeTime);
			yield return new WaitForSeconds(Random.Range(spawnFreqLower, spawnFreqUpper));
		}
	}
	
}

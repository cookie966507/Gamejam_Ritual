using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Level
{
	public class Fireplace : MonoBehaviour {

		private float fuel = 10f;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			fuel -= Time.deltaTime;
			if(fuel > 8f) {
				GetComponent<Animator>().SetInteger("FireLevel", 3);
			} else if (fuel > 6f) {
				GetComponent<Animator>().SetInteger("FireLevel", 2);
			} else if (fuel > 4f) {
				GetComponent<Animator>().SetInteger("FireLevel", 1);
			} else if (fuel <= 0f) {
				GetComponent<Animator>().SetInteger("FireLevel", 0);
			} 
		}

		void OnTriggerEnter2D(Collider2D col) {
			if(col.GetComponent<Tinder>()) {
				Destroy(col.gameObject);
				transform.GetChild(0).GetComponent<ParticleSystem>().Emit(200);
				transform.GetChild(0).GetComponent<ParticleSystem>().Play();
				fuel += 4f;
			}
		}
	}
}

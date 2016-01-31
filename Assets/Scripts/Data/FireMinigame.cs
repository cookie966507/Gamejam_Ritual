using UnityEngine;
using System.Collections;
using TeamUtility.IO;
using Assets.Scripts.Level;

namespace Assets.Scripts.Data
{
	public class FireMinigame : Minigame {

		[SerializeField]
		private GameObject logs;

		[SerializeField]
		private GameObject[] firePlaces;




		public override void Init ()
		{
			Winners = new System.Collections.Generic.List<PlayerID>();
			firePlaces[0] = (GameObject)GameObject.Instantiate(firePlaces[0], new Vector2(-5,1), Quaternion.identity);
			firePlaces[1] = (GameObject)GameObject.Instantiate(firePlaces[1], new Vector2(-5,-3), Quaternion.identity);
			firePlaces[2] = (GameObject)GameObject.Instantiate(firePlaces[2], new Vector2(5,1), Quaternion.identity);
			firePlaces[3] = (GameObject)GameObject.Instantiate(firePlaces[3], new Vector2(5,-3), Quaternion.identity);

			for(int i = 0; i < 20; i++) {
				GameObject.Instantiate(logs, new Vector2(0f, Random.Range(1f,-4f)), Quaternion.identity);
			}
		}

		public override void Run ()
		{
			int numDead = 0;
			int survivor = -1;
			for(int i = 0; i < 4; i++) {
				if(firePlaces[i].GetComponent<Fireplace>().Dead) numDead++;
				else survivor = i;
			}
			if(numDead == 3) {
				
				finished = true;
			}
		}


	}
}
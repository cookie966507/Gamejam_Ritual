using UnityEngine;
using System.Collections;
using TeamUtility.IO;
using Assets.Scripts.Level;
using System.Collections.Generic;

namespace Assets.Scripts.Data
{
	public class FireMinigame : Minigame {

		[SerializeField]
		private GameObject logs;

		[SerializeField]
		private GameObject[] firePlaces;

		private List<Fireplace> inGameFirePlaces;


		public override void Init ()
		{
			Winners = new System.Collections.Generic.List<PlayerID>();

			int numPlayers = GameManager.instance.AllPlayers.Count;

			if(GameManager.instance.CharacterToPlayer.ContainsKey(Assets.Scripts.Util.Enums.Characters.Opochtli)) {
				inGameFirePlaces.Add(((GameObject)GameObject.Instantiate(firePlaces[0], new Vector2(-5,1), Quaternion.identity)).GetComponent<Fireplace>());
			}
			if(GameManager.instance.CharacterToPlayer.ContainsKey(Assets.Scripts.Util.Enums.Characters.Zolin)) {
				inGameFirePlaces.Add(((GameObject)GameObject.Instantiate(firePlaces[1], new Vector2(-5,-3), Quaternion.identity)).GetComponent<Fireplace>());
			}
			if(GameManager.instance.CharacterToPlayer.ContainsKey(Assets.Scripts.Util.Enums.Characters.Yaotl)) {
				inGameFirePlaces.Add(((GameObject)GameObject.Instantiate(firePlaces[2], new Vector2(5,1), Quaternion.identity)).GetComponent<Fireplace>());
			}
			if(GameManager.instance.CharacterToPlayer.ContainsKey(Assets.Scripts.Util.Enums.Characters.Coatl)) {
				inGameFirePlaces.Add(((GameObject)GameObject.Instantiate(firePlaces[3], new Vector2(5,-3), Quaternion.identity)).GetComponent<Fireplace>());
			}

			for(int i = 0; i < 20; i++) {
				GameObject.Instantiate(logs, new Vector2(0f, Random.Range(1f,-4f)), Quaternion.identity);
			}
		}

		public override void Run ()
		{
			int numDead = 0;
			Fireplace survivor = null;
			foreach(Fireplace f in inGameFirePlaces) {
				if(f.Dead) numDead++;
				else survivor = f;
			}
			if(numDead == 3) {
				Winners.Add(GameManager.instance.CharacterToPlayer[survivor.linkedCharacter]);
				finished = true;
			}
		}


	}
}
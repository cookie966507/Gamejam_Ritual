using UnityEngine;
using System.Collections;
using TeamUtility.IO;

namespace Assets.Scripts.Data
{
	public class FireMinigame : Minigame {

		[SerializeField]
		private GameObject logs;

		[SerializeField]
		private GameObject firePlace;

		private float[] fireTimers = {10f, 10f, 10f, 10f};

		public override void Init ()
		{
			Winners = new System.Collections.Generic.List<PlayerID>();
		}

		public override void Run ()
		{
			for(int i = 0; i < 4; i++) {
				fireTimers[i] -= Time.deltaTime;
			}
		}


	}
}
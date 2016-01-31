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

		private float fireTimer = 10f;

		public override void Init ()
		{
			Winners = new System.Collections.Generic.List<PlayerID>();
		}

		public override void Run ()
		{
			fireTimer -= Time.deltaTime;
		}
	}
}
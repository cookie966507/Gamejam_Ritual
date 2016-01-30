using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
	public class Movement : ControllerObject {

		private bool facingRight = true;
		
		public bool FacingRight {
			get { return facingRight; }
		}
	}
}
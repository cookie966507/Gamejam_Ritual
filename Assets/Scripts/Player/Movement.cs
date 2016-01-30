using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
	public class Movement : ControllerObject {

		private bool facingRight = true;
        private float moveSpeed = 5f;

        public void MoveHorizontal(int dir, float ratio = 1f)
        {
            if (dir < 0)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime * ratio);
                facingRight = false;
            }
            else
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * ratio);
                facingRight = true;
            }
        }
        public void MoveVertical(int dir, float ratio = 1f)
        {
            if (dir < 0)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime * ratio);
            }
            else
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * ratio);
            }
        }

        public bool FacingRight
        {
			get { return facingRight; }
		}
	}
}
using UnityEngine;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class that handles player specific components of the controller
    /// Uses input
    /// </summary>
    public class PlayerController : Controller
    {
        void Update()
        {
            float hor = InputManager.GetAxis("Horizontal_P" + (int)id, id);
            float vert = InputManager.GetAxis("Vertical_P" + (int)id, id);

            if (hor > 0)
            {
                movement.MoveHorizontal(1, Mathf.Abs(hor));
            }
            else if (hor < 0)
            {
                movement.MoveHorizontal(-1, Mathf.Abs(hor));
            }
            if (vert > 0)
            {
                movement.MoveVertical(1, Mathf.Abs(vert));
            }
            else if (vert < 0)
            {
                movement.MoveVertical(-1, Mathf.Abs(vert));
            }

            if(InputManager.GetButtonDown("B_P" + (int)id, id))
            {
                movement.InitRoll();
            }
        }
    }
}

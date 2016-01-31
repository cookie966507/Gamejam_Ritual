using UnityEngine;
using TeamUtility.IO;
using Assets.Scripts.Level;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class that handles player specific components of the controller
    /// Uses input
    /// </summary>
    public class PlayerController : Controller
    {
        private bool pickedUpThisTurn;

        new void Update()
        {
            base.Update();
            if(heldObject != null)
            {
                heldObject.transform.position = transform.position + new Vector3(0, 0.1f, 0);
                heldObject.Sprite.transform.position = holdPoint.position;
                heldObject.UpdateSortingLayer();
                anim.SetBool("Carry", true);
            }
            if (Active)
            {
                float hor = InputManager.GetAxis("Horizontal_P" + (int)id, id);
                float vert = InputManager.GetAxis("Vertical_P" + (int)id, id);

                if (hor > 0)
                {
                    movement.MoveHorizontal(1, Mathf.Abs(hor));
                    anim.SetFloat("Speed", 1f);
                    sprite.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (hor < 0)
                {
                    movement.MoveHorizontal(-1, Mathf.Abs(hor));
                    anim.SetFloat("Speed", 1f);
                    sprite.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (vert > 0)
                {
                    movement.MoveVertical(1, Mathf.Abs(vert));
                    anim.SetFloat("Speed", 1f);
                }
                else if (vert < 0)
                {
                    movement.MoveVertical(-1, Mathf.Abs(vert));
                    anim.SetFloat("Speed", 1f);
                }

                if (hor == 0 && vert == 0) anim.SetFloat("Speed", 0);

                if (InputManager.GetButtonDown("LB_P" + (int)id, id) && !heldObject)
                {
                    movement.InitRoll(-1);
                    anim.SetBool("Rolling", true);
                }
                if (InputManager.GetButtonDown("RB_P" + (int)id, id) && !heldObject)
                {
                    movement.InitRoll(1);
                    anim.SetBool("Rolling", true);
                }

                if (InputManager.GetAxis("RightTrigger_P" + (int)id, id) == 0)
                {
                    if (pickedUpThisTurn)
                        pickedUpThisTurn = false;
                    else
                        ThrowObject();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    sprite.position = transform.position + new Vector3(0, 10, 0);
                    falling = true;
                }
            }
        }

        void OnTriggerStay2D(Collider2D col)
        {
            if (heldObject || movement.Rolling) return;
            if (InputManager.GetAxis("RightTrigger_P" + (int)id, id) > 0)
            {
                heldObject = col.GetComponent<SpriteObject>();
                if (heldObject)
                {
                    pickedUpThisTurn = true;
                    heldObject.Active = false;
                    heldObject.Falling = false;
                    heldObject.transform.parent = transform;
                    heldObject.Sprite.position = holdPoint.position;
                    movement.MoveSpeed /= 2;
                }
            }
        }
    }
}

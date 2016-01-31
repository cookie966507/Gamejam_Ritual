using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;

namespace Assets.Scripts.Level
{
    public class MeleeHitbox : MonoBehaviour
    {
        private int damage = -10;
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag.Equals("Player"))
            {
                Controller controller = col.GetComponent<Controller>();
                controller.LifeComponent.ModifyHealth(damage, true);
                if (transform.root.GetComponent<Controller>().MovementComponent.FacingRight) controller.MovementComponent.InitRoll(1);
                else controller.MovementComponent.InitRoll(-1);
            }
        }
    } 
}

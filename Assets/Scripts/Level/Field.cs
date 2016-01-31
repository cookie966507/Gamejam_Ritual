using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts.Level
{
    public class Field : MonoBehaviour
    {

        void OnTriggerExit2D(Collider2D col)
        {
			if(col.GetComponent<SpriteObject>()) {
				col.GetComponent<SpriteObject>().FellOffEdge();
			}
//            if(col.tag.Equals("Player"))
//            {
//                Controller fallingPlayer = col.GetComponent<Controller>();
//				fallingPlayer.FellOffEdge();
////                fallingPlayer.LifeComponent.Deactivate();
//			}
        }
    } 
}

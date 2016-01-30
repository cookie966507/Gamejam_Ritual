using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Level
{
    public class Barrel : SpriteObject
    {
        Collider2D col;

        protected override void Init()
        {
            base.Init();
            col = GetComponent<Collider2D>();
            col.enabled = false;
            falling = true;
        }

        protected override void HitGround()
        {
            base.HitGround();
            col.enabled = true;
        }
    } 
}

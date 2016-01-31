using UnityEngine;
using System.Collections.Generic;
using TeamUtility.IO;

namespace Assets.Scripts.Data
{
    public class MeleeMinigame : Minigame
    {
        public override void Init()
        {
            Winners = new List<PlayerID>();
            for(int i = 0; i < GameManager.instance.AllPlayers.Count; i++)
            {
                GameManager.instance.AllPlayers[i].MovementComponent.MeleeEnabled = true;
            }
        }
        public override void Run()
        {

        }
    }
}

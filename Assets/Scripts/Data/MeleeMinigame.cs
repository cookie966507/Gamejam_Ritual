using UnityEngine;
using System.Collections.Generic;
using TeamUtility.IO;

namespace Assets.Scripts.Data
{
    public class MeleeMinigame : Minigame
    {
        private int numAlive;
        public override void Init()
        {
            numAlive = GameManager.instance.AllPlayers.Count;
            Winners = new List<PlayerID>();
            for(int i = 0; i < GameManager.instance.AllPlayers.Count; i++)
            {
                GameManager.instance.AllPlayers[i].MovementComponent.MeleeEnabled = true;
            }
        }
        public override void Run()
        {
            if (numAlive == 1)
            {
                for (int i = 0; i < GameManager.instance.AllPlayers.Count; i++)
                {
                    if (GameManager.instance.AllPlayers[i].LifeComponent.Health > 0) Winners.Add(GameManager.instance.AllPlayers[i].ID);
                    finished = true;
                    Debug.Log("Complete");
                }
            }
            else
            {
                int temp = 0;
                for (int i = 0; i < GameManager.instance.AllPlayers.Count; i++)
                {
                    if (GameManager.instance.AllPlayers[i].LifeComponent.Health > 0) temp++;
                }
                numAlive = temp;
            }
        }
    }
}

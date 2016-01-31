using UnityEngine;
using System.Collections;
using TeamUtility.IO;
using Assets.Scripts.Level;
using Assets.Scripts.Timers;

namespace Assets.Scripts.Data
{
    public class FishMinigame : Minigame
    {
        [SerializeField]
        private GameObject fishPrefab;
        RepetitionTimer spawnTimer;

        private int[] fishCaught;
        private int targetFish = 5;

        public delegate void EndGameEvent();
        public static event EndGameEvent EndGame;
        
        public override void Init()
        {
            spawnTimer = gameObject.AddComponent<RepetitionTimer>();
            spawnTimer.Initialize(0.5f, "Fish Spawner");
            spawnTimer.TimeOut += new RepetitionTimer.TimerEvent(SpawnFish);
            spawnTimer.FinalTick += new RepetitionTimer.TimerEvent(SpawnFish);
            fishCaught = new int[4];
            Winners = new System.Collections.Generic.List<PlayerID>();
        }

        private void SpawnFish(RepetitionTimer t)
        {
            Bounds b = GameManager.instance.field.GetComponent<Collider2D>().bounds;
            Vector2 pos = new Vector2(Random.Range(b.min.x, b.max.x), Random.Range(b.min.y, b.max.y));
            GameObject fish = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            fish.GetComponent<Fish>().Game = this;
        }

        public override void Run()
        {
            //throw new NotImplementedException();
        }

        public void FishCaught(PlayerID id)
        {
            fishCaught[((int)id)-1]++;
            if(fishCaught[((int)id)-1] >= targetFish)
            {
                finished = true;
                spawnTimer.Initialize(0, "Fish Timer", 0);
                Winners.Add(id);
                if (EndGame != null) EndGame();
            }
        }
    }
}

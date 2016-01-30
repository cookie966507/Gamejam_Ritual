using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Assets.Scripts.Player;
//using System;

namespace Assets.Scripts.Data
{
    public class FallingFishMinigame : Minigame
    {
        //public int FishPoolSize = 20;
        ////public int count = 0;
        
        //[SerializeField]
        //private float gameTime = 10f;
        //[SerializeField]
        //private List<GameObject> fish;
        //[SerializeField]
        //private GameObject fishPrefab;

        //private List<GameObject> fallingFish;

        //private List<Controller> controllers;

        public override void Init()
        {
        //    controllers =  GameManager.instance.AllPlayers;
        //    for (int x = 0; x < FishPoolSize; x++)
        //        fish.Add(fishPrefab);
        }

        public override void Run()
        {
        //   // throw new NotImplementedException();
        }

        //IEnumerator StartFishFall()
        //{
        //    while (true)
        //    {
        //        GameObject fishSpawn = fish.Remove(fishPrefab);
        //        //count++;
        //        //if (count > 19) count = 0;
        //        float xSpawn = Random.Range(-6f, 6f);
        //        float ySpawnShadow = Random.Range(-2.8f, 1.5f);
        //        float ySpawnFish = ySpawnShadow + 7f;
        //        float yRangeTemp = Random.Range(-yRange, yRange);
        //        float xRangeTemp = Random.Range(-xRange, xRange);
        //        Vector3 startPos = new Vector3(xSpawn + xRangeTemp, yRangeTemp + ySpawn, zSpawn);
        //        Object spiritBallClone = Instantiate(spirit, startPos, spirit.transform.rotation);
        //        Destroy(spiritBallClone, lifeTime);
        //        yield return new WaitForSeconds(Random.Range(spawnFreqLower, spawnFreqUpper));
        //    }
        //}
    }
}

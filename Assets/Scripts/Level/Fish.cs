using UnityEngine;
using Assets.Scripts.Level;
using Assets.Scripts.Data;
using Assets.Scripts.Player;

namespace Assets.Scripts.Level
{
    public class Fish : SpriteObject
    {
        private FishMinigame game;

        void OnEnable()
        {
            FishMinigame.EndGame += EndGame;
        }
        void OnDisable()
        {
            FishMinigame.EndGame -= EndGame;
        }

        protected override void Init()
        {
            base.Init();
            falling = true;
        }
        protected override void HitGround()
        {
            base.HitGround();
            Destroy(transform.root.gameObject);
        }

        private void EndGame()
        {
            GetComponentInChildren<Collider2D>().enabled = false;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.transform.tag.Equals("Player"))
            {
                if(Mathf.Abs(GetComponent<SpriteRenderer>().sortingOrder - col.GetComponent<SpriteRenderer>().sortingOrder) < 100)
                {
                    game.FishCaught(col.GetComponent<Controller>().ID);
                    Destroy(transform.root.gameObject);
                }
            }
        }

        public FishMinigame Game
        {
            set { game = value; }
        }
    }
}
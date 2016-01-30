using UnityEngine;

namespace Assets.Scripts.Level
{
    public abstract class SpriteObject : MonoBehaviour
    {
        protected float heightOffGround = 0f;
        protected bool falling = false;
        protected bool active = true;

        [SerializeField]
        protected Transform sprite;

        void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            UpdateSortingLayer();
        }

        public void Update()
        {
            heightOffGround = sprite.position.y - transform.position.y;
            if (heightOffGround > 0 && falling)
            {
                active = false;
                Fall();
            }
            else if(falling && !active)
            {
                HitGround();
            }
        }

        protected void Fall()
        {
            sprite.transform.Translate(-Vector2.up * 9.8f * Time.deltaTime);
        }

        protected virtual void HitGround()
        {
            sprite.transform.position = transform.position;
            falling = false;
            active = true;
        }

        public void UpdateSortingLayer()
        {
            sprite.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
            GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100 + 1);
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool Falling
        {
            get { return falling; }
            set { falling = value; }
        }
    } 
}

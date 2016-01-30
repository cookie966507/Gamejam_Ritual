using UnityEngine;

namespace Assets.Scripts.Level
{
    public abstract class SpriteObject : MonoBehaviour
    {
        protected float heightOffGround = 0f;
        protected bool falling = false;
        protected bool active = true;
        protected float force = 0f;

        private float throwVel = 0f;

        [SerializeField]
        protected Transform sprite;

        void OnDisable()
        {
            sprite.transform.position = transform.position;
            force = 0f;
            falling = false;
        }

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
            else if(falling && !active && heightOffGround <=0)
            {
                HitGround();
            }
        }

        protected void Fall()
        {
            sprite.transform.Translate(-Vector2.up * 5f * Time.deltaTime, Space.World);
            force = Mathf.SmoothDamp(force, 0f, ref throwVel, 0.1f);
            transform.Translate(Vector2.right * force * Time.deltaTime, Space.World);
        }

        protected virtual void HitGround()
        {
            sprite.transform.position = transform.position;
            falling = false;
            active = true;
            force = 0f;
        }

        public void UpdateSortingLayer()
        {
            sprite.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
            GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100 + 1);
        }

        public virtual bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool Falling
        {
            get { return falling; }
            set { falling = value; }
        }

        public float Force
        {
            get { return force; }
            set { force = value; }
        }

        public Transform Sprite
        {
            get { return sprite; }
        }
    } 
}

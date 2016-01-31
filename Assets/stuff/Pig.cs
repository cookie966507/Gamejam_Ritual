using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

namespace Assets.Scripts.Level
{

    public class Pig : SpriteObject
    {

        [SerializeField]
        private float directionMinTime, directionMaxTime, speed;

        private Vector2 runDirection;
        private Bounds b;

        // Use this for initialization
        void Start()
        {
            StartCoroutine("pickDirection");
            b = GameManager.instance.field.GetComponent<Collider2D>().bounds;
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
            if (active)
            {
                transform.Translate(runDirection.x * speed, runDirection.y * speed, 0);

                //keep pig from running out
                if (!b.Contains(transform.position))
                {
                    Vector3 temp = b.ClosestPoint(transform.position);
                    Vector3 directionScaled = temp - transform.position;
                    float magnitude = directionScaled.magnitude;
                    runDirection = new Vector3(directionScaled.x / magnitude, directionScaled.y / magnitude, 0);
                    flipSprite(runDirection);
                }
            }
            //Debug.Log("Height: " + heightOffGround);
            if (heightOffGround > .9) transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), 1);
            if (heightOffGround <= 0) transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), 1);

        }

        void OnTriggerStay2D(Collider2D col)
        {
            if (col.transform.tag.Equals("Player"))
            {
               // Debug.Log("Print!");

                Vector3 temp = transform.position - col.transform.position;
                float magnitude = temp.magnitude;

                runDirection = new Vector3(temp.x / magnitude, temp.y / magnitude, 0);
                flipSprite(runDirection);
            }
        }

        public void flipSprite(Vector3 runDirection)
        {
            //Flip if needed
            if (runDirection.x < 0) transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
            if (runDirection.x > 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }

        public IEnumerator pickDirection()
        {
            while (true)
            {
                runDirection = Random.onUnitSphere;
                flipSprite(runDirection);
                yield return new WaitForSeconds(Random.Range(directionMinTime, directionMaxTime));
            }
        }
    }
}

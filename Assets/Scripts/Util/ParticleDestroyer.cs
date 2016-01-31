using UnityEngine;

namespace Assets.Scipts.Util
{
    public class ParticleDestroyer : MonoBehaviour
    {
        public float destroyTime = 1f;

        void Start()
        {
            Destroy(gameObject, destroyTime);
        }
    } 
}

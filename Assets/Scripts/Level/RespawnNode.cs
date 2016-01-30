using UnityEngine;
using System.Collections;
using TeamUtility.IO;

namespace Assets.Scripts.Level
{
    public class RespawnNode : MonoBehaviour
    {
        [SerializeField]
        private PlayerID id;

        public PlayerID ID
        {
            get { return id; }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
//using Assets.Scripts.Level;
//using Assets.Scripts.Player;
//using Assets.Scripts.Timers;
//using Assets.Scripts.Util;
using TeamUtility.IO;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Manager to control everything as the top of the pyramid
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Use a singleton instance to make sure there is only one
        /// </summary>
        public static GameManager instance;

        // List of all the controllers of the players
        //private List<Controller> controllers;

        [SerializeField]
        private GameObject playerPrefab;

        private int numDead = 0;

        // Sets up singleton instance. Will remain if one does not already exist in scene
        void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            //controllers = new List<Controller>();
        }

        /*
        public void InitializePlayer(PlayerID id)
        {
            GameObject newPlayer = Instantiate(playerPrefab);
            Controller controller = newPlayer.GetComponent<Controller>();
            controller.ID = id;
            controllers.Add(controller);
            controller.Disable();
        }

        public void RemovePlayer(PlayerID id)
        {
            Controller removePlayer = controllers.Find(x => x.ID.Equals(id));
            controllers.Remove(removePlayer);
        }
        */

        #region C# Properties

        #endregion
    }
}

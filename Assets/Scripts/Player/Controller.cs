using UnityEngine;
using System.Collections.Generic;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// This class wil manage all the player's (and enemy's) components,
    /// such as movement, data , etc
    /// Will also allow the different components to talk to one another
    /// </summary>
    public class Controller : MonoBehaviour
    {
        // ID for identifying which player is accepting input
        [SerializeField]
        protected PlayerID id;

        // Componenets to manage
        protected Movement movement;
        protected Life life;

        void Awake()
        {
            // Init all componenets
            InitializePlayerComponents();
        }

        void Start()
        {

        }

        /// <summary>
        /// Assigning references
        /// </summary>
        protected virtual void InitializePlayerComponents()
        {
            // Add all components to manage
            life = GetComponent<Life>();
            movement = GetComponent<Movement>();

            // Tell all components this is their controller
            life.Controller = this;
            movement.Controller = this;

        }

        /// <summary>
        /// Disables the player
        /// </summary>
        public void Disable()
        {
           gameObject.SetActive(false);
        }

        /// <summary>
        /// Reenables the player
        /// </summary>
        public void Enable()
        {
           gameObject.SetActive(true);

        }

        #region C# Properties
       
        /// <summary>
        /// Life component of the player
        /// </summary>
        public Life LifeComponent
        {
            get { return life; }
        }
        /// <summary>
        /// Parkour component of the player
        /// </summary>
        public Movement MovementComponent
        {
            get { return movement; }
        }
        
        /// <summary>
        /// ID of the player
        /// </summary>
        public PlayerID ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}

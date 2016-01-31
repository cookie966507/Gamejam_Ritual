using UnityEngine;
using System.Collections.Generic;
using TeamUtility.IO;
using Assets.Scripts.Level;
using System;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// This class wil manage all the player's (and enemy's) components,
    /// such as movement, data , etc
    /// Will also allow the different components to talk to one another
    /// </summary>
    public class Controller : SpriteObject
    {
        // ID for identifying which player is accepting input
        [SerializeField]
        protected PlayerID id;

        // Componenets to manage
        protected Movement movement;
        protected Life life;

        [SerializeField]
        protected Transform holdPoint;

        protected SpriteObject heldObject;

        protected Animator anim;

        void Awake()
        {
            // Init all componenets
            InitializePlayerComponents();
        }

        void Start()
        {
            base.Init();
            anim = GetComponentInChildren<Animator>();
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

            active = true;
        }

        public void ThrowObject()
        {
            if (heldObject)
            {
                if (movement.FacingRight)
                    heldObject.Force = 30f;
                else
                    heldObject.Force = -30f;
                heldObject.Falling = true;
                heldObject.transform.parent = null;
                heldObject = null;
                movement.MoveSpeed *= 2;
                anim.SetBool("Carry", false);
            }
        }

        /// <summary>
        /// Disables the player
        /// </summary>
        public void Disable()
        {
           active = false;
           gameObject.SetActive(false);
        }

        /// <summary>
        /// Reenables the player
        /// </summary>
        public void Enable()
        {
           active = true;
           gameObject.SetActive(true);

        }

        #region C# Properties

        public override bool Active
        {
            get { return active; }
            set
            {
                active = value;
                if (!active) ThrowObject();
            }
        }

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

        public Animator Anim
        {
            get { return anim; }
        }
        #endregion
    }
}

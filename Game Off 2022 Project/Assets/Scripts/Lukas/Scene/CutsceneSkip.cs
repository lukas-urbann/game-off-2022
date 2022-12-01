using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lukas.Scene
{
    public class CutsceneSkip : MonoBehaviour
    {
        [SerializeField] private List<Animator> anim = new List<Animator>();
        private InputSystemFirstPersonControls inputActions;
        public InputSystemFirstPersonControls InputActions { get => inputActions; }

        private void Awake()
        {
            inputActions = new InputSystemFirstPersonControls();
        }
        
        private void Update()
        {
            if (inputActions.FPSController.Jump.WasPressedThisFrame())
                foreach (Animator anim in anim)
                    anim.speed = 50;
            
        }
        
        private void OnEnable()
        {
            inputActions.Enable();
        }
        
        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}

using DataChange;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _3DFP
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement"), SerializeField]
        private float moveSpeed;

        [SerializeField]
        private Transform orientation;

        private float horizontalInput;
        private float verticalInput;

        [HideInInspector]
        public Vector2 look;

        private Vector3 moveDirection;
        public bool cursorInputForLook = true;

        private Rigidbody rb => GetComponent<Rigidbody>();
        // Start is called before the first frame update
        void Start()
        {
            //在Inspector窗口设置即可
            //rb.freezeRotation = true;
        }
        
        // Update is called once per frame
        void Update()
        {

        }


        #region Listener
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }
        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        } 
        #endregion
        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            moveDirection = newMoveDirection;
            Debug.Log(moveDirection);
        }
        
    }

}
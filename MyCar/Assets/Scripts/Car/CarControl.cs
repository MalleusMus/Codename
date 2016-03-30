using UnityEngine;
using System.Collections;

namespace MyCar {
    class CarControl : MonoBehaviour {

        public float speed = 2.0f;
        public WheelCollider frontLeft = null;
        public WheelCollider frontRight = null;
        public WheelCollider backLeft = null;
        public WheelCollider backRight = null;

        public void Start() {

        }

        public void Update() {
            
        }

        public void FixedUpdate() {
            float torque = 0.0f;
            torque = Input.GetAxis("AxisV") * speed;

            frontLeft.motorTorque = torque;
            frontRight.motorTorque = torque;
            backLeft.motorTorque = torque;
            backRight.motorTorque = torque;
        }
    }
}

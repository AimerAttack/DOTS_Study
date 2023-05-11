using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class RotateCube : MonoBehaviour
    {
        public float rotateSpeed = 360;

        private void Update()
        {
            transform.Rotate(new Vector3(0,rotateSpeed * Time.deltaTime,0));
        }
    }
}
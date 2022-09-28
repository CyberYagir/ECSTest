using System;
using UnityEngine;

namespace Mono
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 offcet;
        [SerializeField] private Transform target;
        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offcet, Time.fixedDeltaTime * speed);
        }
    }
}

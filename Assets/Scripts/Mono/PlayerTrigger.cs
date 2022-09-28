using System;
using UnityEngine;
using UnityEngine.Events;
using Views;

namespace Mono
{
    public class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var view = other.GetComponent<UnitView>();
            if (view)
            {
                view.Death();
            }
        }
    }
}

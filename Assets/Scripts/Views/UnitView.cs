using DG.Tweening;
using UnityEngine;

namespace Views
{
    public class UnitView : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected Transform rifle;
        [SerializeField] protected bool isDead;
        
        protected static readonly int Run = Animator.StringToHash("Run");
        protected static readonly int Shoot = Animator.StringToHash("Shoot");
        public bool IsDeath => isDead;
        public void Death()
        {
            isDead = true;
        }
        public Rigidbody Rigidbody => rb;
        public Animator Animator => animator;

        public virtual void SetRun(bool state)
        {

        }
    }
}
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using Views;

namespace Mono
{
    public class Ragdoller : MonoBehaviour
    {
        [SerializeField] private ParticleSystem blood;
        [SerializeField] private Rigidbody[] bones;
        [SerializeField] private Collider[] colliders;
        [SerializeField] private EnemyView enemyView;
        [SerializeField] private Renderer renderer;
        [SerializeField] private CapsuleCollider capsuleCollider;
        private Material startMaterial;
        public void Ragdoll(EnemyPool pool)
        {
            startMaterial = renderer.sharedMaterial;
            capsuleCollider.enabled = false;
            blood.Play();
            enemyView.Animator.enabled = false;
            renderer.shadowCastingMode = ShadowCastingMode.Off;
            
            renderer.material.DOFade(0, 2).SetDelay(5).onComplete += () => pool.AddToPool(enemyView);
            
            for (int i = 0; i < bones.Length; i++)
            {
                bones[i].isKinematic = false;
                colliders[i].enabled = true;
            }
        }

        public void DisableRagdoll()
        {
            capsuleCollider.enabled = true;
            enemyView.Animator.enabled = true;
            renderer.shadowCastingMode = ShadowCastingMode.On;
            renderer.sharedMaterial = startMaterial;
            for (int i = 0; i < bones.Length; i++)
            {
                bones[i].isKinematic = true;
                colliders[i].enabled = false;
            }
        }
    }
}

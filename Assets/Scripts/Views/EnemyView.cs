using DG.Tweening;
using Enemy;
using Mono;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Views
{
    public class EnemyView : UnitView
    {
        [SerializeField] private MultiAimConstraint aim;
        [SerializeField] private Ragdoller ragdoller;
        [SerializeField] private ParticleSystem bullets;
        [SerializeField] protected EnemyData enemyData;

        public Ragdoller Ragdoll => ragdoller;
        public EnemyData GetEnemy() => enemyData;


        public override void SetRun(bool state)
        {
            base.SetRun(state);
            animator.SetBool(Run, state);
            animator.SetBool(Shoot, state);

            aim.weight = state ? 0 : 1;
        }

        public void MoveAim(Vector3 playerPos)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(playerPos - transform.position), 10 * Time.fixedDeltaTime);
        }

        public void Reset()
        {
            isDead = false;
        }

        public void ShootBullet()
        {
            bullets.Emit(1);
        }
    }
}

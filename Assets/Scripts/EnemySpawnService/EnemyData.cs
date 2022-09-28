using UnityEngine;
using Views;

namespace Enemy
{
    [System.Serializable]
    public struct EnemyData
    {
        private EnemyView enemy;
        private bool readyToShoot;
        private float time;
        
        
        [SerializeField] private float speed;
        [SerializeField] private float shootDistance;
        [SerializeField] private float shootCooldown;
        
        public EnemyView EnemyView => enemy;
        public Transform Transform => enemy.transform;
        public Rigidbody Rigidbody => enemy.Rigidbody;
        public float Speed => speed;
        public float Distance => shootDistance;
        public bool ReadyShoot => readyToShoot;

        public EnemyData(EnemyView enemy, EnemyData parameters)
        {
            this.enemy = enemy;
            this.speed = parameters.speed;
            this.shootDistance = parameters.shootDistance;
            this.readyToShoot = false;
            this.shootCooldown = parameters.shootCooldown;
            this.time = 0;
        }

        public void ShootCalculate()
        {
            time += Time.deltaTime;
            if (time >= shootCooldown)
            {
                enemy.ShootBullet();
                time = 0;
            }
        }
        public void SetReadyShoot() => readyToShoot = true;

        public void NotReady()
        {
            readyToShoot = false;
        }
    }
}

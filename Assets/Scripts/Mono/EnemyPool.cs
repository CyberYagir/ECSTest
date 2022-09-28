using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Mono
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private SceneView scene;

        private LinkedList<EnemyView> enemies = new LinkedList<EnemyView>();

        public void Init()
        {
            for (int i = 0; i < gameData.MaxUnits * 1.5f; i++)
            {
                var enemy = Instantiate(scene.prefabs.EnemyPrefab);
                enemy.gameObject.SetActive(false);
                enemies.AddLast(enemy);
            }
        }


        public EnemyView GetFromPool()
        {
            if (enemies.First != null)
            {
                var first =  enemies.First.Value;
                if (enemies.First.Value.IsDeath)
                {
                    enemies.First.Value.Ragdoll.DisableRagdoll();
                    enemies.First.Value.Reset();
                }
                enemies.RemoveFirst();
                return first;
            }

            return null;
        }


        public void AddToPool(EnemyView enemy)
        {
            enemy.gameObject.SetActive(false);
            enemies.AddLast(enemy);
        }
    }
}

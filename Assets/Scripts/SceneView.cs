using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views;

public sealed class SceneView : MonoBehaviour
{
    [System.Serializable]
    public struct PrefabsData
    {
        [SerializeField] private EnemyView enemy;

        public EnemyView EnemyPrefab => enemy;
    }
    
    [System.Serializable]
    public struct UIData
    {
        [SerializeField] private Joystick joystick;

        public Joystick Joystick => joystick;
    }

    public PrefabsData prefabs;
    public UIData uiData;
    
    
    [SerializeField] private PlayerView player;
    public PlayerView Player => player;
}

using Mono;
using UnityEngine;

namespace Views
{
    public class PlayerView : UnitView
    {
        [SerializeField] private PlayerTrigger trigger;
        [SerializeField] private PlayerData playerData;
        
        
        public PlayerTrigger Trigger => trigger;
        public PlayerData GetStartData() => playerData;


        public override void SetRun(bool state)
        {
            base.SetRun(state);
            animator.SetBool(Run, state);
        }
    }
}

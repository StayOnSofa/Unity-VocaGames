using UnityEngine;
using Vocagames.Player.Stats;

namespace Vocagames.Player.Types
{
    public class RandomColorSkill : Skill
    {
        public RandomColorSkill() : base(new ToFarCondition(3)) { }
        
        public override PlayerInfoState UpdateState(PlayerInfoState state)
        {
            state.Color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            return state;
        }
    }
}
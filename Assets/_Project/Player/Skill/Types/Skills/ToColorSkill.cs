using UnityEngine;
using Vocagames.Player.Stats;

namespace Vocagames.Player.Types
{
    public class ToColorSkill : Skill
    {
        private Color _color;
        
        public ToColorSkill(Color color) : base(new ToFastCondition(3))
        {
            _color = color;
        }

        public override PlayerInfoState UpdateState(PlayerInfoState state)
        {
            state.Color = _color;
            return state;
        }
    }
}
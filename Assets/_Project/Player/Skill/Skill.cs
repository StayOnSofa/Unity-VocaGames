using Vocagames.Player.Stats;

namespace Vocagames.Player
{
    public abstract class Skill
    {
        private ICondition _condition;
        private bool _flagInCooldown;

        public Skill(ICondition condition)
        {
            _condition = condition;
        }
        
        public bool CheckState(PlayerInfoState state)
        {
            return _condition.Check(state);
        }

        public void Cooldown()
        {
            _flagInCooldown = false;
        }

        public PlayerInfoState TryUpdateState(PlayerInfoState state)
        {
            if (!_flagInCooldown)
            {
                state = UpdateState(state);
                _flagInCooldown = true;
            }

            return state;
        }

        public abstract PlayerInfoState UpdateState(PlayerInfoState state);
    }
}
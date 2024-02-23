using Vocagames.Player.Stats;

namespace Vocagames.Player.Types
{
    public class ToFastCondition : ICondition
    {
        private float _speed;

        public ToFastCondition(float speed)
        {
            _speed = speed;
        }

        public bool Check(PlayerInfoState state)
        {
            return state.Speed > _speed;
        }
    }
}
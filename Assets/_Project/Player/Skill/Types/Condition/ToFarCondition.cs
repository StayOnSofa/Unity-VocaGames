using Vocagames.Player.Stats;

namespace Vocagames.Player.Types
{
    public class ToFarCondition : ICondition
    {
        private float _distance;

        public ToFarCondition(float distance)
        {
            _distance = distance;
        }

        public bool Check(PlayerInfoState state)
        {
            return state.TraveledDistance > _distance;
        }
    }
}
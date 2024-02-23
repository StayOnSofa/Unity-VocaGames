using Vocagames.Player.Stats;

namespace Vocagames.Player
{
    public interface ICondition
    {
        public bool Check(PlayerInfoState state);
    }
}
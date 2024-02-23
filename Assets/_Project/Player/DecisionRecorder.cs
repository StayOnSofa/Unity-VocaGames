using System;
using System.Collections.Generic;
using Vocagames.Player.Stats;

namespace Vocagames.Player
{
    public class DecisionRecorder : IDisposable
    {
        private DecisionPlayer _player;
        private Queue<PlayerInfoState> _queue;
        
        public DecisionRecorder(DecisionPlayer player)
        {
            _queue = new();
            
            _player = player;
            _player.OnUpdateState += RecordState;
        }

        private void RecordState(PlayerInfoState state)
        {
            _queue.Enqueue(state);
        }

        public IEnumerable<PlayerInfoState> GetRecordedStates()
        {
            foreach (var state in _queue)
                yield return state;

            _queue.Clear();
        }

        public void Dispose()
        {
            _player.OnUpdateState -= RecordState;
        }
    }
}
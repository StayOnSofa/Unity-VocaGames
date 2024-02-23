using System.Collections.Generic;
using UnityEngine;
using Vocagames.Player.Stats;

namespace Vocagames.Player
{
    public class SequencePlaybackPlayer : Player
    {
        private Queue<PlayerInfoState> _statesQueue;
        
        public void Constructor(IEnumerable<PlayerInfoState> sequence)
        {
            _statesQueue = new();

            foreach (var state in sequence)
                _statesQueue.Enqueue(state);
        }

        protected override PlayerInfoState UpdateState(PlayerInfoState defaultState)
        {
            if (_statesQueue.Count > 0)
                return _statesQueue.Dequeue();

            var state = defaultState;
            
            //Stay still
            state.Speed = 0;
            state.Direction = Vector3.zero;
            
            return state;
        }
    }
}
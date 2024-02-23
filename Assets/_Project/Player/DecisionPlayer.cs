using System;
using System.Collections.Generic;
using UnityEngine;
using Vocagames.Player.Stats;

using Random = UnityEngine.Random;

namespace Vocagames.Player
{
    public class DecisionPlayer : Player
    {
        public event Action<PlayerInfoState> OnUpdateState;
        
        [Space]
        [SerializeField] private float _minSpeed = 1;
        [SerializeField] private float _maxSpeed = 5;

        private IEnumerable<Skill> _skills;

        public void Constructor(IEnumerable<Skill> skills)
        {
            _skills = skills;
        }

        public void SkillsCooldown()
        {
            foreach (var skill in _skills)
                skill.Cooldown();
        }

        private float GetRandomSpeed()
        {
            return Random.Range(_minSpeed, _maxSpeed);
        }

        private Vector3 GetRandomDirection()
        {
            var direction = Vector3.Normalize(Random.onUnitSphere);
            direction.y = 0;
            
            return direction;
        }

        protected override PlayerInfoState UpdateState(PlayerInfoState previousState)
        {
            var state = previousState;
            
            state.Direction = GetRandomDirection();
            state.Speed = GetRandomSpeed();

            foreach (var skill in _skills)
            {
                if (skill.CheckState(state))
                    state = skill.TryUpdateState(state);
            }
            
            OnUpdateState?.Invoke(state);
            return state;
        }
    }
}
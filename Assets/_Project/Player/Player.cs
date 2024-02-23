using UnityEngine;
using Vocagames.Player.Graphics;
using Vocagames.Player.Stats;

namespace Vocagames.Player
{
    public abstract class Player : MonoBehaviour
    {
        public const int SecondsPerTick = 1;
        
        [SerializeField] private PlayerGraphics _graphics;

        private Color _defaultColor;
        private PlayerInfoState _playerState;
        
        private float _timer;
        
        private Vector3 _spawnCoords;
        private Vector3 _previousCoords;
        
        public void Constructor(Color defaultColor)
        {
            _spawnCoords = transform.position;
            _defaultColor = defaultColor;
            
            ToDefaults();
        }

        public void ToDefaults()
        {
            _timer = 0;
            _previousCoords = _spawnCoords;
            
            _playerState = new PlayerInfoState
            {
                Speed = 0,
                Color = _defaultColor,
                Direction = Vector3.zero,
                TraveledDistance = 0
            };
        }

        public void ToSpawn()
        {
            transform.position = _spawnCoords;
        }
        
        protected abstract PlayerInfoState UpdateState(PlayerInfoState previousState);
        
        private void Update()
        {
            float dt = Time.deltaTime;
            ref var state = ref _playerState;

            var coords = transform.position;
            
            state.TraveledDistance += Vector3.Distance(coords, _previousCoords);
            _previousCoords = coords;
            
            coords += _playerState.Direction * (_playerState.Speed * dt);
            
            transform.position = coords;
            
            TickUpdate();
        }

        private void TickUpdate()
        {
            float dt = Time.deltaTime;
            _timer += dt;
            
            if (_timer > SecondsPerTick)
            {
                _playerState = UpdateState(_playerState);
                _timer = 0;
            }

            ApplyState(_playerState);
        }
        
        protected void ApplyState(PlayerInfoState state)
        {
            _graphics.SetColor(state.Color);
        }
    }
}
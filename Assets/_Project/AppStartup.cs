using UnityEngine;
using Vocagames.Player;
using Vocagames.Player.Types;

namespace Vocagames
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private DecisionPlayer _playerPrefab;
        [SerializeField] private SequencePlaybackPlayer _clonePrefab;

        [Space] [SerializeField] private KeyCode _key = KeyCode.R;

        private DecisionPlayer _mainPlayer;
        private DecisionRecorder _recorder;

        public void Start()
        {
            _mainPlayer = Instantiate(_playerPrefab);
            _mainPlayer.Constructor(Color.blue);

            _mainPlayer.Constructor(new Skill[] { new RandomColorSkill(), new ToColorSkill(Color.green) });

            _recorder = new DecisionRecorder(_mainPlayer);
        }

        private void Update()
        {
            if (Input.GetKeyDown(_key))
            {
                _mainPlayer.ToSpawn();
                _mainPlayer.ToDefaults();
                _mainPlayer.SkillsCooldown();

                var states = _recorder.GetRecordedStates();
                var clone = Instantiate(_clonePrefab);

                clone.Constructor(states);
            }
        }

        private void OnDestroy()
        {
            _recorder.Dispose();
        }
    }
}
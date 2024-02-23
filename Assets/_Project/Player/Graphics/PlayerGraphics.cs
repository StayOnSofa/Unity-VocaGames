using UnityEngine;

namespace Vocagames.Player.Graphics
{
    public class PlayerGraphics : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private TrailRenderer _trailRenderer;
        
        [Space][SerializeField] private Material _material;
        
        private Material _instance;
        
        private void Awake()
        {
            _instance = Instantiate(_material);
            
            _meshRenderer.material = _instance;
            _trailRenderer.material = _instance;
        }

        public void SetColor(Color color)
        {
            _instance.color = color;
        }

        private void OnDestroy()
        {
            Destroy(_instance);
        }
    }
}
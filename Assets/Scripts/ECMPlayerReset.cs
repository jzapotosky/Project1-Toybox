using UnityEngine;

namespace MichaelWolf
{
    public class ECMPlayerReset : MonoBehaviour
    {
        [SerializeField] private ECM2.Characters.Character _character = null;
        [SerializeField] private Transform _spawnPoint = null;
        
        private static ECMPlayerReset _instance;
        public static ECMPlayerReset Instance
        {
            get
            {
                if(_instance == null) { _instance = FindObjectOfType<ECMPlayerReset>(); }
                return _instance;
            }
        }
        
        
        private void Start()
        {
            if (_spawnPoint == null)
            {
                _spawnPoint = new GameObject("[SPAWN]").transform;
                _spawnPoint.position = _character.transform.position;
                _spawnPoint.rotation = _character.transform.rotation;
            }
        }
        
        public void ResetLastPosition()
        {
            _character.SetVelocity(Vector3.zero);

            _character.transform.position = _spawnPoint.position;
            _character.transform.rotation = _spawnPoint.rotation;
        }
    }
}
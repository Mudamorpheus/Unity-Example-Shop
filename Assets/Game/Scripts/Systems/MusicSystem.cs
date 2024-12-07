using System.Linq;

using UnityEngine;

namespace Example.Scripts.Systems
{
    public class MusicSystem : MonoBehaviour
    {
        //----------<Fields>----------

        public static MusicSystem Instance;
        //
        [SerializeField] public AudioSource _audioSource;
        [SerializeField] public AudioClip[] _audioClips;

        //----------<Unity>----------

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        //----------<Audio>----------

        public void PlayMusic(string name)
        {
            var clip = _audioClips.FirstOrDefault(x => x.name == name);
            if (clip)
            {
                _audioSource.clip = clip;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else
            {
                Debug.LogError($"MusicSystem.PlayMusic(): Clip with name [{name}] doesn't exist.");
            }
        }
    }
}

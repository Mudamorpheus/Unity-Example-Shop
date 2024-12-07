using System.Linq;

using UnityEngine;

namespace Example.Scripts.Systems
{
    public class SoundSystem : MonoBehaviour
    {
        //----------<Fields>----------

        public static SoundSystem Instance;
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

        public void PlaySound(string name)
        {
            var clip = _audioClips.FirstOrDefault(x => x.name == name);
            if (clip)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
            else
            {
                Debug.LogError($"SoundSystem.PlaySound(): Clip with name [{name}] doesn't exist.");
            }
        }
    }
}

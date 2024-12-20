using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;
        public static AudioManager Instance { get => instance; }
        [Header("Audio Sources")]
        public AudioSource bgmSource; // For background music
        public AudioSource sfxSource; // For sound effects

        [Header("Audio Clips")]
        public List<AudioClip> bgmClips; // List of background music tracks
        public List<AudioClip> sfxClips; // List of sound effects

        private void Awake()
        {
            // Ensure a single instance of AudioManager
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #region BGM Methods

        // Play a specific BGM track
        public void PlayBGM(string bgmName, float volume = 1.0f, bool loop = true)
        {
            AudioClip clip = bgmClips.Find(bgm => bgm.name == bgmName);
            if (clip != null)
            {
                bgmSource.clip = clip;
                bgmSource.volume = volume;
                bgmSource.loop = loop;
                bgmSource.Play();
            }
            else
            {
                Debug.LogWarning($"BGM {bgmName} not found!");
            }
        }

        // Stop the current BGM
        public void StopBGM()
        {
            bgmSource.Stop();
        }

        // Pause the current BGM
        public void PauseBGM()
        {
            bgmSource.Pause();
        }

        // Resume the current BGM
        public void ResumeBGM()
        {
            bgmSource.UnPause();
        }

        #endregion

        #region SFX Methods

        // Play a specific SFX
        public void PlaySFX(string sfxName, float volume = 1.0f)
        {
            AudioClip clip = sfxClips.Find(sfx => sfx.name == sfxName);
            if (clip != null)
            {
                sfxSource.PlayOneShot(clip, volume);
            }
            else
            {
                Debug.LogWarning($"SFX {sfxName} not found!");
            }
        }

        // Stop all SFX (useful for specific cases)
        public void StopAllSFX()
        {
            sfxSource.Stop();
        }

        #endregion
    }
}

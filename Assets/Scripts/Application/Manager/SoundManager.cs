using UnityEngine;

namespace MakeTen.Application.Manager
{
    // TODO: Interfaceを継承する
    public sealed class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        [SerializeField] private AudioClip positiveSe;
        [SerializeField] private AudioClip negativeSe;
        
        [SerializeField] private AudioClip titleBgm;
        [SerializeField] private AudioClip gameBgm;
        [SerializeField] private AudioClip resultBgm;

        public void PlayPositiveSe()
        {
            audioSource.PlayOneShot(positiveSe);
        }
        
        public void PlayNegativeSe()
        {
            audioSource.PlayOneShot(negativeSe);
        }
        
        public void PlayTitleBgm()
        {
            audioSource.clip = titleBgm;
            audioSource.Play();
        }
        
        public void PlayGameBgm()
        {
            audioSource.clip = gameBgm;
            audioSource.Play();
        }
        
        public void PlayResultBgm()
        {
            audioSource.clip = resultBgm;
            audioSource.Play();
        }
    }
}

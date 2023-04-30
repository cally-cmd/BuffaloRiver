using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

  public AudioClip defaultHealth;

  private AudioSource track1, track2; 
  private bool isPlayingTrack1;

  public static AudioManager Instance;

  private void Awake() {
    if (Instance == null) {
      Instance = this;
    }
  }

  private void Start() {
    isPlayingTrack1 = false;

    track1 = gameObject.AddComponent<AudioSource>();
    track2 = gameObject.AddComponent<AudioSource>();

    SwapTrack(defaultHealth);
  }

  //https://www.youtube.com/watch?v=1VXeyeLthdQ is where this idea originates.
  public void SwapTrack(AudioClip newClip) {
    
    StopAllCoroutines();
    StartCoroutine(FadeTrack(newClip));

    isPlayingTrack1 = !isPlayingTrack1;
  }

  private IEnumerator FadeTrack(AudioClip newClip) {
    float timeToFade = 0.25f;
    float timeElapsed = 0;

    if (isPlayingTrack1) {
      track2.clip = newClip;
      track2.Play();

      while (timeElapsed < timeToFade) {
        track2.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
        track1.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }

      track1.Stop();

    } else {
      track1.clip = newClip;
      track1.Play();

      while (timeElapsed < timeToFade) {
        track1.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
        track2.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }

      track2.Stop();
    }
  }
}

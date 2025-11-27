using UnityEngine;

public class Shield1Detector : MonoBehaviour {
  public AudioClip sonido;
    
  private void OnCollisionEnter(Collision collision) {
    foreach (var device in Microphone.devices) {
      Debug.Log("Name: " + device);
    }
    Debug.Log("Default microphone: " + Microphone.devices[0]);
    // Capturar sonido del micrófono
    AudioSource audioSource = GetComponent<AudioSource>();
    if (audioSource == null) {
      audioSource = gameObject.AddComponent<AudioSource>();
    }
    // audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
    audioSource.clip = sonido; 
    audioSource.Play();
  }
}
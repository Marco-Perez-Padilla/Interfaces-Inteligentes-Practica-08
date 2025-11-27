using UnityEngine;

public class Altavoces : MonoBehaviour {
  public AudioSource[] speakers;
  private string micName;
  private bool isRecording = false;
  private AudioClip recordedClip;

  public int recordTime = 5; 
  public int sampleRate = 44100;

  void Start() {
    if (Microphone.devices.Length == 0) {
      Debug.LogError("No se detecta ningún micrófono.");
      return;
    }

    micName = Microphone.devices[0];
    Debug.Log("Micrófono usado: " + micName);

    if (speakers.Length == 0) {
      Debug.LogWarning("No hay AudioSources asignados para reproducir.");
    }
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.R)) {
      if (!isRecording) {
        StartRecording();
      }
      else {
        StopAndPlay();
      }
    }
  }

  void StartRecording() {
    Debug.Log("Grabando (Pulsa [R] para detener grabación y empezar a reproducir)");
    recordedClip = Microphone.Start(micName, false, recordTime, sampleRate);
    isRecording = true;
  }

  void StopAndPlay() {
    if (!isRecording) {
      return;
    }

    Microphone.End(micName);
    Debug.Log("Reproduciendo");

    foreach (var speaker in speakers) {
      if (speaker != null) {
        speaker.PlayOneShot(recordedClip);
      }
    }

    isRecording = false;
  }
}

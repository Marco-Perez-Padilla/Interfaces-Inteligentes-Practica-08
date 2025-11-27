using UnityEngine;
using System.IO;

public class CameraCapture : MonoBehaviour {
  private WebCamTexture webcam_texture;
  private Texture2D frame_texture;

  void Start() {
    // Listar cámaras
    foreach (var device in WebCamTexture.devices) {
      Debug.Log("Camera name: " + device.name);
    }

    if (WebCamTexture.devices.Length == 0) {
      Debug.LogWarning("No se encontraron cámaras.");
      return;
    }

    string camName = WebCamTexture.devices[0].name;
    Debug.Log("Default camera: " + camName);

    // Crear webcam
    webcam_texture = new WebCamTexture(camName);

    // Asignar a Renderer
    Renderer r = GetComponent<Renderer>();
    if (r != null) {
      r.material.mainTexture = webcam_texture;
    }

    webcam_texture.Play();
  }

  void OnDisable() {
    if (webcam_texture != null && webcam_texture.isPlaying) {
      webcam_texture.Stop();
    }
  }

  public void CaptureFrame() {
    if (webcam_texture == null || !webcam_texture.isPlaying) {
      Debug.LogWarning("La cámara no está activa.");
      return;
    }

    // Crear Texture2D con las dimensiones de la webcam
    frame_texture = new Texture2D(webcam_texture.width, webcam_texture.height, TextureFormat.RGB24, false);

    // Copiar los píxeles actuales de la webcam a la Texture2D
    frame_texture.SetPixels(webcam_texture.GetPixels());
    frame_texture.Apply();

    Debug.Log("Fotograma capturado en memoria.");
  }

  public void SaveFrame(string fileName = "captura.png") {
    if (frame_texture == null) {
      Debug.LogWarning("No hay fotograma capturado.");
      return;
    }

    // Convertir a PNG
    byte[] bytes = frame_texture.EncodeToPNG();

    // Ruta de guardado
    string path = Path.Combine(Application.persistentDataPath, fileName);

    File.WriteAllBytes(path, bytes);

    Debug.Log("Imagen guardada en: " + path);
  }
}

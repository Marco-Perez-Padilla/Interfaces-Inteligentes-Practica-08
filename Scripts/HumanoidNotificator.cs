using UnityEngine;

public class HumanoidsNotificator : MonoBehaviour {
  public delegate void Mensaje(string HumanoidType);
  public event Mensaje OnCollisionHumanoid;

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Humanoide1")) {
      OnCollisionHumanoid?.Invoke("Tipo1");
    }
  }
}
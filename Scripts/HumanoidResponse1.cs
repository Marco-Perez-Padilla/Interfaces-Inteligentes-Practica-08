using UnityEngine;
using System.Collections;

public class HumanoidResponse1 : MonoBehaviour {
  public HumanoidsNotificator notificator;
  public Transform type_one_shield;

  public float movement_force = 5f;
  public float stop_distance = 1f;

  private Rigidbody rigid;
  private bool must_move = false;

  private void Start() {
    rigid = GetComponent<Rigidbody>();
    
    if (rigid == null) {
      Debug.LogError($"{gameObject.name}: ¡Falta componente Rigidbody!");
      return;
    }

    if (notificator != null) {
      notificator.OnCollisionHumanoid += ReactToCollision;
    } else {
      Debug.LogWarning($"{gameObject.name}: No se asignó el notificator!");
    }
  }

  void ReactToCollision(string HumanoidType) {
    // Los humanoides tipo 1 reaccionan cuando el cubo toca un humanoide tipo 2
    if (HumanoidType == "Tipo1") {
      if (type_one_shield != null) {
        Debug.Log($"{gameObject.name} (Humanoide Tipo1) se mueve hacia escudo tipo 1");
        must_move = true;
      } else {
        Debug.LogWarning($"{gameObject.name}: No se asignó escudo tipo 1!");
      }
    }
  }

  private void FixedUpdate() {
    if (must_move && type_one_shield != null) {

      Vector3 direction = (type_one_shield.position - transform.position).normalized;
      Vector3 targetPos = transform.position + direction * movement_force * Time.fixedDeltaTime;

      rigid.MovePosition(targetPos);

      if (Vector3.Distance(transform.position, type_one_shield.position) < stop_distance) {
        must_move = false;
        Debug.Log($"{gameObject.name}: Llegué al escudo tipo 1");
      }
    }
  }

  private void OnDestroy() {
    if (notificator != null) {
      notificator.OnCollisionHumanoid -= ReactToCollision;
    }
  }
}
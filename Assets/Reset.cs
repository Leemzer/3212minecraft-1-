using UnityEngine;

public class Reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            // Вимикаємо керуючий скрипт (наприклад, PlayerMovement)
            Reset movementScript = other.GetComponent<Reset>(); // ← заміни на свій скрипт!
            if (movementScript != null)
                movementScript.enabled = false;

            // Телепортуємо об'єкт
            controller.enabled = false;
            other.transform.position = Vector3.zero;
            controller.enabled = true;

            // Після затримки — вмикаємо скрипт назад
            StartCoroutine(EnableMovementLater(movementScript, 0.1f));
        }
        else
        {
            other.transform.position = Vector3.zero;
        }
    }

    private System.Collections.IEnumerator EnableMovementLater(MonoBehaviour script, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (script != null)
            script.enabled = true;
    }
}

using UnityEngine;

public class TankTurretFreeAim : MonoBehaviour
{
    public Transform turretTransform;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Generar un plano horizontal a la altura de la torreta
        Plane horizontalPlane = new Plane(Vector3.up, turretTransform.position);

        float distance;
        if (horizontalPlane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Vector3 direction = point - turretTransform.position;
            direction.y = 0f; // eliminar componente vertical

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                turretTransform.rotation = Quaternion.RotateTowards(
                    turretTransform.rotation,
                    targetRotation,
                    360f * Time.deltaTime // velocidad máxima de giro (360º por segundo)
                );
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] private float smoothTime = 0.25f;

    private Vector3 velocity = Vector3.zero;

    // Límites en X e Y
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 100f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 50f;

    void LateUpdate()
    {
        // Calcula la posición deseada en X e Y
        float targetX = Mathf.Clamp(target.position.x + offset.x, minX, maxX);
        float targetY = Mathf.Clamp(target.position.y + offset.y, minY, maxY);

        Vector3 targetPos = new Vector3(targetX, targetY, offset.z);

        // Movimiento suave
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
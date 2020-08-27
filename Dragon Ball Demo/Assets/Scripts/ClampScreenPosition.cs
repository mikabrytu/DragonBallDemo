using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampScreenPosition : MonoBehaviour
{
    [SerializeField] private Vector4 limits;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, limits.x, limits.y);
        pos.y = Mathf.Clamp(pos.y, limits.z, limits.w);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}

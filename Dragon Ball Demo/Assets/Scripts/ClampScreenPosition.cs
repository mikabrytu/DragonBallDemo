using System;
using UnityEngine;
using Bolt;

public class ClampScreenPosition : MonoBehaviour
{
    [SerializeField] private Vector4 limits;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, limits.x, limits.y);
        pos.y = Mathf.Clamp(pos.y, limits.z, limits.w);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        //Debug.Log($"Screen position: {pos.y}");

        Variables.Object(gameObject).Set("Can Rotate X", Math.Round(pos.x, 1) > limits.x && Math.Round(pos.x, 1) < (limits.y - 0.1f));
        Variables.Object(gameObject).Set("Can Rotate Y", Math.Round(pos.y, 1) > limits.z && Math.Round(pos.y, 1) < (limits.w - 0.1f));
    }
}

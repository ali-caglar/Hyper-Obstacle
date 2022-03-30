using System.Collections.Generic;
using TransformLerp.Base;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private List<TransformLerpBase> _transformLerp;

    private void Start()
    {
        foreach (var transformLerp in _transformLerp)
        {
            transformLerp.StartLerp();
        }
    }
}
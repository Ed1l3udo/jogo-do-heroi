using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    public float parallaxSpeed = 0.1f; // Fator de controle de velocidade
    Vector2 startingPosition;
    float startingZ;
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(1 / zDistanceFromTarget) * clippingPlane * parallaxSpeed; // Multiplicando pelo parallaxSpeed
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);       
    }
}

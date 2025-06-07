using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(Transform))]
public class SandstormController : MonoBehaviour
{
    public List<Transform> sandParticles;

    [Header("Movement")]
    public Vector2 movementRange = new Vector2(0.5f, 0.3f);
    public Vector2 speedRange = new Vector2(1f, 3f);
    public Vector2 delayRange = new Vector2(0f, 1f);

    [Header("Color")]
    public float colorShiftAmount = 0.1f;
    public float alphaMin = 0.3f;
    public float alphaMax = 0.6f;
    public float colorAnimDuration = 2f;

    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
        AttachToCamera();

        if (sandParticles == null || sandParticles.Count == 0)
        {
            sandParticles = new List<Transform>();
            foreach (Transform t in transform)
            {
                sandParticles.Add(t);
            }
        }

        AnimateParticles();
        AnimateColors();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);
    }

    void AttachToCamera()
    {
        transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);
        transform.rotation = Quaternion.identity;
    }

     void AnimateParticles()
    {
        foreach (Transform particle in sandParticles)
        {
            StartCoroutine(AnimateParticleMovement(particle));
        }
    }

    IEnumerator AnimateParticleMovement(Transform particle)
    {
        float delay = Random.Range(delayRange.x, delayRange.y);
        yield return new WaitForSeconds(delay);

        float moveX = Random.Range(-movementRange.x, movementRange.x);
        float moveY = Random.Range(-movementRange.y, movementRange.y);
        float speed = Random.Range(speedRange.x, speedRange.y);

        Vector3 originalPos = particle.localPosition;

        particle.DOLocalMove(originalPos + new Vector3(moveX, moveY, 0), speed)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void AnimateColors()
    {
        foreach (Transform particle in sandParticles)
        {
            StartCoroutine(AnimateParticleColor(particle));
        }
    }

    IEnumerator AnimateParticleColor(Transform particle)
    {
        float delay = Random.Range(delayRange.x, delayRange.y);
        yield return new WaitForSeconds(delay);

        Renderer rend = particle.GetComponent<Renderer>();
        if (rend == null || rend.material == null) yield break;

        Material mat = rend.material;
        Color originalColor = mat.GetColor("_Color");

        float shiftR = Random.Range(-colorShiftAmount, colorShiftAmount);
        float shiftG = Random.Range(-colorShiftAmount, colorShiftAmount);
        float shiftB = Random.Range(-colorShiftAmount, colorShiftAmount);
        float targetAlpha = Random.Range(alphaMin, alphaMax);

        Color targetColor = new Color(
            Mathf.Clamp01(originalColor.r + shiftR),
            Mathf.Clamp01(originalColor.g + shiftG),
            Mathf.Clamp01(originalColor.b + shiftB),
            targetAlpha
        );

        mat.DOColor(targetColor, "_Color", colorAnimDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
using System;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private Transform cam;
    private Vector3 camStartPos;
    private float distance;

    private GameObject[] backgrounds;
    private Material[] mat;
    private float[] backSpeed;

    private float farthestBack;
    public float parallaxSpeed;
    
    private float verticalOffset;
    
    private void Start()
    {
        cam = Camera.main.transform;
        verticalOffset = transform.position.y - cam.position.y;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
            //distance = cam.position.x - camStartPos.x;

            Vector3 camMovement = cam.position - camStartPos;
            transform.position = new Vector3(cam.position.x, cam.position.y + verticalOffset, transform.position.z);

            for (int i = 0; i < backgrounds.Length; i++)
            {
                float speed = backSpeed[i] * parallaxSpeed;
                
                Vector2 offset = new Vector2(camMovement.x, camMovement.y * 0.8f) * speed;
                mat[i].SetTextureOffset("_MainTex", offset);
            }
    }
}

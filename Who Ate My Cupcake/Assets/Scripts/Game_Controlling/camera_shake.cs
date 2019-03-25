using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_shake : MonoBehaviour
{
    GameObject mainCamera;
    Vector3 initialPosition;
    public float shakeDuration;
    public float shakeMagnitude;

    private float elapsedTime;

    public void readyForShake()
    {
        mainCamera = GameObject.Find("Main Camera");
        initialPosition = mainCamera.transform.position;
    }

    public void shake()
    {
        float x = Random.Range(-1f, 1f) * shakeMagnitude;
        float y = Random.Range(-1f, 1f) * shakeMagnitude;
        Vector3 position = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(x, y, mainCamera.transform.position.z);
    }

    public void stopShake()
    {
        mainCamera.transform.position = initialPosition;
    }
}

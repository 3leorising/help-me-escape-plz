using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraShake : MonoBehaviour
{
    public static CameraShake reference;
    public static CameraShake _Reference { get { return reference; } }

    // https://gamedevsolutions.com/camera-shake-effect-in-unity3d/
    // Camera Information
    public Transform cameraTransform;
    private Vector3 orignalCameraPos;

    // Shake Parameters
    public float shakeDuration = 2f;
    public float shakeAmount = 0.7f;

    private bool canShake = false;
    private float _shakeTimer;

    private void Awake()
    {
        if (reference != null && reference != this)
        {
            //  BRUHHHHH THIS LITTLE LINE MESSED ME UP FOR 30 MIN I HATE THIS
            // THIS MF KEPT DELETING THE CAMERA FOR LEVEL 2 AND I COULDNT FOLLOW THE PLAYER WHEN I MOVED BCUZ THE ONE FROM LVL 1 PERSISTED I HATE EVERYHTING WOIEFOREUNJKSDJN
            //Destroy(this.gameObject); 

            Destroy(reference.gameObject);
        }
        else
        {
            reference = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        orignalCameraPos = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera();
        }*/

        // prevent persisting to death screen
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0 || sceneIndex == 3)
        {
            //Debug.Log("Death");
            Destroy(this.gameObject);
        }

        if (canShake)
        {
            StartCameraShakeEffect();
        }
    }

    public void ShakeCamera()
    {
        canShake = true;
        _shakeTimer = shakeDuration;
    }

    public void StartCameraShakeEffect()
    {
        if (_shakeTimer > 0)
        {
            cameraTransform.localPosition = orignalCameraPos + Random.insideUnitSphere * shakeAmount;
            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            _shakeTimer = 0f;
            cameraTransform.position = orignalCameraPos;
            canShake = false;
        }
    }
}

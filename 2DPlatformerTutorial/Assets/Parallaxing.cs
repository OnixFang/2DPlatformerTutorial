using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds;     // Array of all the back/foregrounds to be parallaxed.
    private float[] parallaxScales;     // Proportion of the camera's movement to move the backgrounds by.
    public float smoothing = 1f;        // How smooth the parallax is going to be.

    private Transform cam;              // Reference to the main camera's transform.
    private Vector3 previousCamPos;     // The position of the camera in the previous frame.

    // Is called before Start(). Good for references.
    void Awake()
    {
        // set up the camera reference
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start()
    {
        // The previous frame had the current frame's camera position
        previousCamPos = cam.position;

        // Asigning corresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
        }
    }
}

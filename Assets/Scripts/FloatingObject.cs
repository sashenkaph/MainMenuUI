using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FloatingObject : MonoBehaviour
{
    [Header("Floating parameters")]
    public Vector3 rotationSpeed = new(0, 0, 0);//degrees per second
    //sin parameters
    public float amplitude = 0.03f;
    public float frequency = 0.4f;

    [Header("Hover event color")]
    [SerializeField]
    Color hoverColor = new(0.5310609f, 0.735849f, 0.7062086f, 1);

    //[Header("Particle effect")]
    //public GameObject particleEffect;

    private Vector3 positionOffset = new();
    private Vector3 temporaryPosition = new();

    private XRBaseInteractable interactable;

    private Renderer render;
    private Color baseColor;

    //private Transform objectTransform;

    // Start is called before the first frame update
    void Start()
    {
        positionOffset = transform.position;

        render = GetComponent<Renderer>();
        //baseColor = render.material.GetColor("_Color");
        baseColor = render.material.color;

        interactable = GetComponent<XRBaseInteractable>();
        if (interactable is IXRHoverInteractable hoverInteractable)
        {
            hoverInteractable.hoverEntered.AddListener(OnHoverEntered);
            hoverInteractable.hoverExited.AddListener(OnHoverExited);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spinning around Y-axis
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        //
        temporaryPosition = positionOffset;
        temporaryPosition.y += amplitude * Mathf.Sin(Mathf.PI * frequency * Time.fixedTime);
        transform.position = temporaryPosition;
 
        //position = new Vector3(0, amplitude * Mathf.Sin(Mathf.PI * frequency * Time.time), 0);
    }

    void OnHoverEntered(HoverEnterEventArgs args)
    {
        //render.material.SetColor("_Color", Color.red);
        render.material.color = hoverColor;
    }

    void OnHoverExited(HoverExitEventArgs args)
    {
        render.material.color = baseColor;
    }
}

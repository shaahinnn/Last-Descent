using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;

    [SerializeField] AudioClip engineAudio;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] ParticleSystem mainBooster;
    AudioSource gameAudio;
    Rigidbody rb;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        RotationThrust();
    }

    private void RotationThrust()
    {
        float rotationInput = rotation.ReadValue<float>();
        Debug.Log(rotationInput);
        if (rotationInput < 0)
        {
            RotateLeft();
        }
        else if (rotationInput > 0)
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationStrength);
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
            leftBooster.Stop();
        }
    }
    private void RotateRight()
    {
        ApplyRotation(-rotationStrength);
        if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
            rightBooster.Stop();
        }
    
    }
    private void StopRotating()
    {
        leftBooster.Stop();
        rightBooster.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    private void StartThrusting()
    {
        Debug.Log("Space Pessed");
        mainBooster.Play();
        rb.freezeRotation = true;
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        rb.freezeRotation = false;
        if (!gameAudio.isPlaying)
        {
            gameAudio.PlayOneShot(engineAudio);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }
    private void StopThrusting()
    {
        gameAudio.Stop();
        mainBooster.Stop();
    }
}

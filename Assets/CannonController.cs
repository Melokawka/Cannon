using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab; // Reference to the cannonball prefab
    public Transform cannonBallSpawnPoint; // Point where the cannonball should spawn
    public ParticleSystem cannonBallParticles;
    public float shootingRate = 1f; // Maximum shooting rate in seconds
    public int shootingForce = 50;

    private float shootingTimer; // Timer to control the shooting rate

    private void Start()
    {
        shootingTimer = 0f;
    }

    private void Update()
    {
        shootingTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && shootingTimer >= shootingRate)
        {
            ShootCannonBall();
            shootingTimer = 0f;
        }
    }

    private void ShootCannonBall()
    {
        if (cannonBallPrefab && cannonBallSpawnPoint)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, cannonBallSpawnPoint.position, Quaternion.identity);
            cannonBall.transform.localScale = new Vector3(0.00344f, 0.00344f, 0.00344f);

            Vector3 shootingDirection = Camera.main.transform.forward;

            Rigidbody cannonBallRigidbody = cannonBall.GetComponent<Rigidbody>();
            if (cannonBallRigidbody)
            {
                cannonBallRigidbody.AddForce(shootingDirection * shootingForce, ForceMode.Impulse);
            }

            // Apply the particle system to the cannonball if it exists
            if (cannonBallParticles)
            {
                ParticleSystem cannonBallParticlesInstance = cannonBall.GetComponent<ParticleSystem>();
                if (cannonBallParticlesInstance == null)
                {
                    cannonBallParticlesInstance = cannonBall.AddComponent<ParticleSystem>();
                }
                cannonBallParticlesInstance.Play();
            }
            
            Destroy(cannonBall, 5);
        }
    }
}

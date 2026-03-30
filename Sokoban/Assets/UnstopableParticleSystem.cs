using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class UnstopableParticleSystem : MonoBehaviour
{
    private ParticleSystem particleSystem;

    void Start()
    {
       particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Time.timeScale < 0.01f)
        {
            particleSystem.Simulate(Time.unscaledDeltaTime, true, false);
        }
    }
}

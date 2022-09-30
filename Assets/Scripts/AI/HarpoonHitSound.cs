using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonHitSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceComponent = null;
    // Start is called before the first frame update
    private void Start()
    {
        audioSourceComponent = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        EventManager.onStartSkillCheckEvent += PlayHitSound;
    }
    void OnDisable()
    {
        EventManager.onStartSkillCheckEvent -= PlayHitSound;
    }
    public void PlayHitSound(float speed, float treshold, int eventChance, bool plungerStrength)
    {
        audioSourceComponent.Play();
    }
}

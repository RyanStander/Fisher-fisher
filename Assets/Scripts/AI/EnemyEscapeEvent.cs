using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEscapeEvent : MonoBehaviour
{
    [Header("Enemy Attributes for Skill Check")]
    [Range (1,5)]
    public float skillBarSpeed;

    [Range(0, 1f)]
    public float skillZoneThreshold;

    [Range(0, 100)]
    public int chanceForEventPerSecond; //Not suggested to be high

    [SerializeField] AudioSource audioSourceComponent = null;
    private void Start()
    {
        audioSourceComponent = GetComponent<AudioSource>();
    }
    public void PlayHitSound()
    {
        audioSourceComponent.Play();
    }
}

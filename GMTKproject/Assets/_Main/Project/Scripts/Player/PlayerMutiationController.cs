using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMutiationController : MonoBehaviour
{
    [SerializeField] private Vector3 mutationScale;
    [SerializeField] private Ease scalingEase;
    [SerializeField] private float mutuationTime;

    [SerializeField] private ParticleSystem poofParticle;

    [SerializeField] private Transform playerRenderer;

    /// <summary>
    /// Peyniri yedikten sonra mutasyonda kalma süresi olsun süre bitince normale dömsün
    /// </summary>
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MutatePlayer();
        }
    }

    private void MutatePlayer()
    {
        poofParticle.Play();
        playerRenderer.transform.DOScale(mutationScale, mutuationTime).SetEase(scalingEase);
    }
}
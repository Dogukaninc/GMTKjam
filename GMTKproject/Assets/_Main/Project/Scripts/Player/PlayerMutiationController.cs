using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlayerMutiationController : MonoBehaviour
{
    [SerializeField] private Vector3 mutationScale;
    [SerializeField] private Ease scalingEase;
    [SerializeField] private float mutuationTime;
    
    [SerializeField] private ParticleSystem poofParticle;
    [SerializeField] private Transform playerRenderer;

    [Header("Mutant Mouse Variables")]
    [SerializeField] private Sprite bigMouseSprite;
    [SerializeField] private Animator mutantAnimator;
    public bool canMutate;
    
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
        Instantiate(poofParticle.gameObject, transform.position, Quaternion.identity);
        StartCoroutine(WaitUntilParticleFinish());
    }

    IEnumerator WaitUntilParticleFinish()
    {
        yield return new WaitForSeconds(0.7f);
        playerRenderer.GetComponent<SpriteRenderer>().sprite = bigMouseSprite;
    }
}
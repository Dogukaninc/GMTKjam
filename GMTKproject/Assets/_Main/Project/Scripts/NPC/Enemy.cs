using System.Collections;
using UnityEngine;

namespace _Main.Project.Scripts.NPC
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private PatrolArea _patrolArea;

        private Rigidbody2D _rigidbody2D;
        private int currentTargetIndex;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            currentTargetIndex = 0;
            StartCoroutine(PatrolRoutine());
        }

        private void Update()
        {
            if (_rigidbody2D.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        private IEnumerator PatrolRoutine()
        {
            while (true)
            {
                yield return StartCoroutine(PatrolMovement(_patrolArea.patrolWayPoints[currentTargetIndex].position));
                yield return new WaitForSeconds(3f);

                currentTargetIndex = (currentTargetIndex + 1) % _patrolArea.patrolWayPoints.Count;
            }
        }

        private IEnumerator PatrolMovement(Vector3 targetPosition)
        {
            while (Vector3.Distance(transform.position, targetPosition) > 0.5f)
            {
                var direction = (targetPosition - transform.position).normalized;
                _rigidbody2D.velocity = direction * movementSpeed * Time.deltaTime;
                yield return null; // Bir sonraki frame'i bekleyin
            }

            _rigidbody2D.velocity = Vector2.zero;
        }
        
    }
}
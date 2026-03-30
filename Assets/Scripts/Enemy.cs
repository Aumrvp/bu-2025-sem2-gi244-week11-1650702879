<<<<<<< Updated upstream
=======
using System.Collections;
>>>>>>> Stashed changes
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;

<<<<<<< Updated upstream
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

=======
    private bool isStunned = false;
    private Coroutine stunRoutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
            return;
        }

        if (player == null || rb == null) return;

        if (isStunned)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            return;
        }

        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.AddForce(dir * speed);
>>>>>>> Stashed changes
    }

    public void Stun(float duration)
    {
        if (stunRoutine != null)
        {
            StopCoroutine(stunRoutine);
        }

        stunRoutine = StartCoroutine(StunRoutine(duration));
    }

    IEnumerator StunRoutine(float duration)
    {
        isStunned = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(duration);

        isStunned = false;
        stunRoutine = null;
    }
}
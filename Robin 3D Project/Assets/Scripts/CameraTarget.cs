using System;
using System.Collections;
using UnityEngine;

public class CameraTarget : Singleton<CameraTarget>
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 10f;
    private Transform previousTarget;
    private bool showTarget = false;
    private Player player;
    private float speed = 50f;
    public static Action<bool> OnEnabledInput;

    public override void Awake()
    {
        base.Awake();

        transform.SetParent(null);
    }

    private void Start()
    {
        player = Player.Instance;
        target = player.transform;
    }

    private void FixedUpdate()
    {
        if(showTarget) transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        else transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 50);

    }

    private void Update()
    {
        if(showTarget) distance = Vector3.Distance(transform.position, target.position);
    }

    public void ChangeTarget(Transform newTarget, float lookTime)
    {
        previousTarget = player.transform;
        target = newTarget;
        StartCoroutine(ShowTarget(lookTime));
        OnEnabledInput?.Invoke(false);
    }

    public void ChangeTarget(Transform newTarget, float lookTime, float _speed)
    {
        previousTarget = player.transform;
        target = newTarget;
        StartCoroutine(ShowTarget(lookTime));
        OnEnabledInput?.Invoke(false);
        speed = _speed;
    }

    private IEnumerator ShowTarget(float lookTime)
    {
        showTarget = true;
        OnEnabledInput?.Invoke(false);

        yield return new WaitUntil(() => distance < 0.5f);

        yield return new WaitForSeconds(lookTime);

        StartCoroutine(ShowPlayer());
    }

    private IEnumerator ShowPlayer()
    {
        target = previousTarget;

        yield return new WaitUntil(() => Vector3.Distance(transform.position, target.position) < 1.5f);

        OnEnabledInput?.Invoke(true);
        showTarget = false;
    }
}

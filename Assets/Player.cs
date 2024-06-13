using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;

public class PlayerScript : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] Vector2 movimiento;
    [Header("Rotacion y velocidad")]
    [SerializeField] float velocidadMovimiento = 3.0f;
    [SerializeField] float velocidadRotacion;
    private Rigidbody rb;

    [Header("DoTween")]
    [SerializeField] private float duration;
    [SerializeField] private Ease EaseValue = Ease.Linear;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(movimiento.x, 0, movimiento.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocidadRotacion, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.MovePosition(transform.position + moveDirection * velocidadMovimiento * Time.deltaTime);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movimiento = context.ReadValue<Vector2>();
    }
}


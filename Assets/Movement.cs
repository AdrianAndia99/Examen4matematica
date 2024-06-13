using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{
    private float velocidadCaminando = 2f;
    private float velocidadCorriendo = 5f;
    private float inputX = 0;
    private bool estaCorriendo = false;
    private Vector2 fuerzaMovimiento;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        fuerzaMovimiento = Vector2.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        estaCorriendo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float velocidadActual = estaCorriendo ? velocidadCorriendo : velocidadCaminando;

        fuerzaMovimiento.x = inputX * velocidadActual;

        rb.AddForce(new Vector2(fuerzaMovimiento.x, 0f));
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }
}

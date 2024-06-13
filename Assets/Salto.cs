using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playersalto : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] public int Jumps;
    [SerializeField] public int fuerza;
    [SerializeField] public LayerMask layermask;
    // Start is called before the first frame update
    void Update()
    {


    }
    void FixedUpdate()
    {
        Chequearpiso();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump Read");
        if (context.performed)
        {
            Debug.Log("Jump Called");
            JumP();
        }
    }
    void JumP()
    {
        Debug.Log("Jump Executed");
        if (Jumps > 0)
        {
            myRB.AddForce(Vector2.up * fuerza, ForceMode.Impulse);
            Jumps--;
        }
    }
    void Chequearpiso()
    {
        RaycastHit raycast;
        if (Physics.Raycast(transform.position, Vector3.down, out raycast, rayDistance, layermask))
        {
            if (raycast.collider.CompareTag("Piso"))
            {
                Jumps = 1;
            }
        }
    }
}

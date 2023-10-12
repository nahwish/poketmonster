using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    [SerializeField]
    [Tooltip("Todos los objetos que el personaje no puede atravesar")]
    private LayerMask solidObjectLayer,pokemonLayer;
    [SerializeField]
    float speed;
    private Vector2 input;
    private Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isMoving)
        {
            IsMovingPosition();
            GetTheMovementAndCancelDiagonalMovement();
        }
    }

    //obtener el movimiento y anular movimiento diagonal
    private void GetTheMovementAndCancelDiagonalMovement()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (input.x != 0)
        {
            input.y = 0;
        }
    }
    //desplazamiento y animación
    private void IsMovingPosition()
    {
        if (input != Vector2.zero)
        {
            StartAnimationMove();

            var targetPosition = this.transform.position;
            targetPosition.x += input.x;
            targetPosition.y += input.y;

            if (IsAvailable(targetPosition))
            {
                StartCoroutine(MoveTowards(targetPosition));
            }
        }
    }
    private void StartAnimationMove()
    {
        _animator.SetFloat("Move X", input.x);
        _animator.SetFloat("Move Y", input.y);

    }
    //actualiza posicion 
    IEnumerator MoveTowards(Vector3 destination)
    {
        isMoving = true;
        yield return StartCoroutine(MoveDestination(destination));
        isMoving = false;
    }
    public IEnumerator MoveDestination(Vector3 destination)
    {
        while (Vector3.Distance(transform.position, destination) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = destination;
        CheckForPokemon();
    }
    private void CheckForPokemon()
    {
        if(Physics2D.OverlapCircle(transform.position, 00.2f,pokemonLayer) != null)
        {
            if(Random.Range(0,100)<10)
            {
                Debug.Log("Empezar batalla pokemon");
            }
        }
    }
    // se ejecuta al final, sirve para sincronizar la animación
    private void LateUpdate()
    {
        _animator.SetBool("Is Moving", isMoving);
    }

    /// <summary>
    /// Comprueba si está disponible la zona a la que queremos acceder
    /// </summary>
    /// <param name="target">zona a la que queremos acceder</param>
    /// <returns> devuelve true si la zona esta disponible</returns> 
    private bool IsAvailable(Vector3 target)
    {
        if (Physics2D.OverlapCircle(target, 0.5f, solidObjectLayer) != null)
        {
            return false;
        }
        return true;
    }
}

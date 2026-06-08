using Sirenix.OdinInspector;
using System;
<<<<<<< Updated upstream:Assets/Scripts/ThirdPersonController.cs
=======
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
>>>>>>> Stashed changes:Assets/Scripts/Class07/ThirdPersonController.cs

public class ThirdPersonController : MonoBehaviour
{
    [FoldoutGroup("References")]
    public InputSystem_Actions inputs;
    [FoldoutGroup("References")]
    private CharacterController controller;
    [FoldoutGroup("References")]
    public CinemachineCamera characterCamera;
    [FoldoutGroup("References")]
    public CinemachineCamera characterAimCamera;
    [FoldoutGroup("References")]
<<<<<<< Updated upstream:Assets/Scripts/ThirdPersonController.cs
    public Transform Skull;
=======
    public Transform Spine;
    [FoldoutGroup("References")]
    public LayerMask enemyMask;

    [FoldoutGroup("References")]
    public LayerMask WallMask;

    [FoldoutGroup("References")]
    public GameObject GranadePrefab;

    [FoldoutGroup("References")]
    public AgentEnemyController EnemyReference;

    [FoldoutGroup("References")]
    public ParticleSystem DashParticles;

    [FoldoutGroup("References")]
    public ParticleSystem ShootParticles;

    [FoldoutGroup("References")]
    public ParticleSystem BloodParticles;

    [FoldoutGroup("References")]
    public ParticleSystem ConstruccionParticles;
>>>>>>> Stashed changes:Assets/Scripts/Class07/ThirdPersonController.cs
    //  public Animator animator;


    [FoldoutGroup("Controller")]
    public float moveSpeed = 5f;
    [FoldoutGroup("Controller")]
    public float runSpeed = 5;
    [FoldoutGroup("Controller")]
    public float rotationSpeed = 200f;
    [FoldoutGroup("Controller")]
    public float verticalVelocity = 0;
    [FoldoutGroup("Controller")]
    public float jumpForce = 10;
    [FoldoutGroup("Controller")]
    public float pushForce = 4;

    [FoldoutGroup("Controller/Dash")]
    private bool IsDashing;
    [FoldoutGroup("Controller/Dash")]
    public float dashForce;
    [FoldoutGroup("Controller/Dash")]
    public float dashDuration = 0.2f;
    [FoldoutGroup("Controller/Dash")]
    private float dashTimer;

    public bool CanDash = true;
    private float CurrentCDDash;
    private float cooldownDash = 5f;

    [FoldoutGroup("Controller/Animator"), SerializeField]
    private CinemachineImpulseSource source;

    [SerializeField] private Vector2 moveInput;



    [FoldoutGroup("WallRun")]
    public float rayLenght;
    [FoldoutGroup("WallRun")]
    public float cameraTitlt = 15;
    [FoldoutGroup("WallRun")]
    public float maxTimeInAir;
    [FoldoutGroup("WallRun")]
    public bool enableWallRun;


    [FoldoutGroup("WallRun")]
    private float airTimer;

    [FoldoutGroup("WallRun")]
    public float airTimeToWallRun = 0.2f;

    [FoldoutGroup("WallRun")]
    public bool CanWallRun = true;

    [FoldoutGroup("WallRun")]
    public float MaxStaminaForWallRun = 10f;

    [FoldoutGroup("WallRun")]
    public float CurrentStaminaForWallRun;


    [FoldoutGroup("Attack")]
    public bool aimMode = false;





    [FoldoutGroup("Attack")]
    public Transform WeaponShootAnchor;

    [FoldoutGroup("Attack")]
    public LineRenderer RayPrefab;




    Vector3 normalDebug;
    Vector3 impactPoint;
    Vector3 crossResult;

    public UnityEvent OnShoot;

    private void Awake()
    {
        inputs = new();
        controller = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        characterCamera.Priority = 10;
        characterAimCamera.Priority = 0;
    }
    private void OnEnable()
    {
        inputs.Enable();

        inputs.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        inputs.Player.Dash.performed += OnDash;

        inputs.Player.Attack.performed += Attack;

        inputs.Player.Jump.performed += OnJump;
        inputs.Player.Aim.started += ctx =>
            {
                characterCamera.Priority = 0;
                characterAimCamera.Priority = 10;
                aimMode = true;
            };
        inputs.Player.Aim.canceled += ctx =>
        {
            characterCamera.Priority = 10;
            characterAimCamera.Priority = 0;
            aimMode = false;
        };

<<<<<<< Updated upstream:Assets/Scripts/ThirdPersonController.cs
        inputs.Player.Sprint.performed += ctx => moveSpeed += runSpeed ;
        inputs.Player.Sprint.canceled += ctx => moveSpeed -= runSpeed;
=======
        inputs.Player.Sprint.performed += ctx =>
        {if(CurrentStamina >0)
            moveSpeed += runSpeed;
            IsRunning = true;


        };
        inputs.Player.Sprint.canceled += ctx => 
        {
            moveSpeed = OriginalmoveSpeed;
            IsRunning = false;



        };
        inputs.Player.ThrowGranade.performed += ThrowSmt;

    }

    private void ThrowSmt(InputAction.CallbackContext context)
    {

        GameObject granade = Instantiate(GranadePrefab, transform.position + gameObject.transform.forward * 1.5f, Quaternion.identity);

        Vector3 dir = gameObject.transform.forward;
        granade.GetComponent<Rigidbody>().AddForce(dir * Force, ForceMode.Impulse);



    }
    
    public void RechargeTurret()
    {
        if (CurrentAmountTurret < MaxAmountTurret)
        {
            timerCDTurret += Time.deltaTime;
            if (timerCDTurret > CDTurret)
            {
               timerCDTurret = 0;
                CurrentAmountTurret++;

            }
        }
>>>>>>> Stashed changes:Assets/Scripts/Class07/ThirdPersonController.cs


    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("ATTack");

        Physics.Raycast(WeaponShootAnchor.position, characterAimCamera.transform.forward, out RaycastHit hit, 100);

<<<<<<< Updated upstream:Assets/Scripts/ThirdPersonController.cs
=======
        OnShoot?.Invoke();
        //if (Physics.SphereCast(WeaponShootAnchor.position, 5f,characterAimCamera.transform.forward, out RaycastHit hit, 100f, enemyMask))
        if (Physics.Raycast(WeaponShootAnchor.position, characterAimCamera.transform.forward, out RaycastHit hitWall, 100f, WallMask))
        {
            if( aimMode)
            {
                if(CurrentAmountTurret > 0)
                {

                    Debug.Log("Hit smt");
                    GameObject TurretObj = Instantiate(TurreetPrefab, hitWall.point, Quaternion.identity);

                    TurretObj.transform.up = hitWall.normal;

                    Turret turret = TurretObj.GetComponent<Turret>();

                    turret.Enemy = EnemyReference;
                    CurrentAmountTurret--;

                    GameObject construcParticles = Instantiate(ConstruccionParticles.gameObject, hitWall.point, Quaternion.LookRotation(transform.forward));

                    Destroy(construcParticles, 2f);

                }
            }
        }

        else if((Physics.Raycast(WeaponShootAnchor.position, characterAimCamera.transform.forward, out RaycastHit hitEnemy, 100f, enemyMask)))
        {

            Debug.Log("Hit smt");
            LineRenderer ray = Instantiate(RayPrefab, transform.position, Quaternion.identity);

            ray.gameObject.transform.position = WeaponShootAnchor.position;

            ray.positionCount = 2;

            ray.SetPosition(0, WeaponShootAnchor.position);

            ray.SetPosition(1, hitEnemy.point);


           AgentEnemyController enemy = hitEnemy.collider.GetComponent<AgentEnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
                GameObject bloodParticles = Instantiate(BloodParticles.gameObject, hitEnemy.point, Quaternion.LookRotation(transform.forward));

                Destroy(bloodParticles, 2f);
            }


        }
        else
        {
            Debug.Log("Miss");
        }
        /*
        Physics.Raycast(WeaponShootAnchor.position, characterAimCamera.transform.forward, out RaycastHit hit, 100f, enemyMask);
        
>>>>>>> Stashed changes:Assets/Scripts/Class07/ThirdPersonController.cs
        if(hit .collider != null)
        {

            LineRenderer ray = Instantiate(RayPrefab, transform.position, Quaternion.identity);

            ray.gameObject.transform.position = WeaponShootAnchor.position;

            ray.positionCount = 2;

            ray.SetPosition(0, WeaponShootAnchor.position);

            ray.SetPosition(1, hit.point);
           
        }



        

    }

    void Start()
    {

        CurrentStaminaForWallRun = MaxStaminaForWallRun;
<<<<<<< Updated upstream:Assets/Scripts/ThirdPersonController.cs
=======
        CurrentAmountTurret = MaxAmountTurret;

        CurrentStamina = MaxStamina;
        CurrentCDDash = cooldownDash;
>>>>>>> Stashed changes:Assets/Scripts/Class07/ThirdPersonController.cs
    }
    void Update()
    {
        if (!controller.isGrounded)
        {
            airTimer += Time.deltaTime;

        }
        else
        {
            airTimer = 0;
        }
<<<<<<< Updated upstream:Assets/Scripts/ThirdPersonController.cs
=======
        RechargeTurret();

        if ( IsRunning)
        {
            CurrentStamina -= Time.deltaTime * 2;
            if (CurrentStamina <0)
            {
                CurrentStamina = 0;
            }
        }
        else
        {
            CurrentStamina += Time.deltaTime ;

            if (CurrentStamina > MaxStamina)
            {
                CurrentStamina = MaxStamina;
            }
        }

>>>>>>> Stashed changes:Assets/Scripts/Class07/ThirdPersonController.cs
        OnMove();
        //OnSimpleMove();
        EnableWallRun();

        if (enableWallRun && !controller.isGrounded)
        {
            CurrentStaminaForWallRun -= Time.deltaTime;
            if (CurrentStaminaForWallRun < 0)
            {
                CurrentStaminaForWallRun = 0;
                CanWallRun = false;
                enableWallRun = false;

            }
        }
    }

    public void OnMove()
    {


        Vector3 cameraForwardDir = characterCamera.transform.forward;
        cameraForwardDir.y = 0;
        cameraForwardDir.Normalize();


        if(!aimMode)
        {
            if (moveInput != Vector2.zero)
            {
                Quaternion targetQuaternion = Quaternion.LookRotation(cameraForwardDir);
                //transform.rotation = targetQuaternion;
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetQuaternion,
                    rotationSpeed * Time.deltaTime);


            }
        }
        else
        {

            Vector3 cameraForwardAimDir = characterCamera.transform.forward;
            //cameraForwardAimDir.y = 0;
            cameraForwardAimDir.Normalize();

            Quaternion targetQuaternion = Quaternion.LookRotation(cameraForwardAimDir);

             transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetQuaternion,
                rotationSpeed * Time.deltaTime);
        }
       
        //>?
        Vector3 moveDir;
        if (!enableWallRun)
        {
            moveDir = (cameraForwardDir * moveInput.y + transform.right * moveInput.x) * moveSpeed;
        }
        else
        {
            moveDir = (crossResult * moveInput.y) * moveSpeed;


            
        }

        float magnitud = Mathf.Abs(controller.velocity.magnitude);
        // print(magnitud);
        //animator.SetFloat("Speed", GetSpeed());


        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (enableWallRun && CanWallRun)
            verticalVelocity = 0;
        if (!CanWallRun || controller.isGrounded)
        {

           
            characterCamera.Lens.Dutch = 0;
        }
        if (controller.isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f;
        moveDir.y = verticalVelocity;

       // animator.SetBool("Grounded", controller.isGrounded);


        if (IsDashing)
        {
            //->convertir el dash a un barrido por el piso! dash con gravedad integrada omaegoto!
            if (moveInput.x > 0)
            {
                moveDir = transform.right * dashForce * (dashTimer / dashDuration);

                dashTimer -= Time.deltaTime;

                if (dashTimer <= 0)
                    IsDashing = false;
            }
            else if (moveInput.x < 0)
            {

                moveDir = -transform.right * dashForce * (dashTimer / dashDuration);

                dashTimer -= Time.deltaTime;

                if (dashTimer <= 0)
                    IsDashing = false;
            }
            else if(moveInput.y > 0)
            {

                moveDir = transform.forward * dashForce * (dashTimer / dashDuration);

                dashTimer -= Time.deltaTime;

                if (dashTimer <= 0)
                    IsDashing = false;
            }
            else if(moveInput.y < 0)
            {

                moveDir = -transform.forward * dashForce * (dashTimer / dashDuration);

                dashTimer -= Time.deltaTime;

                if (dashTimer <= 0)
                    IsDashing = false;
            }
        }
        controller.Move(moveDir * Time.deltaTime);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!controller.isGrounded) return;
        //StartCoroutine(JumpDelay());

        source.GenerateImpulse();
        verticalVelocity = jumpForce;
    }
    private IEnumerator JumpDelay()
    {

        yield return new WaitForSeconds(0.35f);



        //animator.SetTrigger("Jump");
        source.GenerateImpulse();
        verticalVelocity = jumpForce;
    }
    public void OnSimpleMove()
    {
        transform.Rotate(Vector3.up * moveInput.x * rotationSpeed * Time.deltaTime);
        Vector3 moveDir = transform.forward * moveSpeed * moveInput.y;
        controller.SimpleMove(moveDir);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Vector3 pushDir = (hit.transform.position - transform.position).normalized;

        if (hit.rigidbody != null && hit.rigidbody.linearVelocity == Vector3.zero)
        {
            print(hit.gameObject.name);
            hit.rigidbody.AddForce(pushDir * pushForce, ForceMode.Impulse);
        }
    }
    private void OnDash(InputAction.CallbackContext context)
    {
        if (CanDash)
        {

            IsDashing = true;
            CanDash = false;
            dashTimer = dashDuration;

            StartCoroutine(CooldownDash());
        }
    }

    public IEnumerator CooldownDash()
    {
        CurrentCDDash = 0;

        while (CurrentCDDash < cooldownDash)
        {
            CurrentCDDash += Time.deltaTime;
            yield return null;

        }

        CanDash = true;
        yield break;

    }
    public void EnableWallRun()
    {
        //->mejor castearlo desde una referenia en los piez
        RaycastHit hit = default;

        Physics.Raycast(transform.position, transform.right, out RaycastHit hitRight, rayLenght);

        Physics.Raycast(transform.position, -transform.right, out RaycastHit hitLeft, rayLenght);

        if (hitRight.collider != null && hitRight.collider.gameObject.tag == "Wall")
        {
            hit = hitRight;
            if (enableWallRun)
            {
                characterCamera.Lens.Dutch = cameraTitlt;

                //model.transform.rotation = Quaternion.Euler(-90f, 0, -90);
               

            }
            else

                characterCamera.Lens.Dutch = 0;

        }
        else if (hitLeft.collider != null && hitLeft.collider.gameObject.tag == "Wall")
        {
            hit = hitLeft;

            if (enableWallRun)
            {
                characterCamera.Lens.Dutch = -cameraTitlt;
                //model.transform.rotation = Quaternion.Euler(90f, 0, 90);
               
            }
            else
                characterCamera.Lens.Dutch = 0;

        }
        else
        {
            characterCamera.Lens.Dutch = 0;
            enableWallRun = false;
        }

        if ((hit.collider != null && airTimer >= airTimeToWallRun && CanWallRun))
        {
            enableWallRun = true;
            Debug.Log("AleluyaR");


            normalDebug = hit.normal;
            impactPoint = hit.point;
            crossResult = Vector3.Cross(normalDebug, transform.up);//+1

            if (Vector3.Dot(crossResult, transform.forward) < 0)
            {
                crossResult *= -1;
            }
        }
    }
    public float GetSpeed()
    {
        return Mathf.Abs(controller.velocity.magnitude);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawRay(transform.position, transform.right * rayLenght);
        Gizmos.color = Color.navyBlue;
        Gizmos.DrawRay(transform.position, -transform.right * rayLenght);

        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(impactPoint, normalDebug * rayLenght);
        Gizmos.DrawSphere(impactPoint, 0.1f);

        Gizmos.color = Color.orange;
        Gizmos.DrawRay(impactPoint, crossResult * rayLenght);


    }
}

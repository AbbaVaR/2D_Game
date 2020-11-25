using UnityEngine;
using UnityEngine.UI;

public class AboutPlayer : MonoBehaviour {
    public float MaxHP { get; set; } = 100f;
    public float CurHP { get; set; }
    public float MaxStam { get; set; } = 100f;
    public float CurStam { get; set; }
    public float PlayerD { get; set; } = 30f;
    public float Speed { get; } = 5f;
    public float JumpForce { get; } = 7000f;
    public bool IsFacingRight { get; set; } = true;
    public bool IsGrounded { get; set; } = false;
    public float GroundRadius { get; } = 0.1f;
    public float AttackRadius { get;} = 0.35f;
    public bool Blocking { get; set; } = false;

    public Animator anim;
    public Rigidbody2D rb;    
    public Transform attackCheck;    
    public LayerMask whatIsGround;    
    public Transform groundCheck;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

}

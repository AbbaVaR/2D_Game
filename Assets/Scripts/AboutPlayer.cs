using UnityEngine;
using UnityEngine.UI;

public class AboutPlayer : MonoBehaviour {
    public float MaxHP { get; set; }
    public float CurHP { get; set; }
    public float MaxSP { get; set; } = 100f;
    private float curSP;
    public float CurSP 
        {
            get
            {
                return curSP;
            }
            set
            {
                if (curSP > MaxSP) curSP = MaxSP;
                else if (curSP < 0) curSP = 0;
                else curSP = value;
            }
        }
    public float BlockStr { get; set; }
    public float PlayerD { get; set; }
    public float Speed { get; } = 5f;
    public float JumpForce { get; } = 7000f;
    public bool IsFacingRight { get; set; } = true;
    public bool IsGrounded { get; set; } = false;
    public float GroundRadius { get; } = 0.1f;
    public float AttackRadius { get;} = 0.35f;
    public bool Blocking { get; set; } = false;
    public int Lvl { get; set; } = 1;
    public int Money { get; set; }  //Деньги игрока
    public int MoneyLVL { get; set; } //Денег для повышения уровня
    public float HpLvl { get; set; } = 1; // Прокачка здоровья
    public float SpLvl { get; set; } = 1; // Прокачка выносливости
    public float StrLvl { get; set; } = 1;// Прокачка урона
    public float BlockLvl { get; set; } = 1;// Прокачка блокирования
    public Animator anim;
    public Rigidbody2D rb;    
    public Transform attackCheck;    
    public LayerMask whatIsGround;    
    public Transform groundCheck;

}

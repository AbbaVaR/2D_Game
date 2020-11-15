using UnityEngine;
using UnityEngine.UI;

public class AboutPlayer : MonoBehaviour {
    public float MaxHP { get; set; } = 100f;
    public float CurHP { get; set; }
    public float MaxStam { get; set; } = 100f;
    public float CurStam { get; set; }
    public float PlayerD { get; set; } = 30f;

    public Animator anim;
    //public Image hpBar;
    //public float FillHpBar { get; set; } = 1f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

}

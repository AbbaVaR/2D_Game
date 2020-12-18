using UnityEngine;
using UnityEngine.UI;

public class SpBar : MonoBehaviour
{
    public Player player;
    public Text spBar;


    private void OnEnable()
    {
        player.SPchange += UpdateValue;
    }

    private void OnDisable()
    {
        player.SPchange -= UpdateValue;
    }

    public void UpdateValue(float value)
    {
        if (player == null) return;
        if (value < 0)
            spBar.text = "SP: 0%";
        else if (value > 100)
            spBar.text = "SP: 100%";
        else
            spBar.text = "SP: " + ((int)value).ToString() + "%";
    }
}


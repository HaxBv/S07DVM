using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image Mirilla;
    public Image Stamina;
    public Image Dash;
    public TextMeshProUGUI AmountTurret;
    public ThirdPersonController Controller;

    void Start()
    {

    }

    void Update()
    {
        Mirilla.gameObject.SetActive(Controller.aimMode);

        AmountTurret.text = $"{Controller.CurrentAmountTurret }";

        float Porcentaje1 = Controller.CurrentStamina / Controller.MaxStamina;

        Stamina.fillAmount = Porcentaje1;

        float Porcentaje2 = Controller.CurrentCDDash / Controller.cooldownDash;
        Dash.fillAmount = Porcentaje2;


    }
}

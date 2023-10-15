using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

enum Validity
{
    None, Valid, Potential, Invalid
}

public class KeyboardKey : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private Image renderer;
    [SerializeField] private TextMeshProUGUI letterText;


    [Header(" Settings ")]
    private Validity validity;

    [Header(" Events ")]
    public static Action<char> onKeyPressed;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SendKeyPressedEvent);
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SendKeyPressedEvent()
    {
        // Debug.Log("FATIH=>" + letterText.text[0]);
        onKeyPressed?.Invoke(letterText.text[0]);
    }

    public char GetLetter()
    {
        return letterText.text[0];
    }

    public void Initialize()
    {
        renderer.color = Color.white;
        validity = Validity.None;
    }

    public void SetValid()
    {
        if (validity == Validity.Valid)
            return;


        renderer.color = Color.green;
        validity = Validity.Valid;

    }

    public void SetPotential()
    {
        renderer.color = Color.yellow;
        validity = Validity.Potential;

    }

    public void SetInvalid()
    {
        if (validity == Validity.Valid || validity == Validity.Potential)
            return;

        renderer.color = Color.gray;
        validity = Validity.Invalid;
    }

    public bool IsUntouched()
    {
        return validity == Validity.None;
    }
}

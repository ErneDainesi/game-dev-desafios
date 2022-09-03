using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCounter;
    [SerializeField] private int initialAmmmo;
    private static int ammoCount;
    public static HudManager instance;
    public static int AmmoCount { get => ammoCount; set => ammoCount = value; }
    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            ammoCount = initialAmmmo;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        ammoCounter.text = ammoCount.ToString();
    }
}

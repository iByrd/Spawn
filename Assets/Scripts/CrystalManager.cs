using TMPro;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    public int crystalCount;
    public TMP_Text crystalText;
    public GameObject doorOne;
    public bool doorOneOpened;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crystalText.text = "Crystals: " + crystalCount.ToString();

        if (crystalCount == 3 && !doorOneOpened)
        {
            doorOneOpened = true;
            Destroy(doorOne);
        }
    }
}

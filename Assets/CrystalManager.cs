using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour
{
    public int crystalCount;
    public Text crystalText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crystalText.text = "Crystals: " + crystalCount.ToString();
    }
}

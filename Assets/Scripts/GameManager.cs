using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpaceDiamonds[] allDiamonds;
    public int diamondCount = 0;





    void Start()
    {
        allDiamonds = FindObjectsByType<SpaceDiamonds>(FindObjectsSortMode.None);
    }


    void Update()
    {
        diamondCount = 0;

        foreach (SpaceDiamonds x in allDiamonds)
        {
            if (x.isCollected)
            {
                diamondCount += 1;
                x.gameObject.SetActive(false);
            }
        }
    }
}

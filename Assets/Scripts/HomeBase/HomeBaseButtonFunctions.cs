using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBaseButtonFunctions : MonoBehaviour
{   
    private HomeBaseVFX homeBaseVFX;

    private void Start()
    {
        homeBaseVFX = GetComponent<HomeBaseVFX>();
    }
    public void ReturnToWorldMap()
    {
        SceneManager.LoadScene("WorldMap");
    }
}

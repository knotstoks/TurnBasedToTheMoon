using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HomeBaseVFX))]
public class HomeBaseParent : MonoBehaviour
{   
    private HomeBaseVFX homeBaseVFX;

    public virtual void Start()
    {
        homeBaseVFX = GetComponent<HomeBaseVFX>();
    }
    public void GoToWorldMap()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void GoToCharacterMenu()
    {
        SceneManager.LoadScene("CharacterMenu");
    }
}

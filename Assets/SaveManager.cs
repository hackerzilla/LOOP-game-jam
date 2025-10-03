using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SaveManager : MonoBehaviour
{
    [Header("Save Manager Settings")]
    public static SaveManager Instance;
    public int numberOfTries = 5;
    public int score = 0;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
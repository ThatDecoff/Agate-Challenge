using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentController : MonoBehaviour
{
    private static PersistentController Instance = null;

    public KeyCode BackKey = KeyCode.Tilde;

    private void Start()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(BackKey))
        {
            SceneManager.LoadScene("Challenge10", LoadSceneMode.Single);
        }
    }
}

using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    static GameObject permanentGO;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (permanentGO == null) 
        {
            permanentGO = this.gameObject;
        }
        if (permanentGO != this.gameObject)
        {
            Destroy(this.gameObject);
        }
       
    }
}

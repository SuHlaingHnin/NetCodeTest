using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    #region Public Functions
    public bool Opened
    {
        get
        {
            return gameObject.activeInHierarchy;
        }
    }

    public virtual void OnShowAsync(params object[] objects)
    {

    }

    public void Show(params object[] objects)
    {
        if (Opened) return;
        gameObject.SetActive(true);
        OnShowAsync(objects);
    }

    public void Close()
    {
        if (!Opened) return;
        gameObject.SetActive(false);
    }
    #endregion
}

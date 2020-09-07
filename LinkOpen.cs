using UnityEngine;

public class LinkOpen : MonoBehaviour
{
    [SerializeField] string link ="https://oceana.org/";
    public void OpenCommunityLink()
    {
        Application.OpenURL(link);
    }
}

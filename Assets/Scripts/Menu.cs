using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Rooms;
    public GameObject Main;

    private void Awake()
    {
        Main.SetActive(true);
        Rooms.SetActive(false);
    }

    public void EnterRoomList()
    {
        Rooms.SetActive(true);
        Main.SetActive(false);
    }

    public void Return()
    {
        Rooms.SetActive(false);
        Main.SetActive(true);
    }

    public void ExitGame()
    {
        
    }
}

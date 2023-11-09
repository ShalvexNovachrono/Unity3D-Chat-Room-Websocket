using UnityEngine;
using UnityEngine.UI;

public class Sender : MonoBehaviour
{
  public InputField MessageInput;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Return) && !(MessageInput.text != ""))
      return;
    Gameobject.FindAnyObjectByType<WebSocketWorker>().SendMessageParameter("", MessageInput.text);
    MessageInput.text = "";
    MessageInput.Select();
  }

}

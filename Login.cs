using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
  public Transform NextPage;
  public Transform WebSocketWorker;
  public InputField usernameInput;
  public Button LoginButton;

  private void Start()
  {
    LoginButton.onClick.AddListener(Login_Function));
  }

  private void Login_Function()
  {
    WebSocketWorker.gameObject.SetActive(true);
    Object.FindObjectOfType<WebSocketWorker>().Username = usernameInput.text;
    NextPage.gameObject.SetActive(true);
    transform.gameObject.SetActive(false);
  }

}

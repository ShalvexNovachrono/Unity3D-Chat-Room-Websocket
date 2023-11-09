using UnityEngine;
using UnityEngine.UI;

public class MessageWriter : MonoBehaviour
{
  public Text UsernameText;
  public Text MessageDisplay;
  public string username;
  public string message;
  public bool CustomColour;
  public float[] r;
  public float[] g;
  public float[] b;
  public float[] a;

  private void Start()
  {
    UsernameText = this.transform.GetChild(0).GetComponent<Text>();
    MessageDisplay = this.transform.GetChild(1).GetComponent<Text>();
  }

  private void Update()
  {
    UsernameText.text = this.username;
    MessageDisplay.text = this.message;
    if (CustomColour)
    {
      UsernameText.color = new Color(this.r[0], this.g[0], this.b[0], this.a[0]);
      MessageDisplay.color = new Color(this.r[0], this.g[0], this.b[0], this.a[0]);
    }
    Destroy(transform.GetComponent<MessageWriter>());
  }

  public MessageWriter()
  {
    r = new float[1]{ 213f };
    g = new float[1]{ 231f };
    b = new float[1]{ 52f };
    a = new float[1]{ 1f };
  }
}
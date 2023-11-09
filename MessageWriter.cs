// Decompiled with JetBrains decompiler
// Type: MessageWriter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B34C14AB-0760-406D-ABE6-62CD929EE8CE
// Assembly location: D:\Download\folder\Chat Room_Data\Managed\Assembly-CSharp.dll
// Compiler-generated code is shown

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
    this.UsernameText = this.transform.GetChild(0).GetComponent<Text>();
    this.MessageDisplay = this.transform.GetChild(1).GetComponent<Text>();
  }

  private void Update()
  {
    this.UsernameText.text = this.username;
    this.MessageDisplay.text = this.message;
    if (this.CustomColour)
    {
      this.UsernameText.color = new Color(this.r[0], this.g[0], this.b[0], this.a[0]);
      this.MessageDisplay.color = new Color(this.r[0], this.g[0], this.b[0], this.a[0]);
    }
    Object.Destroy((Object) this.transform.GetComponent<MessageWriter>());
  }

  public MessageWriter()
  {
    this.r = new float[1]{ 213f };
    this.g = new float[1]{ 231f };
    this.b = new float[1]{ 52f };
    this.a = new float[1]{ 1f };
    base.\u002Ector();
  }
}

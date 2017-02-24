using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class CItem : ScriptableObject {
    public readonly int ID;                 // 아이디
    public string Title { get; set; }       // 이름
    public string SpritePath { get; set; }  // 스프라이트 경로
    public Sprite Sprite { get; set; }      // 스프라이트
    public bool Stackable { get; set; }     // 여러개 쌓을수 있는지 여부

    public CItem()
    {
        ID = -1;    // 빈 아이템
    }

    public CItem(int id, string title, string path)
    {
        ID = id;
        Title = title;

        SpritePath = path;
        Sprite = Resources.Load<Sprite>(path);
    }

    public static CItem NonItem = new CItem(-1, "None", null);
}


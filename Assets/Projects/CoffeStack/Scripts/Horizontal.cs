using UnityEngine;

public class HorizontalLayout : MonoBehaviour
{
    public float spacing = 1f; // Nesneler arasındaki boşluk

    void Start()
    {
        // Tüm çocuk nesneleri al
        Transform[] children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }

        // Çocuk nesneleri pozisyonlarına göre sırala
        System.Array.Sort(children, ComparePosition);

        // Nesneleri yatayda hizala
        for (int i = 0; i < children.Length; i++)
        {
            Vector3 pos = children[i].position;
            pos.x = i * (children[i].lossyScale.x + spacing);
            children[i].position = pos;
        }
    }

    // İki transformun pozisyonlarını karşılaştıran fonksiyon
    int ComparePosition(Transform a, Transform b)
    {
        if (a.position.x < b.position.x) return -1;
        else if (a.position.x > b.position.x) return 1;
        else return 0;
    }
}

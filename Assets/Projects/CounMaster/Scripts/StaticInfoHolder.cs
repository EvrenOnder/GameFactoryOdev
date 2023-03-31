using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInfoHolder
{
    //kalabalığın maksimum ve minimum x pozisyonları burada saklanıyor. Platformdan sarkmasınlar diye
    public static float maxXpos = -20000;//ilk karşılaştırma için 
    public static float minXpos = 20000;//ilk karşılaştırma için 

    //platformun genişlik bilgileri burada saklanıyor. Oyun açıldığı an set ediliyor.
    public static float minPlatformXpos = 0;
    public static float maxPlatformXpos = 0;

    public static Man[] mans;
}

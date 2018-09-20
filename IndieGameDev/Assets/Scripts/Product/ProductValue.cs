using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductValue : MonoBehaviour {

    [SerializeField]
    private int smallBaseValue = 0, mediumBaseValue = 0, largeBaseValue = 0;

    private int productValue;

    public int GetValue()
    {
        return productValue;
    }

    public void CalculateValue(int mThreshold, int lThreshold, int size, int quality)
    { 
        //product is small
        if(size < mThreshold)
        {
            productValue = smallBaseValue;
        }
        //product is medium
        else if(size >= mThreshold && size < lThreshold)
        {
            productValue = mediumBaseValue;
        }
        else if(size >= lThreshold)
        {
            productValue = largeBaseValue;
        }

        productValue = productValue * quality;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour {

    //Products are created by finishing certain tasks
    //and the are able to generate value for the company.
    [Header("NOTE! Values not to be set in inspector.")]
    [SerializeField]
    private int mediumProductThreshold;
    [SerializeField]
    private int largeprojectThreshold;
    [SerializeField]
    private int productSize, productQuality;

    private ProductValue productValue;

    public void Initialize(int mThreshold, int lThreshold, int size, int quality)
    {
        SetSizeThresholds(mThreshold, lThreshold);
        productSize = size;
        productQuality = quality;

        productValue = GetComponent<ProductValue>();
        productValue.CalculateValue(mThreshold, lThreshold, size, quality);
        StartCoroutine(SellTimer());
    }

    private void SetSizeThresholds(int m, int l)
    {
        mediumProductThreshold = m;
        largeprojectThreshold = l;
    }

    public void SellProduct()
    {
        Debug.Log("Product sold! " + productValue.GetValue() + " added to capital");

        GameObject capital = GameObject.FindGameObjectWithTag("Capital");

        if (capital != null)
        {
            capital.GetComponent<Capital>().AddMoney(productValue.GetValue());
        }
        else
        {
            Debug.Log("Error! Unable to find gameObject tagged with 'Capital'");
        }

        Destroy(gameObject);
    }

    private IEnumerator SellTimer() //Temporary function to delay product sale.
    {
        yield return new WaitForSeconds(1f);

        SellProduct();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    [SerializeField] private Transform parentTransformForAnimalsCards;
    [SerializeField] private GameObject prefabForAnimal;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private InfoPanelUiProporties infoPanelUiProporties;
    public void CreateAnimalsCards(AnimalsData animals)
    {
        foreach (var item in animals.Animals)
        {
            GameObject g = Instantiate(prefabForAnimal, parentTransformForAnimalsCards);
            AnimalCardUiProporties animalCardUiProporties = g.GetComponent<AnimalCardUiProporties>();
            animalCardUiProporties.type.text = item.type;
            g.GetComponent<Button>().onClick.AddListener(() =>
            {
                infoPanel.SetActive(true);
                infoPanelUiProporties.info.text = item.text;
            });
        }
    }
}

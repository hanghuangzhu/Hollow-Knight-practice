using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CardManager cardManager;
    public GameObject[] cardSlots;
    public GameObject BG;
    public GameObject ONE;
    public Color humanColor, orcColor, undeadColor, nightElfColor, neutralColor;

    public int page;
    public Text pageText;


    [SerializeField] private bool isSearch;
    [SerializeField] private int totalNumbers;
    [SerializeField] private int currentSearchMana;

    [SerializeField] private bool isSearchByMana;
    [SerializeField] private bool isSearchByClass;
    [SerializeField] private string currentSearchClass;

    private void Start()
    {
        DisplayCards();
    }
    private void Update()
    {
        UpdatePage();

        TurnPage();
        if(!isSearch)
        {
            totalNumbers = 0;
        }
    }

    private void UpdatePage()
    {
        //pageText.text = (page + 1).ToString();
        //pageText.text = (page + 1) + "/" + (Mathf.Ceil(cardSlots.Length / 8) + 1).ToString();

        if(!isSearch)
        {
            pageText.text = (page + 1) + "/" + (Mathf.Ceil(cardSlots.Length / 8) + 1).ToString();
        }
        else
        {
            //pageText.text = "Search By Mana /Class Mode";
            pageText.text = (page + 1) + "/" + (Mathf.Ceil(totalNumbers / 8) + 1).ToString();
        }
    }

    public void InitialCardsTab()
    {
        page = 0;
        isSearch = false;
        DisplayCards();
        BG.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        isSearchByMana = false;
        isSearchByClass = false;
    }



    public void SearchByMana(int _mana)
    {
        BG.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        isSearchByMana = true;
        isSearchByClass = false;

        isSearch = true;
        totalNumbers = 0;
        page = 0;
        currentSearchMana = _mana;

        List<Card> cards = new List<Card>();
        cards = ReturnCard(_mana);

        for(int i =0;i<cardSlots.Length;i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }

        for(int i=0;i<cards.Count;i++)
        {
            if(i>=page*8 && i<(page+1)*8)
            {
                totalNumbers++;
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text =cards[i].cardName;
                cardSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardDes;

                cardSlots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite =cards[i].cardBgSprite;
                cardSlots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite =cards[i].cardSprite;

                cardSlots[i].transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text =cards[i].cardAttack.ToString();
                cardSlots[i].transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardHealth.ToString();
                cardSlots[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardMana.ToString();



                switch (cards[i].cardClass)
                {
                    case CardClass.Human:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Human";
                            cardSlots[i].GetComponent<Image>().color = humanColor;
                            break;
                        }
                    case CardClass.Orc:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Orc";
                            cardSlots[i].GetComponent<Image>().color = orcColor;
                            break;
                        }
                    case CardClass.Undead:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Undead";
                            cardSlots[i].GetComponent<Image>().color = undeadColor;
                            break;
                        }
                    case CardClass.NightElf:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "NightElf";
                            cardSlots[i].GetComponent<Image>().color = nightElfColor;
                            break;
                        }
                    case CardClass.Neutral:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Neutral";
                            cardSlots[i].GetComponent<Image>().color = neutralColor;
                            break;
                        }
                }
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }
        }
    }

    public void SearchByClass(string _cardClass)
    {
        
        //Debug.Log(_cardClass);

        isSearchByMana = false;
        isSearchByClass = true;

        isSearch = true;
        totalNumbers = 0;
        page = 0;
        currentSearchClass = _cardClass;
        List<Card> cards = new List<Card>();
        cards = ReturnCard(_cardClass);
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < cards.Count; i++)
        {
            if (i >=page * 8 && i < (page + 1) * 8)
            {
                totalNumbers++;
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardName;
                cardSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardDes;

                cardSlots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = cards[i].cardBgSprite;
                cardSlots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = cards[i].cardSprite;

                cardSlots[i].transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardAttack.ToString();
                cardSlots[i].transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardHealth.ToString();
                cardSlots[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardMana.ToString();



                switch (cards[i].cardClass)
                {
                    case CardClass.Human:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Human";
                            cardSlots[i].GetComponent<Image>().color = humanColor;
                            break;
                        }
                    case CardClass.Orc:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Orc";
                            cardSlots[i].GetComponent<Image>().color = orcColor;
                            break;
                        }
                    case CardClass.Undead:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Undead";
                            cardSlots[i].GetComponent<Image>().color = undeadColor;
                            break;
                        }
                    case CardClass.NightElf:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "NightElf";
                            cardSlots[i].GetComponent<Image>().color = nightElfColor;
                            break;
                        }
                    case CardClass.Neutral:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Neutral";
                            cardSlots[i].GetComponent<Image>().color = neutralColor;
                            break;
                        }
                }
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }
        }
        BG.GetComponent<Image>().color = ONE.GetComponent<Image>().color;
        

    }

    private List<Card> ReturnCard(int _mana)
    {
        List<Card> cards = new List<Card>();
        for(int i=0;i<cardManager.cards.Count;i++)
        {
            Card card;
            if(_mana <8)
            {
                if (cardManager.cards[i].cardMana == _mana)
                {
                    card = cardManager.cards[i];
                    cards.Add(card);
                }
            }
            else
            {
                if (cardManager.cards[i].cardMana >= _mana)
                {
                    card = cardManager.cards[i];
                    cards.Add(card);
                }
            }
        }
        //Debug.log(cards.Count);
        return cards;
    }

    private List<Card> ReturnCard(string _cardClass)
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            Card card;

            if (cardManager.cards[i].cardClass.ToString() == _cardClass)
            {
                card = cardManager.cards[i];
                cards.Add(card);
            }
            //Debug.log(cards.Count);
        }
        return cards;
    }

    private void DisplayCards()
    {
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            if(i>=page*8 && i<(page+1)*8)
            {
                DisplaySingleCard(i);
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }
        }
    }

    private void TurnPage()
    {
        if(!isSearch)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (page >= Mathf.Floor((cardManager.cards.Count - 1) / 8))
                {
                    page = 0;
                }
                else
                {
                    page++;
                }
                DisplayCards();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (page <= 0)
                {
                    page = Mathf.FloorToInt((cardManager.cards.Count - 1) / 8);
                }
                else
                {
                    page--;
                }
                DisplayCards();
            }
        }
        else
        {
            if(isSearchByMana)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (page >= (Mathf.FloorToInt(totalNumbers / 8)))
                    {
                        page = 0;
                    }
                    else
                    {
                        page++;
                    }
                    DisplayBySearchMana();
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (page <= 0)
                    {
                        page = (Mathf.FloorToInt(totalNumbers / 8));
                    }
                    else
                    {
                        page--;
                    }
                    DisplayBySearchMana();
                }
            }
            if(isSearchByClass)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (page >= (Mathf.FloorToInt(totalNumbers / 8)))
                    {
                        page = 0;
                    }
                    else
                    {
                        page++;
                    }
                    DisplayBySearchClass();
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (page <= 0)
                    {
                        page = (Mathf.FloorToInt(totalNumbers / 8));
                    }
                    else
                    {
                        page--;
                    }
                    DisplayBySearchClass();
                }
            }
        }
    }

    private void DisplaySingleCard(int i)
    {
        totalNumbers++;
        cardSlots[i].gameObject.SetActive(true);
        cardSlots[i].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = cardManager.cards[i].cardName;
        cardSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = cardManager.cards[i].cardDes;

        cardSlots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = cardManager.cards[i].cardBgSprite;
        cardSlots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = cardManager.cards[i].cardSprite;

        cardSlots[i].transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = cardManager.cards[i].cardAttack.ToString();
        cardSlots[i].transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = cardManager.cards[i].cardHealth.ToString();
        cardSlots[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cardManager.cards[i].cardMana.ToString();



        switch (cardManager.cards[i].cardClass)
        {
            case CardClass.Human:
                {
                    cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Human";
                    cardSlots[i].GetComponent<Image>().color = humanColor;
                    break;
                }
            case CardClass.Orc:
                {
                    cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Orc";
                    cardSlots[i].GetComponent<Image>().color = orcColor;
                    break;
                }
            case CardClass.Undead:
                {
                    cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Undead";
                    cardSlots[i].GetComponent<Image>().color = undeadColor;
                    break;
                }
            case CardClass.NightElf:
                {
                    cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "NightElf";
                    cardSlots[i].GetComponent<Image>().color = nightElfColor;
                    break;
                }
            case CardClass.Neutral:
                {
                    cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Neutral";
                    cardSlots[i].GetComponent<Image>().color = neutralColor;
                    break;
                }
        }
    }

    private void DisplayBySearchMana()
    {
        List<Card> cards = new List<Card>();
        cards = ReturnCard(currentSearchMana);

        for(int i=0;i<cardSlots.Length;i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }
        for(int i=0;i<cards.Count;i++)
        {
            if(i>=page*8 && i<(page+1)*8)
            {
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardName;
                cardSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardDes;

                cardSlots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = cards[i].cardBgSprite;
                cardSlots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = cards[i].cardSprite;

                cardSlots[i].transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardAttack.ToString();
                cardSlots[i].transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardHealth.ToString();
                cardSlots[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardMana.ToString();



                switch (cards[i].cardClass)
                {
                    case CardClass.Human:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Human";
                            cardSlots[i].GetComponent<Image>().color = humanColor;
                            break;
                        }
                    case CardClass.Orc:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Orc";
                            cardSlots[i].GetComponent<Image>().color = orcColor;
                            break;
                        }
                    case CardClass.Undead:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Undead";
                            cardSlots[i].GetComponent<Image>().color = undeadColor;
                            break;
                        }
                    case CardClass.NightElf:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "NightElf";
                            cardSlots[i].GetComponent<Image>().color = nightElfColor;
                            break;
                        }
                    case CardClass.Neutral:
                        {
                            cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Neutral";
                            cardSlots[i].GetComponent<Image>().color = neutralColor;
                            break;
                        }
                }
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }
            
        }
    }

    private void DisplayBySearchClass()
    {
            List<Card> cards = new List<Card>();
            cards = ReturnCard(currentSearchClass);

            for (int i = 0; i < cardSlots.Length; i++)
            {
                cardSlots[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < cards.Count; i++)
            {
                if (i >= page * 8 && i < (page + 1) * 8)
                {
                    cardSlots[i].gameObject.SetActive(true);
                    cardSlots[i].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardName;
                    cardSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardDes;

                    cardSlots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = cards[i].cardBgSprite;
                    cardSlots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = cards[i].cardSprite;

                    cardSlots[i].transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardAttack.ToString();
                    cardSlots[i].transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardHealth.ToString();
                    cardSlots[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cards[i].cardMana.ToString();



                    switch (cards[i].cardClass)
                    {
                        case CardClass.Human:
                            {
                                cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Human";
                                cardSlots[i].GetComponent<Image>().color = humanColor;
                                break;
                            }
                        case CardClass.Orc:
                            {
                                cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Orc";
                                cardSlots[i].GetComponent<Image>().color = orcColor;
                                break;
                            }
                        case CardClass.Undead:
                            {
                                cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Undead";
                                cardSlots[i].GetComponent<Image>().color = undeadColor;
                                break;
                            }
                        case CardClass.NightElf:
                            {
                                cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "NightElf";
                                cardSlots[i].GetComponent<Image>().color = nightElfColor;
                                break;
                            }
                        case CardClass.Neutral:
                            {
                                cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Neutral";
                                cardSlots[i].GetComponent<Image>().color = neutralColor;
                                break;
                            }
                    }
                }
                else
                {
                    cardSlots[i].gameObject.SetActive(false);
                }
            }
    }
}

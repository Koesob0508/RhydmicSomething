using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Prototype02
{
    public abstract class P2UIManager : MonoBehaviour
    {
        [SerializeField] protected GameObject pannel;
        [SerializeField] protected GameObject rewardUI;
        protected P2SongWriter songWriter;

        protected string rewardDetail;
        protected List<int> rewardFlow;
        protected UnityAction rewardAction;

        [SerializeField] protected List<GameObject> rewardObjects;

        protected List<TextMeshProUGUI> rewardTexts;
        protected List<List<Image>> rewardImages;
        [SerializeField] protected List<Button> rewardButtons;

        public UnityAction closeFloatingUI;

        public bool isImages;

        public void Initialize(P2SongWriter _songWriter)
        {
            this.songWriter = _songWriter;
            (rewardTexts, rewardImages, rewardButtons) = this.InitilizeReward(rewardObjects);
            this.rewardUI.SetActive(false);
            InactivatePannel();

            if (rewardImages.Count == 3 && rewardImages[0].Count == 8)
            {
                isImages = true;
            }
            else
            {
                Debug.Log(rewardImages.Count);
                Debug.Log(rewardImages[0].Count);
            }
        }

        public void LevelUp()
        {
            this.SetRewardUI();
            this.ActivatePannel();
            this.rewardUI.SetActive(true);
        }

        public void CloseRewardUI()
        {
            foreach(Button button in rewardButtons)
            {
                button.onClick.RemoveListener(rewardAction);
            }
            this.rewardUI.SetActive(false);
            closeFloatingUI();
            this.InactivatePannel();
        }
        protected void ActivatePannel()
        {
            this.pannel.SetActive(true);
        }
        protected void InactivatePannel()
        {
            this.pannel.SetActive(false);
        }

        protected (List<TextMeshProUGUI>, List<List<Image>>, List<Button>) InitilizeReward(List<GameObject> _rewardObjects)
        {
            TextMeshProUGUI text;
            List<TextMeshProUGUI> resultTexts = new List<TextMeshProUGUI>();

            GameObject imagesGameObject;
            List<Image> images = new List<Image>();
            List<List<Image>> resultImages = new List<List<Image>>();

            Button button;
            List<Button> resultButtons = new List<Button>();

            foreach (GameObject reward in _rewardObjects)
            {
                images = new List<Image>();

                text = reward.transform.Find("Text").GetComponent<TextMeshProUGUI>();
                button = reward.transform.Find("Button").GetComponent<Button>();
                imagesGameObject = reward.transform.Find("Images").gameObject;

                for (int index = 0; index < imagesGameObject.transform.childCount; index++)
                {
                    images.Add(imagesGameObject.transform.GetChild(index).GetComponent<Image>());
                }

                resultTexts.Add(text);
                resultImages.Add(images);
                resultButtons.Add(button);
            }

            return (resultTexts, resultImages, resultButtons);
        }

        protected void SetRewardUI()
        {
            List<int> indices = new List<int>();
            int actionIndex;
            
            for (int index = 0; index < rewardObjects.Count; index++)
            {
                (actionIndex, rewardAction, rewardFlow, rewardDetail) = songWriter.GetRandomSelectionInfo();

                while (indices.Contains(actionIndex))
                {
                    (actionIndex, rewardAction, rewardFlow, rewardDetail) = songWriter.GetRandomSelectionInfo();
                }

                indices.Add(actionIndex);

                // Reward UI 세팅 시작
                rewardTexts[index].text = rewardDetail;
                rewardButtons[index].onClick.AddListener(rewardAction);

                // Reward 이미지 변경
                var images = rewardImages[index];

                for(int i = 0; i < rewardImages[index].Count; i++)
                {
                    switch(rewardFlow[i])
                    {
                        case 0:
                            images[i].color = Color.black;
                            break;
                        case 1:
                            images[i].color = Color.white;
                            break;
                        case 2:
                            images[i].color = Color.yellow;
                            break;
                        default:
                            break;
                    }
                    
                }
            }
        }
    }
}


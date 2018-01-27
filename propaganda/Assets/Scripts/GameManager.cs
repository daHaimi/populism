using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Populism
{

    public class GameManager : MonoBehaviour
    {


        // Stereotype reference list
        List<StereoType_Attributes> stereoTypeEntities;

        

        public void RegisterStereoType(StereoType_Attributes stereoTypeAttributes)
        {
            stereoTypeEntities.Add(stereoTypeAttributes);
        }


        // Handle time

        public float defaultLevelTime = 100;

        public float timeLeft;

        public void UpdateGameTimer()
        {

            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                EndLevel();
            }
        }



        // handle Scenes 

        // Handle Menu

        public GameObject menu_AfterLevel; // Assign in inspector
        private bool isShowing;


        // Handle gamestart

        public void StartCurrentLevel()
        {

            timeLeft = defaultLevelTime;

            isShowing = false;
            menu_AfterLevel.SetActive(isShowing);

            menu_AfterLevel.transform.Find("/Info Text/Text").GetComponent<Text>().text = "";
            menu_AfterLevel.transform.Find("/Button_StartGame").gameObject.SetActive(false);
            menu_AfterLevel.transform.Find("/Button_Retry").gameObject.SetActive(true);
            menu_AfterLevel.transform.Find("/Button_NextLevel").gameObject.SetActive(false);

        }

        public void SpawnEnemies()
        {

        }

        // Handle GameEnd

        public void EndLevel()
        {
            // count motivated entities
            int count = CountMotivatedEntities();

            menu_AfterLevel.SetActive(true);

            // see if threshhold is reached
            if ((float)count / stereoTypeEntities.Count > 0.8f)
            {
                // show next level menu
                menu_AfterLevel.transform.Find("/Info Text/Text").GetComponent<Text>().text = "Level Complete.";
                menu_AfterLevel.transform.Find("Button_Retry").gameObject.SetActive(false);
                menu_AfterLevel.transform.Find("Button_NextLevel").gameObject.SetActive(true);
            }
            else
            {
                // show retry menu
                menu_AfterLevel.transform.Find("/Info Text/Text").GetComponent<Text>().text = "Your propaganda was not strong enough...";
                menu_AfterLevel.transform.Find("Button_Retry").gameObject.SetActive(true);
                menu_AfterLevel.transform.Find("Button_NextLevel").gameObject.SetActive(false);
            }

            

           

        }

        public void GameCompleted()
        {
            menu_AfterLevel.transform.Find("/Info Text/Text").GetComponent<Text>().text = "Game Completed.";
            menu_AfterLevel.transform.Find("Button_GameStart").gameObject.SetActive(true);
            menu_AfterLevel.transform.Find("Button_Retry").gameObject.SetActive(false);
            menu_AfterLevel.transform.Find("Button_NextLevel").gameObject.SetActive(false);
        }

        public int CountMotivatedEntities()
        {

            int count = 0;

            foreach (StereoType_Attributes attribute in stereoTypeEntities)
            {
                if (attribute.motivation > 0)
                {
                    count++;
                }
            }

            return count;
        }



        // Use this for initialization
        void Start()
        {

            StartCurrentLevel();

        }

        // Update is called once per frame
        void Update()
        {
            UpdateGameTimer();

            if (Input.GetKeyDown("escape") && timeLeft > 0)
            {
                isShowing = !isShowing;
                menu_AfterLevel.SetActive(isShowing);
            }
        }

    }
}

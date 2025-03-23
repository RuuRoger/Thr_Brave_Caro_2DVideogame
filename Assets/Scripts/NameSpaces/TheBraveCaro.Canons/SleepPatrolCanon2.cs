using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Controls;


namespace TheBraveCaro.Canons
{
    public class SleepPatrolCanon2 : PatrolCanon
    {
        [SerializeField] private GameObject _bigLight;
        [SerializeField] private GameObject _redSmallLight;
        [SerializeField] private GameObject[] _sprites;

        private int _randomNumber;
        private bool _isSleeping;
        private void AwakePatrolCanon()
        {
            _isSleeping = false;
            _bigLight.SetActive(true);
            _redSmallLight.SetActive(true);
        }

        private void SleepPatrolCanon()
        {
            _isSleeping = true;
            _bigLight.SetActive(false);
            _redSmallLight.SetActive(false);
            StartCoroutine(ShowingSleep());

        }

        IEnumerator AwakeAndSleep()
        {
            while (true)
            {
                //Random time
                _randomNumber = Random.Range(1, 11);

                //Awake Patrol canon
                AwakePatrolCanon();

                //Active time
                yield return new WaitForSeconds(_randomNumber);

                //Sleep patrolcanon
                SleepPatrolCanon();

                foreach (GameObject sprite in _sprites)
                {
                    sprite.SetActive(false);
                }


                //Waiting random time
                _randomNumber = Random.Range(1, 11);
                yield return new WaitForSeconds(_randomNumber);

            }
        }

        IEnumerator ShowingSleep()
        {
          while (_isSleeping)
            {
                foreach (GameObject sprite in _sprites)
                {
                    yield return new WaitForSeconds(0.2f);
                    sprite.SetActive(true);
                    yield return new WaitForSeconds(0.2f);
                }

                foreach (GameObject sprite in _sprites)
                {
                    sprite.SetActive(false);
                }
            }
        }

        private void Start()
        {
            StartCoroutine(AwakeAndSleep());
        }

    }

}
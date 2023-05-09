using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace mine
{
    public interface Pick
    {

        static int score { get; set; }
        public void onHit();



    }

    public class checkCube
    {

        public void call(Pick obj)
        {
            obj.onHit();
        }

    }

    public class Success : Pick
    {

        public void onHit()
        {
            Pick.score = 10;
        }
    }

    public class Danger : Pick
    {
        public void onHit()
        {
            Pick.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    public class Normal : Pick
    {
        public void onHit()
        {
            Pick.score = 5;

        }
    }

    public class ScoreSet : MonoBehaviour
    {



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

using UnityEngine;


namespace Assets.Scripts.MapGeneration
{
    class VoronoiTest
    {
        RandomWorldGenerator rwg;

        void Awake()
        {
            rwg = new RandomWorldGenerator();
            rwg.InitWorldGenerator(100, 50, 500);

        }

        void Update()
        {
            if(Input.anyKeyDown)
                Test();
        }

        private void Test()
        {
            rwg.CreateMap();

        }

        void OnDrawGizmos()
        {
        }
    }
}

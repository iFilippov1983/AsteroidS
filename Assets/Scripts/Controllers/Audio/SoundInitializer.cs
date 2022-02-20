namespace AsteroidS
{
    public class SoundInitializer
    {
        private readonly SoundEventsStructure _soundEventsStructure;
        private static SoundInitializer _instance;

        public static SoundInitializer Instance
        {
            get 
            {
                if (_instance == null) return new SoundInitializer();
                else return _instance;
            }
            private set { _instance = value; }
        }
        private SoundInitializer()
        {
            Instance = this;
            _soundEventsStructure.soundVolumeChangeEvent = null;
            _soundEventsStructure.shotEventDefault = new ProxyShotEventDefault();
            _soundEventsStructure.shotEventLazer = null;
            _soundEventsStructure.hitEventAsteroid = null;
            _soundEventsStructure.hitEventEnemyShip = null;
            _soundEventsStructure.destroyEventAsteroid = null;
            _soundEventsStructure.destroyEventEnemyShip = null;
        }

        public SoundEventsStructure GetSoundEvents()
        {
            SoundEventsStructure result = _soundEventsStructure;
            return result;
        }
    }
}
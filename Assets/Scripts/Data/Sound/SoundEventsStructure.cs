namespace AsteroidS
{
    public struct SoundEventsStructure 
    {
        public ISoundEventProxy soundVolumeChangeEvent;
        public ISoundEventProxy shotEventDefault;
        public ISoundEventProxy shotEventLazer;
        public ISoundEventProxy hitEventAsteroid;
        public ISoundEventProxy hitEventEnemyShip;
        public ISoundEventProxy destroyEventAsteroid;
        public ISoundEventProxy destroyEventEnemyShip;
    }
}
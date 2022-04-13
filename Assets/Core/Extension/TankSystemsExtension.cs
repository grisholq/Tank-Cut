using Leopotam.Ecs;

public static class TankSystemsExtension
{
    public static void AddTankSystems(this EcsSystems systems)
    {
        systems.Add(new TankShotStateResetSystem());

        systems.Add(new TankClickSystem());

        systems.Add(new TankShotSystem());
        systems.Add(new TankShotMarkSystem());

        systems.Add(new TankCannonballSpawnSystem());
        systems.Add(new TankCannonballSplineSetSystem());
        systems.Add(new TankCannonballStartSetSystem());

        systems.Add(new TankMoulageCannonballEndSetSystem());
        systems.Add(new TankTargetCannonballEndSetSystem());

        systems.Add(new TankCannonballHitDeleterSystem());
        systems.Add(new TankCannonballHitSystem());
        systems.Add(new TankDeathSystem());

        systems.Add(new TankWinCheckSystem());
        systems.Add(new TankLoseCheckSystem());
    }
}
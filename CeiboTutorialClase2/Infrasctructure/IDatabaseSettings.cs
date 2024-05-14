namespace CeiboTutorialClase2.Infrasctructure
{
    public interface IDatabaseSettings
    {
        string ConectionString { get; set; }
        string Name { get; set; }
    }
}
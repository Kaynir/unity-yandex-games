using System;

namespace Kaynir.YandexGames.Services.Clouds
{
    public interface ICloudService
    {
        event Action<string> DataLoaded;
        event Action<bool> DataSaved;

        void LoadData();
        void SaveData(string data);
    }
}
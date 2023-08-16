using System;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Services.Clouds
{
    public class YandexCloudService : MonoBehaviour, ICloudService
    {
        public event Action<string> DataLoaded;
        public event Action<bool> DataSaved;

        public void LoadData()
        {
            YandexPlugin.LoadData();
        }

        public void SaveData(string data)
        {
            YandexPlugin.SaveData(data);
        }

        #region JS Callbacks
        private void OnDataLoaded(string data) => DataLoaded?.Invoke(data);
        private void OnDataSaved(bool result) => DataSaved?.Invoke(result);
        #endregion
    }
}
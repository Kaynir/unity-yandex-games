using System;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Services
{
    public class YandexCloudService : MonoBehaviour, ICloudService
    {
        #region Events
        public event Action<string> DataLoaded;
        public event Action<bool> DataSaved;
        #endregion

        #region Methods
        public void LoadData() => YandexPlugin.LoadData();
        public void SaveData(string data) => YandexPlugin.SaveData(data);
        #endregion

        #region JS Callbacks
        private void OnDataLoaded(string data) => DataLoaded?.Invoke(data);
        private void OnDataSaved(bool result) => DataSaved?.Invoke(result);
        #endregion
    }
}
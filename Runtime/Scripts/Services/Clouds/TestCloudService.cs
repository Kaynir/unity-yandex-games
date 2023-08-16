using System;
using UnityEngine;

namespace Kaynir.YandexGames.Services.Clouds
{
    public class TestCloudService : MonoBehaviour, ICloudService
    {
        public event Action<string> DataLoaded;
        public event Action<bool> DataSaved;

        [SerializeField] private bool positiveSaveResult = true;

        public void LoadData()
        {
            Debug.Log("Test data loaded.");
            DataLoaded?.Invoke(string.Empty);
        }

        public void SaveData(string data)
        {
            Debug.Log($"Test data saved with result: {positiveSaveResult}.");
            DataSaved?.Invoke(positiveSaveResult);
        }
    }
}

mergeInto(LibraryManager.library, {

  GetSDKStatus: function () {
    console.log('SDK status:', sdkStatus);
    return sdkStatus;
  },

  GetAuthStatus: function () {
    console.log('Auth status:', authStatus);
    return authStatus();
  },

  GetDevice: function () {
    var device = ysdk.deviceInfo.type;
    console.log('Detected device:', device);
    var bufferSize = lengthBytesUTF8(device) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(device, buffer, bufferSize);
    return buffer;
  },

  GetLanguage: function () {
    var language = ysdk.environment.i18n.lang;
    console.log('Detected language:', language);
    var bufferSize = lengthBytesUTF8(language) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(language, buffer, bufferSize);
    return buffer;
  },

  SaveData: function (data) {
    var dataString = UTF8ToString(data);
    var dataObject = JSON.parse(data);
    player.setData(dataObject).then(() => {
      gameInstance.SendMessage('YandexSDK', 'OnDataSaved');
      console.log('Data saved.');
    }).catch((err) => {
      console.log('Failed to save data with error:', err);
    });
  },

  LoadData: function () {
    player.getData().then(data => {
      var dataString = JSON.stringify(data);
      gameInstance.SendMessage('YandexSDK', 'OnDataLoaded', dataString);
      console.log('Data loaded.');
    }).catch((err) => {
      console.log('Failed to load data with error:', err);
    });
  },

  SetLeaderboard: function (id, value) {
    if (authStatus === 1)
    {
      lb.setLeaderboardScore(UTF8ToString(id), value);
      console.log('Leaderboard updated.');
    }
  },

  ShowFullscreenAdv: function () {
    ysdk.adv.showFullscreenAdv({
      callbacks: {
        onOpen: () => {
          gameInstance.SendMessage('YandexSDK', 'OnFullscreenAdvOpened');
          console.log('Fullscreen adv opened.');
        },
        onClose: function (result) {
          gameInstance.SendMessage('YandexSDK', 'OnFullscreenAdvClosed');
          console.log('Fullscreen adv closed with result:', result);
        },
        onError: function (err) {
          gameInstance.SendMessage('YandexSDK', 'OnFullscreenAdvFailed');
          console.log('Fullscreen adv opened with error:', err);
        }
      }
    });
  },

  ShowRewardedAdv: function (reward) {
    ysdk.adv.showRewardedVideo({
      callbacks: {
        onOpen: () => {
          gameInstance.SendMessage('YandexSDK', 'OnVideoAdvOpened');
          console.log('Video adv opened.');
        },
        onRewarded: () => {
          gameInstance.SendMessage('YandexSDK', 'OnVideoAdvRewarded', reward);
          console.log('Video adv rewarded.');
        },
        onClose: () => {
          gameInstance.SendMessage('YandexSDK', 'OnVideoAdvClosed');
          console.log('Video adv closed.');
        },
        onError: (err) => {
          gameInstance.SendMessage('YandexSDK', 'OnVideoAdvFailed');
          console.log('Video adv opened with error:', err);
        }
      }
    });
  },

});
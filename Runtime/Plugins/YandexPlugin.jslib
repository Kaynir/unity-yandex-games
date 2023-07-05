mergeInto(LibraryManager.library, {

  IsAuthorized: function() {
    return isAuthorized();
  }

  GetDevice: function () {
    let device = getDevice();
    return JavaToUnityString(device);
  }

  GetLanguage: function () {
    let language = getLanguage();
    return JavaToUnityString(language);
  }

  SaveData: function (data) {
    let dataString = UTF8ToString(data);
    saveData(dataString);
  },

  LoadData: function () {
    loadData();
  },

  SetLeaderboardScore: function (id, value) {
    let leaderboardID = UTF8ToString(id);
    setLeaderboardScore(leaderboardID, value);
  },

  ShowFullscreenAdv: function () {
    showFullscreenAdv();
  },

  ShowRewardedAdv: function (reward) {
    showRewardedAdv(reward);
  },

});
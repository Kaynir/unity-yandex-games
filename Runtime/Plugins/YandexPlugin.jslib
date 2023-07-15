mergeInto(LibraryManager.library, {

  IsAuthorized: function() {
    return isAuthorized();
  }

  GetSystemData: function () {
    return getSystemData();
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